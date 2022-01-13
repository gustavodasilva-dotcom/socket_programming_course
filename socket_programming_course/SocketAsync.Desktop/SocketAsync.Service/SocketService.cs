using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Net.Sockets;

namespace SocketAsync.Service
{
    public class SocketService
    {
        private TcpListener _tcpListener { get; set; }

        private IPAddress _iPAddress { get; set; }

        public bool KeepRunning { get; set; }

        private int _port { get; set; }

        public async void ListenIncomingConnectionAsync(IPAddress iPAddress = null, int port = 23000)
        {
            if (iPAddress == null)
                iPAddress = IPAddress.Any;

            if (port <= 0)
                port = 23000;

            _iPAddress = iPAddress;
            _port = port;

            Debug.WriteLine(string.Format($"IP Address: {_iPAddress} - Port: {_port}"));

            _tcpListener = new TcpListener(_iPAddress, _port);

            try
            {
                _tcpListener.Start();

                KeepRunning = true;

                while (KeepRunning)
                {
                    var client = await _tcpListener.AcceptTcpClientAsync();

                    Debug.WriteLine(string.Format($"Client accepted and connected successfully: {client}"));

                    HandleTcpClient(client);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format($"An error occurred: {e.Message}"));

                throw;
            }
        }

        private async void HandleTcpClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();

                StreamReader reader = new StreamReader(stream);
                
                var buff = new char[64];

                while (KeepRunning)
                {
                    Debug.WriteLine(string.Format("Ready to read data."));

                    var returnedBytes = await reader.ReadAsync(buff, 0, buff.Length);

                    Debug.WriteLine(string.Format($"Returned bytes: {returnedBytes}."));

                    if (returnedBytes == 0)
                    {
                        Debug.WriteLine(string.Format($"Socket disconnected."));

                        break;
                    }

                    var receivedText = new string(buff);

                    Debug.WriteLine(string.Format($"Received value: {receivedText}"));
                    Debug.WriteLine(string.Format(""));

                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format($"An error occurred: {e.Message}"));
            }
        }
    }
}
