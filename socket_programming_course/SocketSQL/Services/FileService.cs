using System;
using System.IO;

namespace SocketSQL.Services
{
    public class FileService
    {
        private readonly string _diretorio;

        private string _diretorioLog { get; set; }

        private string _arquivoLog { get; set; }

        public FileService()
        {
            _diretorio = @"C:\Users\gusta\source\repos\socket_programming_course\SocketSQL\Logs\";
        }

        public void CriarArquivoLog()
        {
            try
            {
                var arquivoLog = @"\log.txt";

                var diretorioLog = $"{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}";

                _diretorioLog = _diretorio + diretorioLog;

                _arquivoLog = _diretorioLog + arquivoLog;

                if (!Directory.Exists(_diretorio))
                    Directory.CreateDirectory(_diretorio);

                if (!Directory.Exists(_diretorioLog))
                    Directory.CreateDirectory(_diretorioLog);

                if (!File.Exists(_arquivoLog))
                    File.Create(_arquivoLog);
            }
            catch (Exception e)
            {
                Console.WriteLine($"O seguinte erro ocorreu ao criar o arquivo de log: {e.Message}");
            }
        }

        public void GravarLog(string log)
        {
            try
            {
                var texto = File.ReadAllText(_arquivoLog);

                using (var write = new StreamWriter(_arquivoLog))
                {
                    write.WriteLine(texto);
                    write.WriteLine("");
                    write.WriteLine("*************************************************");
                    write.WriteLine($"************** {DateTime.Now} **************");
                    write.WriteLine(log);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"O seguinte erro ocorreu ao criar o arquivo de log: {e.Message}");
            }
        }
    }
}