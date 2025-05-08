using IntegrationsLib;
using System.IO.Compression;

namespace SystemIOCompression
{
    public class Integration : IZipLibIntegration
    {
        public string Name { get; set; } = "System.IO.Compression";

        public void CompressDirectory(string sourceDirectory, string destinationZipFile)
        {
            if (File.Exists(destinationZipFile))
                File.Delete(destinationZipFile);
            ZipFile.CreateFromDirectory(sourceDirectory, destinationZipFile);
        }

        public void CompressDirectoryWithPassword(string sourceDirectory, string destinationZipFile, string password)
        {
            throw new NotImplementedException();
        }
    }
}
