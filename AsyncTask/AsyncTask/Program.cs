#region

using Newtonsoft.Json;
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
        }
    }
}
#endregion

#region
namespace Async_Task_part2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = "C:\\Users\\Hp\\source\\repos\\Async Task part2\\Async Task part2";

            Directory.CreateDirectory(path + "\\Models");
            if (!File.Exists(path + "\\Models"))
            {
                File.Create(path + "\\Models");
            }

            Directory.CreateDirectory(path + "\\Data");
            string DirPath = (path + "\\Data");
            if (!File.Exists(DirPath + "\\jsonData.json"))
            {
                File.Create(DirPath + "\\jsonData.json");
            }

            List<string> urls = new List<string>
            {
                "https://jsonplaceholder.typicode.com/posts"
            };

            RetrieveData(urls, DirPath + "\\jsonData.json");
        }

        public static void RetrieveData(List<string> urls, string filePath)
        {
            HttpClient client = new HttpClient();

            foreach (string url in urls)
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();

                    string jsonData = response.Content.ReadAsStringAsync().Result;
                    var dataObject = JsonConvert.DeserializeObject(jsonData);


                    string serializedData = JsonConvert.SerializeObject(dataObject, Formatting.Indented);

                    using (StreamWriter sw = new StreamWriter(filePath, true))
                    {
                        sw.WriteLine(serializedData);
                    }

                    Console.WriteLine("Məlumat uğurla fayla yazıldı");
                }
                catch (Exception)
                {
                    Console.WriteLine("Məlumat əldə edilərkən səhv baş verdi ");
                }
            }
        }
    }
}

#endregion