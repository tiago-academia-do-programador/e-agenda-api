using Microsoft.Extensions.Configuration;
using System.IO;

namespace eAgenda.Infra.Configs
{
    public class ConfiguracaoAplicacaoeAgenda
    {
        public ConfiguracaoAplicacaoeAgenda()
        {
            IConfiguration configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            //configuracao.GetConnectionString("SqlServer");

            var connectionString =
                "Server=tcp:eagenda.database.windows.net,1433;" +
                "Initial Catalog=eAgendaDb;" +
                "Persist Security Info=False;" +
                "User ID=rech;" +
                "Password=Helen@2014;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;";


            ConnectionStrings = new ConnectionStrings { SqlServer = connectionString };

            var diretorioSaida = configuracao
                .GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida")
                .Value;

            VersaoSistema = configuracao.GetSection("VersaoSistema").Value;

            ConfiguracaoLogs = new ConfiguracaoLogs { DiretorioSaida = diretorioSaida };
        }

        public string VersaoSistema { get; set; }

        public ConfiguracaoLogs ConfiguracaoLogs { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConfiguracaoLogs
    {
        public string DiretorioSaida { get; set; }
    }

    public class ConnectionStrings
    {
        public string SqlServer { get; set; }
    }
}
