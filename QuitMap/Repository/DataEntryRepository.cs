using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuitMap.Model;
using QuitMap;
using System.Data.Entity;

namespace QuitMap.Repository
{
    public class DataEntryRepository : IDataEntryRepository
    {
        private QuitMapContext _dbContext;

        public DataEntryRepository() 
        {
            _dbContext = new QuitMapContext();
            _dbContext.DataEntries.Load();
        }
        public QuitMapContext Context()
        {
            return _dbContext;
        }
        public DbSet<DataEntry> GetDbSet()
        {
            return _dbContext.DataEntries;
        }
       
        public int GetCount()
        {
            return _dbContext.DataEntries.Count<DataEntry>();
        }

        public void Add(DataEntry E)
        {
            _dbContext.DataEntries.Add(E);
            _dbContext.SaveChanges();
        }

        
        public void Delete(DataEntry E)
        {
            _dbContext.DataEntries.Remove(E);
            _dbContext.SaveChanges();
        }
        

        public void Clear()
        {
            var a = this.All();
            _dbContext.DataEntries.RemoveRange(a);
            _dbContext.SaveChanges();
        }

        
        public IEnumerable<DataEntry> All()
        {
            var qu = from DataEntry in _dbContext.DataEntries select DataEntry;
            return qu.ToList<DataEntry>();
        }

        public DataEntry GetById(int id)
        {
            var query = from DataEntry in _dbContext.DataEntries
                        where DataEntry.DataEntryId == id
                        select DataEntry;
            return query.First<DataEntry>();
        }
        public DataEntry FirstEntry() {

            var query = from DataEntry in _dbContext.DataEntries select DataEntry;
            return query.ToList<DataEntry>().ElementAt<DataEntry>(0);
                    
        }

        public DataEntry GetByDate(string date)
        {
            throw new NotImplementedException();
        }
        public void Dispose() {
           _dbContext.Dispose();
        }

        }
    }

