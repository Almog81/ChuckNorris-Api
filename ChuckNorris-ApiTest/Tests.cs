using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Text.Json.Nodes;


namespace ChuckNorris_ApiTest;

[TestFixture]
public class Tests : Base
{
      
    [OneTimeSetUp]
    public void Setup()
    {
        client = new RestClient(baseUrl);
    }

    [Test]
    public void Test01_Categories()
    {
		JArray categoriesList =	getCategoriesEndpoint();
		Console.WriteLine("Categories joks is: ");
		for (int i = 0; i < categoriesList.Count; i++)
		{
			Console.WriteLine(categoriesList[i].ToString());
		}
	}

    [Test]
    public void Test02_BarakPrCharlie() 
    {
		int barakTotal = (int)GetSearch("Barack Obama")["total"];
        int charlieTotal = (int)GetSearch("Charlie Sheen")["total"];
        if (barakTotal > charlieTotal) 
            Console.WriteLine("Barack Obama has more Jokes!: "+ barakTotal);
        else if (barakTotal < charlieTotal)
            Console.WriteLine("Charlie Sheen has more Jokes!: " + charlieTotal);
        else
            Console.WriteLine("Thy both have the same amount of jokes: " + barakTotal);
	}
    [Test]
    public void Test03_RandomJokes()
    {
        List<JokeEntry> randomJokes = new List<JokeEntry>();
        String url, value;

		for (int i = 0; i <= 10; i++)
        {
			JObject randomJoke = GetRandomJoke();
			randomJokes.Add(new JokeEntry
			{
				Url = (string)randomJoke["url"],
				Value = (string)randomJoke["value"]
			});
		}
		string path = "random_jokes.csv";
		SaveJokesToCsv(randomJokes, path);
	}

    [Test]
    public void Test04_RandomJokes()
    {
		JObject randomMovieJoke = GetRandomJoke("movie");
		JokeEntry movieJoke = new JokeEntry
		{
			Categories = (JArray)randomMovieJoke["categories"],
			Url = (string)randomMovieJoke["url"],
			Value = (string)randomMovieJoke["value"]
		};
        Assert.That(movieJoke.Categories.ToString().Contains("movie"), Is.True);
		Console.WriteLine(movieJoke.Url);
        Console.WriteLine(movieJoke.Value);
	}

    [OneTimeTearDown]
    public void TearDown(){
        client.Dispose();
    }
    

}
