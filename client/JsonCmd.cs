using System.Collections.Generic;

namespace tsl_echo_client
{
	public enum ECommandCode
	{
		Empty = 0,
		ReqEcho,
		ResEcho,
	}

	public class JsonCmd
	{
		public JsonCmd()
		{
			StrArgs = new List<string>();
		}

		public ECommandCode Code;
		public List<string> StrArgs;
	}
}
