using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JSON_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fächer = new List<string>
            {
                "Deutsch:D",
                "Geschichte, Geografie, Politische Bildung:GGP",
                "Soziale Bildung:SOPK"
            };

            // subjects
            JArray subjects = new JArray();

            foreach (string fach in fächer)
            {
                var parts = fach.Split(':');
                JObject subject = new JObject();
                subject["name"] = parts[0];
                subject["acronym"] = parts[1];
                subjects.Add(subject);
            }

            // Build a JSON tree
            JObject root = new JObject();
            root["name"] = "3AHIF";
            root["studentsCount"] = 20;
            root["room"] = "D102";
            root["higherEducation"] = true;

            // headOfClass
            JObject headOfClass = new JObject();
            headOfClass["firstName"] = "Sarah";
            headOfClass["lastName"] = "Reissig";

            // subjects
            //JObject subject1 = new JObject();
            //subject1["name"] = "Deutsch";
            //subject1["acronym"] = "D";
            //subjects.Add(subject1);

            //JObject subject2 = new JObject();
            //subject2["name"] = "Geschichte, Geografie, Politische Bildung";
            //subject2["acronym"] = "GGP";
            //subjects.Add(subject2);

            headOfClass["subjects"] = subjects;
            root["headOfClass"] = headOfClass;

            // Serialisation to JSON

            string json = root.ToString();
            Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}
