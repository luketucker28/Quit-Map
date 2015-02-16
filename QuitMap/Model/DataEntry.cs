using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace QuitMap.Model
{

    public class DataEntry
    {
        public int DataEntryId { get; set; }
        public string Date { get; set; }
        public int NumberSmoked { get; set; }
        public int SmokeReduction { get; set; }


        public DataEntry()
        {

        }
        public DataEntry(string newDate, int smoked, int reduction)
        {

            this.Date = newDate;
            this.NumberSmoked = smoked;
            this.SmokeReduction = reduction;
        }
      
    }
    }


