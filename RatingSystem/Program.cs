using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ReviewSystem
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var path = System.IO.Directory.GetCurrentDirectory() + "\\HotelReview.json";

            using (StreamReader sr = new StreamReader(path.ToString()))
            {
                var json = JObject.Parse(sr.ReadToEnd());
                var data = json["Data"];

                List<Review> list = JsonConvert.DeserializeObject<List<Review>>(data["Reviews"].ToString());

                list.Where(x => x.Value == 5)
                    .Select(x => { x.Value = 8; return x; })
                    .ToList();

                list.Where(y => y.Value == 4)
                   .Select(y => { y.Value = 6; return y; })
                   .ToList();

                list.Where(z => z.Value == 2)
                   .Select(z => { z.Value = -6; return z; })
                   .ToList();

                list.Where(r => r.Value == 1)
                   .Select(r => { r.Value = -8; return r; })
                   .ToList();

                var test = list.GroupBy(c => c.Label)
                     .Select(c => new
                     {
                         Value = c.Sum(y => y.Value),
                         Label = c.Key,
                         Hotel = data["Hotel"]

                     })
                     .ToList();

                foreach (var r in test)
                {
                    Console.WriteLine(r.Value >= 0 ? r.Hotel + " is suggested for " + r.Label : r.Hotel + " is not Suggested for " + r.Label);

                }
            }

            Console.ReadKey();
        }
    }
}

