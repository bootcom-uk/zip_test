using IntegrationsLib;
using Ionic.Zip;

namespace DotNetZip
{
    public class Integration : IZipLibIntegration
    {

        public string Name { get; set; } = "DotNetZip";

        public void CompressDirectory(string sourceDirectory, string destinationZipFile)
        {
            using var zip = new ZipFile();
            zip.AddDirectory(sourceDirectory);
            zip.Save(destinationZipFile);
        }

        public void CompressDirectoryWithPassword(string sourceDirectory, string destinationZipFile, string password)
        {
            using var zip = new ZipFile();
            zip.Password = password;
            zip.AddDirectory(sourceDirectory);
            zip.Save(destinationZipFile);
        }
    }
}
