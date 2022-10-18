using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace efcore_issue_cli
{
    internal class Program
    {
        const string api_url = "https://localhost:5001";
        const string endpoint = "/api/test/insert";

        static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri(api_url)
        };

        static async Task Main(string[] args)
        {
            try
            {
                var requests = new List<Task>(2)
                {
                    client.GetAsync(endpoint),
                    client.GetAsync(endpoint),
                };

                await Task.WhenAll(requests);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
