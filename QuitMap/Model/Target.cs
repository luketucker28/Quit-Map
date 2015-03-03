using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitMap.Model
{
    public class Target 
    {   //[Key]  
        public int TargetId { get; set; }
        //[Required]
        public string Date { get; set; }
        //[Required]
        public string Time { get; set; }
        //[Required]
        public string Place { get; set; }
        //[Required]
        public string Antecedant { get; set; }

        public Target()
        {

        }
        public Target(string enterDate, string enterTime, string occurPlace, string anteced) {
            this.Date = enterDate;
            this.Time = enterTime;
            this.Place = occurPlace;
            this.Antecedant = anteced;
        
        }

        public event PropertyChangedEventHandler PropertyChanged;
       
    }
}
