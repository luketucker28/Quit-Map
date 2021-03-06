﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace QuitMap.Model
{

    public class DataEntry : INotifyPropertyChanged
    {
        public int DataEntryId { get; set; }
       // [Required]
        public string Date { get; set; }
       // [Required]
        public int NumberSmoked { get; set; }
       // [Required]
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
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
    }


