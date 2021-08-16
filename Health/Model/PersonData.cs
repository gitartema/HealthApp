using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Health
{
    class PersonData : INotifyPropertyChanged
    {
        private int rank;
        private string user;
        private string status;
        private int steps;
        private float averageSteps;
        private int bestResult;
        private int worstResult;

        [JsonIgnore]
        public string Color { get; set; }

        public int Rank
        {
            get { return rank; }
            set
            {
                rank = value;
                OnPropertyChanged("Rank");
            }
        }

        public string User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public int Steps
        {
            get { return steps; }
            set
            {
                steps = value;
                OnPropertyChanged("Steps");
            }
        }

        public float AverageSteps
        {
            get { return averageSteps; }
            set
            {
                averageSteps = value;
                OnPropertyChanged("AverageSteps");
            }
        }

        public int BestResult
        {
            get { return bestResult; }
            set
            {
                bestResult = value;
                OnPropertyChanged("BestResult");
            }
        }

        public int WorstResult
        {
            get { return worstResult; }
            set
            {
                worstResult = value;
                OnPropertyChanged("WorstResult");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}