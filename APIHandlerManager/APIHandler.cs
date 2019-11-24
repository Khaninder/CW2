using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using CW2.Models;
using Newtonsoft.Json;

namespace CW2.APIHandlerManager
{
    public class APIHandler
    {// Obtaining the API key is easy. The same key should be usable across the entire
     // data.gov developer network, i.e. all data sources on data.gov.
     // https://www.nps.gov/subjects/developer/get-started.htm

        static string BASE_URL = "https://api.nytimes.com/svc/books/v3/";
        static string API_KEY = "ywqLjGd3TQkfHri1fhkie9BBWJOz91de"; //Add your API key here inside ""

        HttpClient httpClient;

        /// <summary>
        ///  Constructor to initialize the connection to the data source
        /// </summary>
        public APIHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Method to receive data from API end point as a collection of objects
        /// 
        /// JsonConvert parses the JSON string into classes
        /// </summary>
        /// <returns></returns>
        public Rootobject GetBooks(string category)
        {
            //string NATIONAL_PARK_API_PATH = BASE_URL + "lists/current/hardcover-fiction.json";
            string NATIONAL_PARK_API_PATH = "https://api.nytimes.com/svc/books/v3/lists/current/"+category+".json?api-key=ywqLjGd3TQkfHri1fhkie9BBWJOz91de";
            string booksData = "";

            Rootobject books = null;

            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    booksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!booksData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    books = JsonConvert.DeserializeObject<Rootobject>(booksData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return books;
        }

        public Book_Category GetBooksCategory()
        {
            //string NATIONAL_PARK_API_PATH = BASE_URL + "lists/current/hardcover-fiction.json";
            string NATIONAL_PARK_API_PATH = "https://api.nytimes.com/svc/books/v3/lists/names.json?api-key=ywqLjGd3TQkfHri1fhkie9BBWJOz91de";
            string booksData = "";

            Book_Category booksCategory = null;

            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    booksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!booksData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    booksCategory = JsonConvert.DeserializeObject<Book_Category>(booksData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return booksCategory;
        }
    }
}
