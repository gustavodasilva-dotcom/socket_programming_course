using System;
using System.Text;
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

                Console.WriteLine("Prestes a aceitar conexão: ");

                /**
                 * O método Accept() retorna um socket -- que, no caso, é o cliente. Um cliente, para se comunicar com socket
                 * no server-side, precisa, também, abrir um socket (informações retiradas do blog:
                 * https://blog.pantuza.com/artigos/o-que-sao-e-como-funcionam-os-sockets). Então, quando o cliente faz a
                 * comunicação com o socket do server-side, a aplicação do server-side utilizada o Accept() para ser comunicar.
                 * No caso do C#, o método Accept() retorna, justamente, o cliente que está fazendo a "requisição" e a conexão.
                 */
                var client = listenerSocket.Accept();

                Console.WriteLine($"Client conectado: {client.ToString()}.");

                Console.WriteLine($"IP EndPoint: {client.RemoteEndPoint.ToString()}.");

                var buff = new byte[128];

                /**
                 * O método Receive() recebe informações através do socket (informações do cliente). Esse método recebe, como
                 * parâmetro, um array de bytes -- que, nesse caso, funcionará como um parâmetro de tipo de referência. Ou seja,
                 * o método irá preencher o array de bytes com os dados recebidos do cliente através do socket (os dados são
                 * em binários).
                 */
                var numReceivedBytes = client.Receive(buff);

                Console.WriteLine($"Número de bytes recebidos: {numReceivedBytes}");

                var receivedText = Encoding.ASCII.GetString(buff, 0, numReceivedBytes);

                Console.WriteLine($"Dados recebidos: {receivedText}");
            }
            catch (Exception e)
            {
                Console.Write($"An error occurred: {e.Message}");
            }
        }
    }
}
