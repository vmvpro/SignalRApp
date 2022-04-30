namespace SignalRWinFormsClient
{
    partial class ChatForm
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
			this.connectButton = new System.Windows.Forms.Button();
			this.lblUserName = new System.Windows.Forms.Label();
			this.messagesList = new System.Windows.Forms.ListBox();
			this.sendButton = new System.Windows.Forms.Button();
			this.messageTextBox = new System.Windows.Forms.TextBox();
			this.disconnectButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtConnId = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// connectButton
			// 
			this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.connectButton.Location = new System.Drawing.Point(408, 9);
			this.connectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(88, 27);
			this.connectButton.TabIndex = 1;
			this.connectButton.Text = "Connect";
			this.connectButton.UseVisualStyleBackColor = true;
			this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Location = new System.Drawing.Point(14, 15);
			this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(65, 15);
			this.lblUserName.TabIndex = 2;
			this.lblUserName.Text = "UserName:";
			// 
			// messagesList
			// 
			this.messagesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messagesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.messagesList.FormattingEnabled = true;
			this.messagesList.Location = new System.Drawing.Point(13, 112);
			this.messagesList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.messagesList.Name = "messagesList";
			this.messagesList.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.messagesList.Size = new System.Drawing.Size(572, 303);
			this.messagesList.TabIndex = 3;
			this.messagesList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.messagesList_DrawItem);
			// 
			// sendButton
			// 
			this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sendButton.Enabled = false;
			this.sendButton.Location = new System.Drawing.Point(497, 79);
			this.sendButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.sendButton.Name = "sendButton";
			this.sendButton.Size = new System.Drawing.Size(88, 27);
			this.sendButton.TabIndex = 5;
			this.sendButton.Text = "Send";
			this.sendButton.UseVisualStyleBackColor = true;
			this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
			// 
			// messageTextBox
			// 
			this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messageTextBox.Enabled = false;
			this.messageTextBox.Location = new System.Drawing.Point(13, 81);
			this.messageTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.messageTextBox.Name = "messageTextBox";
			this.messageTextBox.Size = new System.Drawing.Size(477, 23);
			this.messageTextBox.TabIndex = 4;
			this.messageTextBox.Enter += new System.EventHandler(this.messageTextBox_Enter);
			// 
			// disconnectButton
			// 
			this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.disconnectButton.Enabled = false;
			this.disconnectButton.Location = new System.Drawing.Point(502, 9);
			this.disconnectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.disconnectButton.Name = "disconnectButton";
			this.disconnectButton.Size = new System.Drawing.Size(88, 27);
			this.disconnectButton.TabIndex = 6;
			this.disconnectButton.Text = "Disconnect";
			this.disconnectButton.UseVisualStyleBackColor = true;
			this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "ConnId:";
			// 
			// txtConnId
			// 
			this.txtConnId.Location = new System.Drawing.Point(86, 49);
			this.txtConnId.Name = "txtConnId";
			this.txtConnId.Size = new System.Drawing.Size(297, 23);
			this.txtConnId.TabIndex = 8;
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(86, 12);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(297, 23);
			this.txtUserName.TabIndex = 9;
			// 
			// ChatForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 437);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.txtConnId);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.disconnectButton);
			this.Controls.Add(this.sendButton);
			this.Controls.Add(this.messageTextBox);
			this.Controls.Add(this.messagesList);
			this.Controls.Add(this.lblUserName);
			this.Controls.Add(this.connectButton);
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "ChatForm";
			this.Text = "SignalR Chat Sample";
			this.Load += new System.EventHandler(this.ChatForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ListBox messagesList;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button disconnectButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtConnId;
		private System.Windows.Forms.TextBox txtUserName;
	}
}

