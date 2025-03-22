using Microsoft.Extensions.Configuration;


namespace OnionArch.Persistence
{
   static class Configration
    {
        static public string DefaultConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                try
                {
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/WebApi"));
                    configurationManager.AddJsonFile("appsettings.json");
                }
                catch
                {
                    configurationManager.AddJsonFile("appsettings.Production.json");
                }

                return configurationManager.GetConnectionString("DefaultConnection");
            }
        }
    }
}

