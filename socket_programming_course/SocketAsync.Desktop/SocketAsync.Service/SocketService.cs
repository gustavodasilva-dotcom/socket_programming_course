using System;
using System.Net;
using System.Diagnostics;
using System.Net.Sockets;

namespace SocketAsync.Service
{
    public class SocketService
    {
        private TcpListener _tcpListener { get; set; }

        private IPAddress _iPAddress { get; set; }

        private int _port { get; set; }

        public async void ListenIncomingConnectionAsync(IPAddress iPAddress = null, int port = 23000)
        {
            try
            {
                if (iPAddress == null)
                    iPAddress = IPAddress.Any;

                if (port <= 0)
                    port = 23000;

                _iPAddress = iPAddress;
                _port = port;

                Debug.WriteLine(string.Format($"IP Address: {_iPAddress} - Port: {_port}"));

                _tcpListener = new TcpListener(_iPAddress, _port);

                _tcpListener.Start();

                var client = await _tcpListener.AcceptTcpClientAsync();

                Debug.WriteLine(string.Format($"Client accepted and connected successfully: {client}"));
            }
            catch (Exception) { throw; }
        }
    }
}
