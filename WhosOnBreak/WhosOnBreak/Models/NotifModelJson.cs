using System;
using Newtonsoft.Json;
namespace WhosOnBreak
{
	public class NotifModelJson
	{
		[JsonProperty("_id")]
		public string Id { get; set; }
		[JsonProperty("time")]
		public double Time { get; set; }
		[JsonProperty("notifBy")]
		public string NotifBy { get; set; }
		[JsonProperty("notifTo")]
		public double NotifTo { get; set; }

		public NotifModelJson()
		{
		}
	}
}
