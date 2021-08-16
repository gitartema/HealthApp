using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Health
{
    static class Serializer
    {
        public static async void Serialize(PersonData person)
        {
            if (person != null)
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                using (FileStream fs = new FileStream($"..\\..\\..\\..\\output\\{person.User}.json", FileMode.OpenOrCreate))
                {
                    await JsonSerializer.SerializeAsync(fs, person, options);
                }
            }
        }
    }
}
