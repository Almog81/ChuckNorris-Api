using CsvHelper;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ChuckNorris_ApiTest
{
    public class Base
    {
        protected RestClient client;
        protected RestRequest request;
        protected RestResponse response;
        
        protected String baseUrl = "https://api.chucknorris.io/";
        protected String jokes = "jokes/";
        protected String categories = "categories";
        protected String category = "?category=";
        protected String random = "random";
        protected String search = "search?query=";



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