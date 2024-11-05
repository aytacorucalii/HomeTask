using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;

namespace AsyncTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            Stopwatch sw = Stopwatch.StartNew();
            List<string> urls = new List<string>()
                {
                    "https://kontakt.az/telefoniya",
                    "https://www.soliton.az/search.php?q=telefon",
                    "https://irshad.az/mehsullar?q=telefon",
                    "https://irshad.az/mehsullar?q=telefon"

                };
            RetrieveDataNonAsync(urls);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("--------------------------------------------------------------");
            RetrieveDataAsync(urls).Wait();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        public static void RetrieveDataNonAsync(List<string> urls)
        {
            HttpClient client = new HttpClient();
            foreach (var url in urls)
            {

                Console.WriteLine(client.GetStringAsync(url).Result.ToString());
            }

        }
        public static async Task RetrieveDataAsync(List<string> urls)
        {
            HttpClient client = new HttpClient();
            List<Task<string>> links = new List<Task<string>>();
            foreach (var url in urls)
            {
                links.Add(client.GetStringAsync(url));
                await Task.WhenAll(links);
            }
            #endregion
            string path = "C:\\Users\\Hp\\OneDrive\\Desktop\\aytacorucaliyeva\\AsyncTask.sln";
            Directory.CreateDirectory(path + "\\Models");
        }
    }
}
