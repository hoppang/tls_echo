using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace tsl_echo_client
{
	public partial class MainForm : Form
	{
		private TSLClient client = new TSLClient();

		public MainForm()
		{
			InitializeComponent();
		}

		private async void btnConnect_Click(object sender, EventArgs e)
		{
			try
			{
				bool result = await client.ConnectAsync();
				if (result)
				{
					labelStatus.Text = "Success";
				}
			}
			catch(SocketException ex)
			{
				labelStatus.Text = "Fail: " + ex.Message;
			}
		}

		private string MakeTestJsonString()
		{
			JsonCmd cmd = new JsonCmd();
			cmd.Code = ECommandCode.ReqEcho;
			cmd.StrArgs.Add("hello");
			cmd.StrArgs.Add("world");

			string json = JsonConvert.SerializeObject(cmd, Formatting.None);
			return json;
		}

		private async void btnSendTestMessage_Click(object sender, EventArgs e)
		{
			var message = MakeTestJsonString();
			client.SendMessage(message);

			string echo = await client.ReadAsync();
			labelStatus.Text = echo;
		}
	}
}
