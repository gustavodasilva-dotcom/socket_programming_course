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
                _socketService.ListenIncomingConnectionAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
