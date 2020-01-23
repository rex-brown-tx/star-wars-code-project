using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace StarsWarsCodeProjectRexBrown.models
{
    public class StarWars
    {
        public List<string> GetStarshipsWithPilots(int minPassengers)
        {
            var result = new List<string>();
            var ships = SWAPI.Starships();
            var shipsContainer = JsonConvert.DeserializeObject<ResultsContainer<Starship>>(ships);
            foreach (var ship in shipsContainer.results.Where(r => r.pilots.Count > 0 && r.passengers >= minPassengers))
            {
                foreach (var pilotUri in ship.pilots)
                {
                    var parts = pilotUri.Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                    int id;
                    int.TryParse(parts[parts.Length - 1], out id);
                    var pilot = SWAPI.Pilot(id);
                    Pilot objPilot = JsonConvert.DeserializeObject<Pilot>(pilot);
                    result.Add($"{ship.name} - {objPilot.name}");
                }
            }

            return result;
        }
    }

}
