using System;
using SocketAsync.Service;

namespace SocketAsync.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var socketClient = new SocketClientService();
                
                socketClient.RaiseLogEvent += HandlerTextReceivedEvent;

                Console.Write("Please, type a valid server IP Address and press Enter: ");
                var setIp = socketClient.SetServerIPAddress(Console.ReadLine());

                Console.Write("Please, type a valid port number and press Enter: ");
                var setPort = socketClient.SetPortNumber(Console.ReadLine());

                if (!setIp || !setPort)
                {
                    Console.WriteLine(string.Format("The IP Address or Port Number supplied is invalid."));
                    Console.WriteLine(string.Format("Press a key to exit..."));

                    Console.ReadKey();

                    return;
                }

                Console.WriteLine();

                socketClient.ConnectToServerAsync();

                var input = string.Empty;

                do
                {
                    Console.Write("Keep running (if not, type <exit>: ");
                    input = Console.ReadLine();

                    if (!input.Trim().Equals("<exit>"))
                    {
                        socketClient.SendToServer(input);
                    }
                    else
                    {
                        socketClient.CloseAndDisconnect();
                    }
                }
                while (!input.Trim().Equals("<exit>"));
            }
            catch (Exception e)
            {
                Console.WriteLine($"The following error occurred: {e.Message}");
            }
        }

        private static void HandlerTextReceivedEvent(object sender, LogEventArgs e)
        {
            try
            {
                Console.WriteLine(string.Format($"{DateTime.Now} - {e.Log}"));
                Console.WriteLine(Environment.NewLine);
            }
            catch (Exception) { throw; }
        }
    }
}
