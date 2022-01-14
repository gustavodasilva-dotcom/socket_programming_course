
namespace SocketAsync.Desktop
{
    partial class MainDesktopSocket
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAcceptIncConn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.btnSendToAll = new System.Windows.Forms.Button();
            this.btnStopListeningConn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAcceptIncConn
            // 
            this.btnAcceptIncConn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptIncConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptIncConn.Location = new System.Drawing.Point(211, 37);
            this.btnAcceptIncConn.Name = "btnAcceptIncConn";
            this.btnAcceptIncConn.Size = new System.Drawing.Size(204, 48);
            this.btnAcceptIncConn.TabIndex = 0;
            this.btnAcceptIncConn.Text = "Accept Incoming Connection";
            this.btnAcceptIncConn.UseVisualStyleBackColor = true;
            this.btnAcceptIncConn.Click += new System.EventHandler(this.btnAcceptIncConn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message:";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMessage.Location = new System.Drawing.Point(211, 203);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(184, 20);
            this.textBoxMessage.TabIndex = 2;
            // 
            // btnSendToAll
            // 
            this.btnSendToAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSendToAll.Location = new System.Drawing.Point(416, 195);
            this.btnSendToAll.Name = "btnSendToAll";
            this.btnSendToAll.Size = new System.Drawing.Size(118, 35);
            this.btnSendToAll.TabIndex = 3;
            this.btnSendToAll.Text = "Send to All";
            this.btnSendToAll.UseVisualStyleBackColor = true;
            this.btnSendToAll.Click += new System.EventHandler(this.btnSendToAll_Click);
            // 
            // btnStopListeningConn
            // 
            this.btnStopListeningConn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStopListeningConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopListeningConn.Location = new System.Drawing.Point(225, 116);
            this.btnStopListeningConn.Name = "btnStopListeningConn";
            this.btnStopListeningConn.Size = new System.Drawing.Size(171, 48);
            this.btnStopListeningConn.TabIndex = 4;
            this.btnStopListeningConn.Text = "Stop Listening to Connections";
            this.btnStopListeningConn.UseVisualStyleBackColor = true;
            this.btnStopListeningConn.Click += new System.EventHandler(this.btnStopListeningConn_Click);
            // 
            // MainDesktopSocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 341);
            this.Controls.Add(this.btnStopListeningConn);
            this.Controls.Add(this.btnSendToAll);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAcceptIncConn);
            this.Name = "MainDesktopSocket";
            this.Text = "Main Desktop Socket";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDesktopSocket_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAcceptIncConn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button btnSendToAll;
        private System.Windows.Forms.Button btnStopListeningConn;
    }
}

