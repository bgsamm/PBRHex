using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex.Core.IO
{
    public static class FileInfoExtensions
    {
        public static string GetName(this FileInfo fileInfo) {
            return fileInfo.Name;
        }

        public static string GetPath(this FileInfo fileInfo) {
            return fileInfo.FullName;
        }
    }
}
