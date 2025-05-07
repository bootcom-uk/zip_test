namespace IntegrationsLib
{
    public interface IZipLibIntegration
    {

        string Name { get; set; }

        void CompressDirectory(string sourceDirectory, string destinationZipFile);

    }
}
