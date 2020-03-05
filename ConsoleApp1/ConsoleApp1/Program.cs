using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("https://www.pja.edu.pl"); //pobiera kod strony 

            //await - thread

            if (result.IsSuccessStatusCode) //thread
            {
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                var matches = regex.Matches(html); //poszukiwanie po html doc 
                foreach(var m in matches)
                {
                    Console.WriteLine(m);
                }


            }
            

            Console.WriteLine("Hello World!");
        }
    }
}
