using ICSharpCode.SharpZipLib.Zip;
using IntegrationsLib;

namespace SharpZip
{
    public class Integration : IZipLibIntegration
    {

        public string Name { get; set; } = "SharpZipLib";

        public void CompressDirectory(string sourceDirectory, string destinationZipFile)
        {
            using var zipStream = new ZipOutputStream(File.Create(destinationZipFile));
            zipStream.SetLevel(9);

            var files = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var entryName = Path.GetRelativePath(sourceDirectory, file);
                var entry = new ZipEntry(entryName) { DateTime = DateTime.Now };
                zipStream.PutNextEntry(entry);

                var buffer = File.ReadAllBytes(file);
                zipStream.Write(buffer, 0, buffer.Length);
            }
            zipStream.Finish();
        }

    }
}
