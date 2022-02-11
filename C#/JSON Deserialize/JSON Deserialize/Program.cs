using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace JSON_Deserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"..\..\class.json");
            Console.WriteLine(json);

            // builds a full JSON DOM
            // DOM = Document Object Model
            JObject root = JObject.Parse(json);

            string klasse = root["name"].Value<string>();
            Console.WriteLine(klasse);           

            int studentsCount = root["studentsCount"].Value<int>();
            Console.WriteLine(studentsCount);

            string firstName = (string)root.SelectToken("headOfClass.firstName");
            Console.WriteLine(firstName);


            JArray subjects = root["headOfClass"]["subjects"].Value<JArray>();
            foreach(var subject in subjects)
            {
                JObject sub = subject.Value<JObject>();
                Console.WriteLine(sub["name"].ToString());
            }

            Console.ReadKey();
        }
    }
}