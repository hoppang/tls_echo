using System.Diagnostics;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tsl_echo_client
{
	class TSLClient
	{
		private SslStream _stream;

		private const string HOSTNAME = "127.0.0.1";
		private const int PORT = 9081;

		public delegate void UpdateStatusCallback(string text);
		private UpdateStatusCallback callback;

		class StateObject
		{
			public Socket sock;
			public const int BufferSize = 1024;
			public byte[] buffer = new byte[BufferSize];
			public StringBuilder sb = new StringBuilder();
		}

		public void SetCallback(UpdateStatusCallback newCB)
		{
			callback = newCB;
		}

		private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		public async Task<bool> ConnectAsync()
		{
			var state = new StateObject();
			var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			await Task.Factory.FromAsync(sock.BeginConnect, sock.EndConnect, HOSTNAME, PORT, state);

			var nstream = new NetworkStream(sock);
			_stream = new SslStream(nstream, false,
				new RemoteCertificateValidationCallback(ValidateServerCertificate), null);

			await _stream.AuthenticateAsClientAsync(HOSTNAME);
			if (!_stream.IsAuthenticated)
			{
				Debug.WriteLine("Failed to authenticate");
				return false;
			}

			return true;
		}

		internal async Task<string> ReadAsync()
		{
			var state = new StateObject();
			var bytesRead = await _stream.ReadAsync(state.buffer, 0, StateObject.BufferSize);
			Debug.WriteLine("bytesRead = " + bytesRead);

			if (bytesRead > 0)
			{
				state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
			}
			return state.sb.ToString();
		}

		public async void SendMessage(string msg)
		{
			var buff = Encoding.UTF8.GetBytes(msg);
			await _stream.WriteAsync(buff, 0, buff.Length);
		}
	}
}
