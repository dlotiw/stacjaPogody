using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacjaPogody
{
    internal class Dane
    {
        public static double temp { get; set; }
        public static double hum { get; set; }
        public static double wind { get; set; }
        public static int wind_bufort { get; set; }
        public static string wind_dir { get; set; }
        public static double korekta { get; set; } = 0;

        public static void Losowanko()
        {
            Random rnd = new Random();
            string[] directions = { "N", "NW", "NE", "E", "W", "S", "SE", "SW" };
            
            temp = Math.Round(rnd.NextDouble() * rnd.Next(40, 60),2);
            hum = Math.Round(rnd.NextDouble() * rnd.Next(60, 100), 2);
            wind = Math.Round(rnd.NextDouble() * rnd.Next(10, 102), 2);
            int index = rnd.Next(directions.Count());
            wind_dir = directions[index];
            
        }
    }
}
