using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using SocketSQL.Services;

namespace SocketSQL
{
    /**
     * Utilizando os aprendizamos passados pelo professor, no curso, estou criando essa pequena
     * aplicação, onde utilizo os novos conhecimentos que ganhei de comunicação por sockets com
     * registros de dados no SQL.
     */

    class Program
    {
        static void Main(string[] args)
        {
            var diretorio = new FileService();
            var dados = new DadosService();
            var log = string.Empty;

            try
            {
                diretorio.CriarArquivoLog();

                var listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var ipAddress = IPAddress.Any;

                var ipEndPoint = new IPEndPoint(ipAddress, 23000);

                listenerSocket.Bind(ipEndPoint);
                listenerSocket.Listen(5);

                Console.WriteLine("Prestes a aceitar conexão: ");

                var client = listenerSocket.Accept();

                log = $"Conexão aceita: {client.ToString()}";
                Console.WriteLine(log);
                diretorio.GravarLog(log);

                log = $"IP EndPonit do cliente: {client.RemoteEndPoint.ToString()}";
                Console.WriteLine(log);
                diretorio.GravarLog(log);

                var buff = new byte[128];

                while (true)
                {
                    var numReceivedBytes = client.Receive(buff);

                    var receivedText = Encoding.UTF8.GetString(buff, 0, numReceivedBytes);
                    log = $"Conteúdo recebido: {receivedText}";
                    Console.WriteLine(log);
                    diretorio.GravarLog(log);

                    client.Send(buff);

                    dados.GravarDados(receivedText);

                    if (receivedText.ToUpper().Equals("X"))
                        break;
                    
                    Array.Clear(buff, 0, numReceivedBytes);

                    numReceivedBytes = 0;
                }
            }
            catch (Exception e)
            {
                log = $"O seguinte erro ocorreu: {e.Message}";
                Console.WriteLine(log);
                diretorio.GravarLog(log);
            }
        }
    }
}
