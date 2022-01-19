using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SocketAsync.Service
{
    public class SocketClientService
    {
        public EventHandler<LogEventArgs> RaiseLogEvent;

        private IPAddress _ipAddress { get; set; }

        private TcpClient _tcpClient { get; set; }

        private int _port { get; set; }

        public SocketClientService()
        {
            _port = -1;

            _ipAddress = null;

            _tcpClient = null;
        }

        protected virtual void OnRaiseLogEvent(LogEventArgs e)
        {
            try
            {
                EventHandler<LogEventArgs> handler = RaiseLogEvent;

                if (handler != null)
                    handler(this, e);
            }
            catch (Exception) { throw; }
        }

        public async Task ConnectToServerAsync()
        {
            try
            {
                if (_tcpClient == null)
                    _tcpClient = new TcpClient();

                await _tcpClient.ConnectAsync(_ipAddress, _port);

                OnRaiseLogEvent(new LogEventArgs($"Connected to server: {_ipAddress} : {_port}"));

                await ReadDataAsync();
            }
            catch (Exception e)
            {
                OnRaiseLogEvent(new LogEventArgs($"The following error occurred: {e.Message}"));

                throw;
            }
        }

        public async Task ReadDataAsync()
        {
            try
            {
                /*
                 * Associado a um TCP Client e a um socket, sempre está um Network Stream, que pode -- e deve -- ser
                 * utilizado para executar procedimentos de entrada e saída.
                 */
                var streamReader = new StreamReader(_tcpClient.GetStream());

                var buff = new char[64];

                int byteCount;

                while (true)
                {
                    byteCount = await streamReader.ReadAsync(buff, 0, buff.Length);

                    if (byteCount <= 0)
                    {
                        OnRaiseLogEvent(new LogEventArgs("The connection has been broken by the server."));
                        
                        _tcpClient.Close();

                        break;
                    }

                    OnRaiseLogEvent(new LogEventArgs($"Received text from the server: {new string(buff)}"));
                    OnRaiseLogEvent(new LogEventArgs($"Byte count: {byteCount}."));
                    OnRaiseLogEvent(new LogEventArgs($"Received text from {_tcpClient.Client.RemoteEndPoint}: {new string(buff)}"));

                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception e)
            {
                OnRaiseLogEvent(new LogEventArgs($"The following error occurred: {e.Message}"));

                throw;
            }
        }

        public async Task SendToServer(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    OnRaiseLogEvent(new LogEventArgs("Cannot send an empty string."));

                    return;
                }

                if (_tcpClient != null)
                {
                    if (_tcpClient.Connected)
                    {
                        var streamWriter = new StreamWriter(_tcpClient.GetStream());

                        streamWriter.AutoFlush = true;

                        await streamWriter.WriteAsync(input);

                        OnRaiseLogEvent(new LogEventArgs($"Data sent to the server: {input}"));
                    }
                }
            }
            catch (Exception e)
            {
                OnRaiseLogEvent(new LogEventArgs($"The following error occurred: {e.Message}"));

                throw;
            }
        }

        public void CloseAndDisconnect()
        {
            try
            {
                if (_tcpClient != null)
                {
                    if (_tcpClient.Connected)
                    {
                        _tcpClient.Close();
                    }
                }
            }
            catch (Exception) { throw; }
        }

        public IPAddress GetIPAddress()
        {
            try
            {
                return _ipAddress;
            }
            catch (Exception) { throw; }
        }

        public int GetPortNumber()
        {
            try
            {
                return _port;
            }
            catch (Exception) { throw; }
        }

        public bool SetServerIPAddress(string ip)
        {
            try
            {
                if (!IPAddress.TryParse(ip, out IPAddress ipAddress))
                {
                    OnRaiseLogEvent(new LogEventArgs("Invalid server IP supplied."));

                    return false;
                }

                _ipAddress = ipAddress;

                return true;
            }
            catch (Exception) { throw; }
        }

        public bool SetPortNumber(string serverPort)
        {
            try
            {
                if (!int.TryParse(serverPort.Trim(), out int portNumber))
                {
                    OnRaiseLogEvent(new LogEventArgs("Invalid port number supplied."));

                    return false;
                }

                if (portNumber <= 0 || portNumber > 65535)
                {
                    OnRaiseLogEvent(new LogEventArgs("Port number must be between 0 and 65535."));

                    return false;
                }

                _port = portNumber;

                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
