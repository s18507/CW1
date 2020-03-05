using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleApp1
{
    public class Student
    {
        private string nazwisko;

        //get set w javie nie uzywamy a robime tak:

        //Wlasciwosci
        //prop + tab tab
        public string MyProperty { get; set; }

        //propful + tab tab 
        private string imie;

        public string Imie
        {
            get { return imie; }
            set {
                if (value == null) throw new ArgumentException();
                imie = value;
            }
        }

    }
    class Program
    {
        public static async Task Main(string[] args)
        {

            // var st = new Student();
            // st.MyProperty = "Kowalski";

            try
            {
                var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
                if (args.Length == 0) return;


                var client = new HttpClient();
                var result = await client.GetAsync("https://www.pja.edu.pl"); //pobiera kod strony 

                //await - thread

                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Serwer error");
                    return;
                }


                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                var matches = regex.Matches(html);//poszukiwanie po html doc
                var set = new HashSet<string>();

                //LINQ(dla sql, dla exel)
                var list = new List<string>();
                var elementy = from e in list
                               where e.StartsWith("A")
                               select e;

                var elementy2 = list.Where(s => s.StartsWith("A"));



                var slownik = new Dictionary<string, string>();



                foreach (var m in matches)
                {
                    Console.WriteLine(m);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Wystapil blad {ex.ToString()}"); //interpolacja stringa
            }

            Console.WriteLine("Hello World!");
        }
    }
}
