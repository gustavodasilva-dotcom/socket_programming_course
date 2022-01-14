using System;
using System.Windows.Forms;
using SocketAsync.Service;

namespace SocketAsync.Desktop
{
    public partial class MainDesktopSocket : Form
    {
        private readonly SocketService _socketService;

        public MainDesktopSocket()
        {
            InitializeComponent();

            _socketService = new SocketService();
        }

        private void btnAcceptIncConn_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Listening for incoming connections.");

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

                MessageBox.Show($"Data sent: {textBoxMessage.Text.Trim()}");

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

                MessageBox.Show("TCP listener stoped.");
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

                MessageBox.Show("TCP listener stoped.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
