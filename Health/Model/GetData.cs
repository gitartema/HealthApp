using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Health
{
    class GetData
    {
        public AllDaysInfo AllDaysInfo { get; set; } = new AllDaysInfo();

        public GetData()
        {
            GetAllDays();
        }

        private void GetOneDay(int day, ObservableCollection<PersonData> personData)
        {
            var json = System.IO.File.ReadAllText($"..\\..\\..\\..\\input\\day{day}.json");

            var objects = JArray.Parse(json);

            foreach (JObject root in objects)
            {
                Console.WriteLine(root.ToString());
                personData.Add(System.Text.Json.JsonSerializer.Deserialize<PersonData>(root.ToString()));
            }
        }

        private void GetAllDays()
        {
            GetOneDay(1, AllDaysInfo.OneDayInfo);

            for (int i = 1; i < 31; i++)
            {
                GetOneDay(i, AllDaysInfo.AllInfo);
            }
        }
    }
}
