using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xServer.Enums;

namespace xServer.Core.Data
{
    public class FileManagerListTag
    {
        public PathType type { get; set; }

        public long fileSize { get; set; }

        public FileManagerListTag(PathType type, long fileSize)
        {
            this.type = type;
            this.fileSize = fileSize;
        }
    }
}
