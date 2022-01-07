using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClientStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                IPAddress iPAddress;
                var port = 0;

                Console.Write("Por favor, informe um endereço IP válido: ");
                var ip = Console.ReadLine();

                Console.Write("Agora, informe uma porta válida: ");
                var porta = Console.ReadLine();

                if (!IPAddress.TryParse(ip, out iPAddress))
                    throw new Exception("O endereço de IP informado está inválido.");

                if (!int.TryParse(porta.Trim(), out port))
                    throw new Exception("A porta informada está inválida.");

                if (port <= 0 || port > 65535)
                    throw new Exception("A porta informada está inválida, menor que 0 ou maior do que 65535.");

                Console.WriteLine($"Endpoint informado: {ip}:{porta}");

                Console.WriteLine("Tentando estabelecer conexão.");

                client.Connect(iPAddress, port);

                Console.WriteLine("Conexão estabelecida. Digite <exit> ou X para sair.");

                var inputCommand = string.Empty;

                while (true)
                {
                    Console.Write("Digite o que será enviado: ");
                    inputCommand = Console.ReadLine();

                    if (inputCommand.Equals("<exit>"))
                    {
                        break;
                    }

                    client.Send(Encoding.ASCII.GetBytes(inputCommand));

                    var buff = new byte[128];

                    var numBytes = client.Receive(buff);

                    Console.WriteLine($"Dados recebidos: {Encoding.ASCII.GetString(buff, 0, numBytes)}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"O seguinte erro ocorreu: {e.Message}");
            }
            finally
            {
                if (client.Connected)
                    client.Shutdown(SocketShutdown.Both);
                    
                client.Close();
                client.Dispose();
            }

            Console.WriteLine("Pressione alguma tecla para sair...");
            Console.ReadKey();
        }
    }
}
