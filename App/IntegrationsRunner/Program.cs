using IntegrationsLib;
using System.Diagnostics;
using System.Reflection;

var integrationDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Integrations");
var directoryCompressionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "ZipFiles");

if(!Directory.Exists(directoryCompressionDirectory))
{
    Directory.CreateDirectory(directoryCompressionDirectory);
}

if(!Directory.Exists(integrationDirectory))
{
    Directory.CreateDirectory(integrationDirectory);    
}

foreach(var zipFile in Directory.GetFiles(directoryCompressionDirectory, "*.zip"))
{
    File.Delete(zipFile);
}

var integrations = Directory.GetFiles(integrationDirectory, "*.dll");
var sw = new Stopwatch();

var directoryToCompress = "G:\\Code\\git\\Repos\\InVentry\\Core";

if (!string.IsNullOrWhiteSpace(directoryToCompress))
{
    if (!Directory.Exists(directoryToCompress))
    {
        Console.WriteLine("Directory does not exist");
        return;
    }
}

foreach (var integration in integrations)
{
   foreach(var type in Assembly.LoadFrom(integration).GetTypes())
    {
        if (type.IsClass && type.GetInterfaces().Contains(typeof(IZipLibIntegration)))
        {
            var instance = Activator.CreateInstance(type) as IZipLibIntegration;

            if(instance == null)
                continue;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Testing {instance.Name} integration");
            sw.Start();
            instance.CompressDirectory(directoryToCompress, Path.Combine(directoryCompressionDirectory, $"{instance.Name}.zip"));
            sw.Stop();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{instance.Name} integration completed file compression in {sw.ElapsedMilliseconds / 1000} seconds");

            Console.ForegroundColor = ConsoleColor.White;

            sw.Reset();

        }
    }
}