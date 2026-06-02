using CsvHelper;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;



namespace ChuckNorris_ApiTest
{
	public class CommonOps : Base
	{

		protected JArray getCategoriesEndpoint()
		{
			request = new RestRequest(jokes + categories, Method.Get);
			response = client.Execute(request);

			return JArray.Parse(response.Content);

		}

		protected JObject GetSearch(String wordToSearch)
		{
			Console.WriteLine(baseUrl + jokes + search + wordToSearch);
			request = new RestRequest(jokes + search + wordToSearch, Method.Get);
			response = client.Execute(request);
			return JObject.Parse(response.Content);
		}
		protected JObject GetRandomJoke()
		{
			request = new RestRequest(jokes + random, Method.Get);
			response = client.Execute(request);
			return JObject.Parse(response.Content);
		}
		protected JObject GetRandomJoke(String inCategory)
		{
			request = new RestRequest(jokes + random + category + inCategory, Method.Get);
			response = client.Execute(request);
			return JObject.Parse(response.Content);
		}

		protected void SaveJokesToCsv(List<JokeEntry> jokes, string filePath)
		{
			using (var writer = new StreamWriter(filePath))
			using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
			{
				csv.WriteRecords(jokes);
			}
		}

		
	}
}
