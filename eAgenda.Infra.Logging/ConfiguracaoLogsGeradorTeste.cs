using Azure.Storage.Blobs;
using eAgenda.Infra.Configs;
using Serilog;
using Serilog.Events;

namespace eAgenda.Infra.Logging
{
    public class ConfiguracaoLogseAgenda
    {
        public static void ConfigurarEscritaLogs()
        {
            var connectionString = 
                "DefaultEndpointsProtocol=https;AccountName=eagendabloblogging;AccountKey=YDCnFhxJ21ffjUSR7OBYR48dIpPthU/N4di1IQjvDcEkqxqgPzCSI0XDv5SXuBVEJgp1IhKdrCVC+AStqyjIsw==;EndpointSuffix=core.windows.net";

            var x = new BlobServiceClient(connectionString);

            //var config = new ConfiguracaoAplicacaoeAgenda();

            //var diretorioSaida = config.ConfiguracaoLogs.DiretorioSaida;

            Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Information).Enrich.FromLogContext()
                   .MinimumLevel.Debug()
                   .WriteTo.AzureBlobStorage(x, storageFileName: "{yyyy}/{MM}/{dd}/log.txt")
                   .CreateLogger();

            //.WriteTo.Debug()

            //.WriteTo.Seq("http://localhost:5341")
            //.WriteTo.File(diretorioSaida + "/log.txt", rollingInterval: RollingInterval.Day,
            //         outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
        }
    }
}
