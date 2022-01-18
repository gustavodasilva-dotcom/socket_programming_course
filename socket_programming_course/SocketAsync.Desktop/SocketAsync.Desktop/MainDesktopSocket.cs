using System;
using System.Windows.Forms;
using SocketAsync.Service;

namespace SocketAsync.Desktop
{
    public partial class MainDesktopSocket : Form
    {
        private readonly SocketServeService _socketService;

        public MainDesktopSocket()
        {
            InitializeComponent();

            _socketService = new SocketServeService();

            _socketService.RaiseLogEvent += HandlerLog;
        }

        private void btnAcceptIncConn_Click(object sender, EventArgs e)
        {
            try
            {
                _socketService.ListenIncomingConnectionAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnSendToAll_Click(object sender, EventArgs e)
        {
            try
            {
                _socketService.SendToAllAsync(textBoxMessage.Text.Trim());

                textBoxMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnStopListeningConn_Click(object sender, EventArgs e)
        {
            try
            {
                _socketService.StopListeningToConnections();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void MainDesktopSocket_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _socketService.StopListeningToConnections();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        void HandlerLog(object sender, LogEventArgs e)
        {
            try
            {
                textBoxConsole.AppendText(string.Format($"{DateTime.Now} - {e.Log}"));
                textBoxConsole.AppendText(Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
