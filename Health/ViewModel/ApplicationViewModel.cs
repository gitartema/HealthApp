using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Health
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private PersonData selectedPerson;

        private readonly GetData data;

        public ObservableCollection<PersonData> People { get; set; } = new ObservableCollection<PersonData>();

        public ObservableCollection<DataPoint> Points { get; private set; } = new ObservableCollection<DataPoint>();

        private ICommand exportToJson;

        public PersonData SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        public ICommand ExportToJson
        {
            get
            {
                return exportToJson ??
                (exportToJson = new RelayCommand(obj =>
                {
                    Serializer.Serialize(SelectedPerson);
                }));
            }
        }

        public ApplicationViewModel()
        {
            Person currentPerson;

            data = new GetData();

            People = data.AllDaysInfo.OneDayInfo;

            foreach (PersonData person in People)
            {
                currentPerson = new Person(person.User, data.AllDaysInfo);
                person.AverageSteps = currentPerson.GetAvarageSteps();
                person.BestResult = currentPerson.GetMaxSteps();
                person.WorstResult = currentPerson.GetMinSteps();
                person.Color = currentPerson.GetDifferent(person);
            }
        }

        public ObservableCollection<int> ListOfStepsByDay()
        {
            ObservableCollection<int> steps = new ObservableCollection<int>();
            foreach (PersonData person in data.AllDaysInfo.AllInfo)
            {
                if (SelectedPerson.User == person.User)
                {
                    steps.Add(person.Steps);
                }
            }

            return steps;
        }

        public void Diagram()
        {
            if (SelectedPerson != null)
            {
                ObservableCollection<int> steps = ListOfStepsByDay();
                Points.Clear();

                for (int i = 0; i < 30; i++)
                {
                    Points.Add(new DataPoint(i + 1, steps[i]));

                    if (SelectedPerson.User == "Разпустов Николай" && i > 27) // Только на нём выбрасывает исключение о переполнении (похоже Разпустовых всего 29)
                        break;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                Diagram();
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }  
    }
}