using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Async_Task_part2.Models;

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
