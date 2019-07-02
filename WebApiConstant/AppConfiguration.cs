
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace ZBMigrator.Constants
{
    public class AppConfiguration
    {
        private readonly string _HostEnvironment = string.Empty;
        private readonly string _ConnectionString = string.Empty;

        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            //configurationBuilder.Add(path,);

            var root = configurationBuilder.Build();
            var AppSetting = root.GetSection("ApplicationSettings");
            _HostEnvironment = root.GetSection("HostEnvironment").Value;
            _ConnectionString = root.GetSection("ConnectionString").GetSection(_HostEnvironment).Value;
            

        }
        public string ConnectionString { get => _ConnectionString; }
    }
}