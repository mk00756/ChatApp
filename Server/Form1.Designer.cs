namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IPTxt = new System.Windows.Forms.TextBox();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.HostBtn = new System.Windows.Forms.Button();
            this.ChatTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IPTxt
            // 
            this.IPTxt.Location = new System.Drawing.Point(12, 200);
            this.IPTxt.Name = "IPTxt";
            this.IPTxt.Size = new System.Drawing.Size(100, 20);
            this.IPTxt.TabIndex = 0;
            this.IPTxt.Text = "127.0.0.1";
            // 
            // PortTxt
            // 
            this.PortTxt.Location = new System.Drawing.Point(118, 200);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.Size = new System.Drawing.Size(100, 20);
            this.PortTxt.TabIndex = 1;
            this.PortTxt.Text = "25000";
            // 
            // HostBtn
            // 
            this.HostBtn.Location = new System.Drawing.Point(12, 226);
            this.HostBtn.Name = "HostBtn";
            this.HostBtn.Size = new System.Drawing.Size(75, 23);
            this.HostBtn.TabIndex = 2;
            this.HostBtn.Text = "Host";
            this.HostBtn.UseVisualStyleBackColor = true;
            this.HostBtn.Click += new System.EventHandler(this.HostBtn_Click);
            // 
            // ChatTxt
            // 
            this.ChatTxt.Enabled = false;
            this.ChatTxt.Location = new System.Drawing.Point(12, 12);
            this.ChatTxt.Multiline = true;
            this.ChatTxt.Name = "ChatTxt";
            this.ChatTxt.Size = new System.Drawing.Size(260, 182);
            this.ChatTxt.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ChatTxt);
            this.Controls.Add(this.HostBtn);
            this.Controls.Add(this.PortTxt);
            this.Controls.Add(this.IPTxt);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPTxt;
        private System.Windows.Forms.TextBox PortTxt;
        private System.Windows.Forms.Button HostBtn;
        private System.Windows.Forms.TextBox ChatTxt;
    }
}

