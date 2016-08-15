#include "stdafx.h"
#include "quasar_client.h"
#include "boost/bind.hpp"
#include "packet_factory.h"
#include "command_handler.h"
#include "quicklz.h"
#include <aes_crypt.h>
#include <helpers.h>
#include <quicklz_helper.h>

using namespace std;
using namespace boost::asio::ip;

quasar_client::quasar_client(boost::asio::io_service& io_srvc) :
	m_sock(io_srvc),
	m_resolver(io_srvc),
	m_hdr_buf(boost::array<unsigned char, 4>()),
	m_connected(false),
	m_compress(true),
	m_encrypt(true),
	m_aes("1WvgEMPjdwfqIMeM9MclyQ==", "NcFtjbDOcsw7Evd3coMC0y4koy/SRZGydhNmno81ZOWOvdfg7sv0Cj5ad2ROUfX4QMscAIjYJdjrrs41+qcQwg==") {
}

quasar_client::~quasar_client() {
	m_sock.close();
}

void quasar_client::connect(string hostname, string port) {
	tcp::resolver::query query(hostname, port);
	auto resolveIterator = m_resolver.resolve(query);
	async_connect(m_sock, resolveIterator, boost::bind(&quasar_client::connect_handler, 
		this, boost::asio::placeholders::error));
}

void quasar_client::send(boost::shared_ptr<quasar_client_packet> packet) {
	vector<byte> payloadBuf = packet->serialize_packet();

	if (m_compress) {
		quicklz_helper::compress_data(payloadBuf);
	}

	if (m_encrypt) {
		m_aes.encrypt(payloadBuf);
	}

	prefix_vector_length(payloadBuf);

	boost::asio::async_write(m_sock, boost::asio::buffer(&payloadBuf[0], payloadBuf.size()),
		[this](boost::system::error_code ec, std::size_t len) {


	});
}

bool quasar_client::get_compress() const {
	return m_compress;
}

void quasar_client::set_compress(const bool value) {
	m_compress = value;
}

bool quasar_client::is_connected() const {
	return m_connected;
}

void quasar_client::connect_handler(const boost::system::error_code &ec) {
	if(ec) {
		msig_on_disconnected();
	}

	m_connected = true;
	read_header();
}

void quasar_client::read_header() {
	async_read(m_sock, boost::asio::buffer(m_hdr_buf, 4),
		[this](boost::system::error_code ec, std::size_t len)
	{
		/* pretty sure len cannot be anything else than 4 here, but just to be sure :P */
		if (ec || len != 4) {
			msig_on_disconnected();
		}

		int hdrSize = *reinterpret_cast<int*>(m_hdr_buf.data());

		if(hdrSize <= 0 || hdrSize > MAX_PACKET_SIZE) {
			// skip this packet
			read_header();
		}
		else {
			m_payload_buf.clear();
			m_payload_buf.resize(hdrSize);
			read_payload();
		}
	});
}

void quasar_client::read_payload() {
	async_read(m_sock, boost::asio::buffer(m_payload_buf),
		[this](boost::system::error_code ec, std::size_t len)
	{
		if (ec) {
			if (ec == boost::asio::error::eof
				|| ec == boost::asio::error::connection_reset) {
				msig_on_disconnected();
			}
			// skip this packet
			read_header();
		}

		if (len != m_payload_buf.size()) {
			//TODO: fix this later
			msig_on_disconnected();
		}

		if (m_encrypt) {
			m_aes.decrypt(m_payload_buf);
		}

		boost::shared_ptr<quasar_server_packet> parsedPacket;

		if (m_compress) {
			quicklz_helper::decompress_data(m_payload_buf);
		}

		try {
			parsedPacket = packet_factory::create_packet(m_payload_buf);
		}
		catch (...) {
			parsedPacket = nullptr;
		}

		if (quasar_packet::is_unknown(parsedPacket)) {
			// skip this packet
			read_header();
		}
		else {
			command_handler::handle_packet(this, parsedPacket);
			read_header();
		}
	});
}
