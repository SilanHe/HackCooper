using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WhosOnBreak
{
	public class UserModelJsonUpdate
	{
		[JsonProperty("mon")]
		public List<double> Mon { get; set; }
		[JsonProperty("tue")]
		public List<double> Tue { get; set; }
		[JsonProperty("wed")]
		public List<double> Wed { get; set; }
		[JsonProperty("thu")]
		public List<double> Thu { get; set; }
		[JsonProperty("fri")]
		public List<double> Fri { get; set; }
		[JsonProperty("sat")]
		public List<double> Sat { get; set; }
		[JsonProperty("sund")]
		public List<double> Sund { get; set; }

		public UserModelJsonUpdate()
		{
		}
	}
}