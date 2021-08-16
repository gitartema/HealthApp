using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health
{
    class Person
    {
        public ObservableCollection<PersonData> personData = new ObservableCollection<PersonData>();

        public Person(string user, AllDaysInfo allDaysInfo)
        {
            GetPerson(user, allDaysInfo);
        }

        private void GetPerson(string user, AllDaysInfo allDaysInfo)
        {
            foreach (PersonData person in allDaysInfo.AllInfo)
            {
                if (user == person.User)
                {
                    personData.Add(person);
                }
            }
        }

        public float GetAvarageSteps()
        {
            int sum = 0;
            foreach (PersonData person in personData)
            {
                sum += person.Steps;
            }
            return (float)sum / 30;
        }

        public int GetMaxSteps()
        {
            int max = personData[0].Steps;
            foreach (PersonData person in personData)
            {
                if (person.Steps > max)
                {
                    max = person.Steps;
                }
            }
            return max;
        }

        public int GetMinSteps()
        {
            int min = personData[0].Steps;
            foreach (PersonData person in personData)
            {
                if (person.Steps < min)
                {
                    min = person.Steps;
                }
            }
            return min;
        }

        public string GetDifferent(PersonData person)
        {
            if (Diff(person.BestResult, person.AverageSteps) > 0.2)
                return "Red";

            if (Diff(person.AverageSteps, person.WorstResult) > 0.2)
                return "Red";

            return "Black";
        }

        private float Diff(float a, float b) => (a - b) / b;
    }
}
