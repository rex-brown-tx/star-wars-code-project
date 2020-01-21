using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

using Newtonsoft.Json;
using StarsWarsCodeProjectRexBrown.models;

namespace StarsWarsCodeProjectRexBrown.models
{
    public class starshipContainer
    {
        public List<starship> results { get; set; }
    }

    public class starship
    {
        public string name { get; set; }
        public int passengers { get; set; }
        public List<string> pilots { get; set; }

        public List<string> GetPilotsByPassengerCount(int countRequired)
        {
            var result = new List<string>();

            string baseUri = "https://swapi.co/api/";

            WebClient client = new WebClient();

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead(baseUri + "starships");
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            starshipContainer shipsContainer = JsonConvert.DeserializeObject<starshipContainer>(s);
            foreach (var ship in shipsContainer.results.Where(r => r.pilots.Count > 0 && r.passengers >= countRequired))
            {
                //Console.WriteLine(ship.name);
                //Console.WriteLine(ship.pilots);

                foreach (var pilotUri in ship.pilots)
                {
                    data = client.OpenRead(pilotUri);
                    reader = new StreamReader(data);
                    s = reader.ReadToEnd();
                    data.Close();
                    reader.Close();

                    pilot objPilot = JsonConvert.DeserializeObject<pilot>(s);
                    result.Add($"{ship.name} - {objPilot.name}");
                }
            }

            return result;
        }
    }

    public class pilotContainer
    {
        public List<pilot> results { get; set; }
    }

    public class pilot
    {
        public string name { get; set; }
        public string starshipName { get; set; }

    }

}
