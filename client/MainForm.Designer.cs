namespace tsl_echo_client
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnConnect = new System.Windows.Forms.Button();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnSendTestMessage = new System.Windows.Forms.Button();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(12, 12);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(141, 23);
			this.btnConnect.TabIndex = 0;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus});
			this.statusBar.Location = new System.Drawing.Point(0, 235);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(372, 22);
			this.statusBar.TabIndex = 1;
			this.statusBar.Text = "statusStrip1";
			// 
			// labelStatus
			// 
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(138, 17);
			this.labelStatus.Text = "Good morning everyone";
			// 
			// btnSendTestMessage
			// 
			this.btnSendTestMessage.Location = new System.Drawing.Point(12, 41);
			this.btnSendTestMessage.Name = "btnSendTestMessage";
			this.btnSendTestMessage.Size = new System.Drawing.Size(141, 23);
			this.btnSendTestMessage.TabIndex = 2;
			this.btnSendTestMessage.Text = "Send Test Message";
			this.btnSendTestMessage.UseVisualStyleBackColor = true;
			this.btnSendTestMessage.Click += new System.EventHandler(this.btnSendTestMessage_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 257);
			this.Controls.Add(this.btnSendTestMessage);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.btnConnect);
			this.Name = "MainForm";
			this.Text = "TSL echo client";
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripStatusLabel labelStatus;
		private System.Windows.Forms.Button btnSendTestMessage;
	}
}

