using System;
using System.Net;
using System.Net.Sockets;

namespace GettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Este é o server-side.

                /**
                 * Instanciando o socket. Nesse construtor, especificado que a conexão do IP é baseada no IPV-4; em seguida,
                 * especificado que o tipo de conexão é um stream; por último, o protocolo é TCP.
                 */
                var listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Especificando que o IP será "qualquer um"; especificamente, o IP 127.0.0.1 (vulgo localhost).
                var ipAddress = IPAddress.Any;

                // Instanciando o endpoint, que é a junção do endereço IP + a porta.
                var ipEndPoint = new IPEndPoint(ipAddress, 23000);

                listenerSocket.Bind(ipEndPoint);
                listenerSocket.Listen(5);
                listenerSocket.Accept();
            }
            catch (Exception e)
            {
                Console.Write($"An error occurred: {e.Message}");
            }
        }
    }
}
