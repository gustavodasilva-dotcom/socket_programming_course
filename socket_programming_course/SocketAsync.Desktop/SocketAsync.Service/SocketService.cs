using System;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Net.Sockets;
using System.Collections.Generic;

namespace SocketAsync.Service
{
    public class SocketService
    {
        public List<TcpClient> _clients { get; set; }

        private TcpListener _tcpListener { get; set; }

        private IPAddress _iPAddress { get; set; }

        private bool KeepRunning { get; set; }

        private int _port { get; set; }

        public SocketService()
        {
            _clients = new List<TcpClient>();
        }

        public async void ListenIncomingConnectionAsync(IPAddress iPAddress = null, int port = 23000)
        {
            if (iPAddress == null) iPAddress = IPAddress.Any;

            if (port <= 0) port = 23000;

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

                    _clients.Add(client);

                    Debug.WriteLine(string.Format($"Client accepted and connected successfully: {client}"));
                    Debug.WriteLine(string.Format($"Recent connected client endpoint: {client.Client.RemoteEndPoint}"));
                    Debug.WriteLine(string.Format($"Client's connected count: {_clients.Count}"));

                    HandleTcpClient(client);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format($"An error occurred: {e.Message}"));
            }
        }

        public async void SendToAllAsync(string message)
        {
            try
            {
                if (string.IsNullOrEmpty(message)) return;

                var buff = Encoding.UTF8.GetBytes(message);

                foreach (var client in _clients) client.GetStream().WriteAsync(buff, 0, buff.Length);
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format($"An error occurred: {e.Message}"));
            }
        }

        public void StopListeningToConnections()
        {
            try
            {
                if (_tcpListener != null) _tcpListener.Stop();

                foreach (var client in _clients) client.Close();

                _clients.Clear();
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format($"An error occurred: {e.Message}")); 
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
                        RemoveClient(client);

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
                RemoveClient(client);

                Debug.WriteLine(string.Format($"An error occurred: {e.Message}"));
            }
        }

        private void RemoveClient(TcpClient client)
        {
            try
            {
                if (_clients.Contains(client))
                {
                    _clients.Remove(client);

                    Debug.WriteLine(string.Format($"Removed client: {client.Client.RemoteEndPoint}"));
                    Debug.WriteLine(string.Format($"Client's list count: {_clients.Count}"));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format($"An error occurred: {e.Message}"));
            }
        }
    }
}
