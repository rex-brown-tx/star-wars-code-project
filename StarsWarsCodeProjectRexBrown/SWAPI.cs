
using System.Net;
using System.IO;

namespace StarsWarsCodeProjectRexBrown
{
    public static class SWAPI
    {
        const string baseUri = "https://swapi.co/api/";
        const string agent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

        public static string Starships()
        {
            var client = new WebClient();
            client.Headers.Add("user-agent", agent);
            var data = client.OpenRead(baseUri + "starships");
            var reader = new StreamReader(data);
            var response = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return response;
        }

        public static string Pilot(int id)
        {
            var client = new WebClient();
            client.Headers.Add("user-agent", agent);
            var data = client.OpenRead(baseUri + "people/" + id.ToString());
            var reader = new StreamReader(data);
            var response = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return response;
        }
    }
}
