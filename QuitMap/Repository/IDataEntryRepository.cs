using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuitMap.Model;

namespace QuitMap.Repository
{
    interface IDataEntryRepository
    {

        int GetCount(); //
        void Add(DataEntry E); //
        void Delete(DataEntry E); //
        void Clear(); 
        IEnumerable<DataEntry> All(); 
        DataEntry GetById(int id); 
        
    }
}
