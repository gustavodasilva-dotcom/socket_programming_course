
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
            this.SuspendLayout();
            // 
            // btnAcceptIncConn
            // 
            this.btnAcceptIncConn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptIncConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptIncConn.Location = new System.Drawing.Point(36, 262);
            this.btnAcceptIncConn.Name = "btnAcceptIncConn";
            this.btnAcceptIncConn.Size = new System.Drawing.Size(204, 48);
            this.btnAcceptIncConn.TabIndex = 0;
            this.btnAcceptIncConn.Text = "Accept Incoming Connection";
            this.btnAcceptIncConn.UseVisualStyleBackColor = true;
            this.btnAcceptIncConn.Click += new System.EventHandler(this.btnAcceptIncConn_Click);
            // 
            // MainDesktopSocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 341);
            this.Controls.Add(this.btnAcceptIncConn);
            this.Name = "MainDesktopSocket";
            this.Text = "Main Desktop Socket";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAcceptIncConn;
    }
}

