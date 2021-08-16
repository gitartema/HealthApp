using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health
{
    class AllDaysInfo
    {
        public ObservableCollection<PersonData> OneDayInfo { get; set; } = new ObservableCollection<PersonData>();
        public ObservableCollection<PersonData> AllInfo { get; set; } = new ObservableCollection<PersonData>();
    }
}
