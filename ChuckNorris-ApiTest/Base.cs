using CsvHelper;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
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

        public static WebDriver driver;




	}
}