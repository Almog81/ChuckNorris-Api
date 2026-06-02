using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ChuckNorris_ApiTest
{
	public class WebAction : CommonOps
	{
		public static void WebTest(string url, string value)
		{
			try
			{
				InitDtiver(url);
				String result = GetJokeValue();
				Assert.That(result, Is.EqualTo(value));
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception see ditails: " + ex.Message);
				Assert.Fail("Exception see ditails: " + ex.Message);
			}
			finally
			{
				driver.Quit();
				Console.WriteLine("driver close");
			}

		}
		protected static void InitDtiver(string url)
		{
			Console.WriteLine("Starting Driver");
			new DriverManager().SetUpDriver(new FirefoxConfig());
			driver = new FirefoxDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl(url);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}
		protected static String GetJokeValue()
		{
			return driver.FindElement(By.Id("joke_value")).Text;
		}
	}
}
