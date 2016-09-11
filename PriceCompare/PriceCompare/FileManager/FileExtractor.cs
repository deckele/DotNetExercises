using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class FileExtractor
    {
        public void DecompressGzFiles(string directoryPath, string fileSearchQuery = "*.gz")
        {
            var filesToDecompress = Directory.GetFiles(directoryPath, fileSearchQuery + "*.gz", SearchOption.AllDirectories);

            foreach (var filePathToDecompress in filesToDecompress)
            {
                Decompress(filePathToDecompress);
            }
        }

        private void Decompress(string filePathToDecompress)
        {
            var fileToDecompress = new FileInfo(filePathToDecompress);
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName + ".xml"))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }

        public string[] GetXmlFilePaths(string directoryPath, string fileSearchQuery = "*.xml")
        {
            return Directory.GetFiles(directoryPath, fileSearchQuery + "*.xml", SearchOption.AllDirectories);
        }
    }
}
