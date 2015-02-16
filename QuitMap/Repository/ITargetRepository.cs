using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuitMap.Model;

namespace QuitMap.Repository
{
    interface ITargetRepository
    {
        int GetCount(); //
        void Add(Target E); //
        void Delete(Target E); //
        void Clear(); //
        
        IEnumerable<Target> All(); //
        Target GetById(int id); //
        //Target GetByDate(string date); //
        
    }
}
