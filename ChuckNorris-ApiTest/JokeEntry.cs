using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChuckNorris_ApiTest
{
	public class JokeEntry
	{
		public JArray Categories { get; set; }
		public string Created_at { get; set; }
		public string Id { get; set; }
		public string Updated_at { get; set; }

		public string Url { get; set; }
		public string Value { get; set; }
		
		
	}
}
