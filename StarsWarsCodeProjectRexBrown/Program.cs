using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

using Newtonsoft.Json;
using StarsWarsCodeProjectRexBrown.models;

namespace StarsWarsCodeProjectRexBrown
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of passengers: ");
            var count = Console.ReadLine();
            int intCount;
            if (!int.TryParse(count, out intCount))
                intCount = 0;

            var result = new starship().GetPilotsByPassengerCount(intCount);
            foreach(var comboString in result)
            {
                Console.WriteLine(comboString);
            }
            Console.Read();
        }

    }
}
