﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuitMap;
using QuitMap.Model;
using System.Data.Entity;

namespace QuitMap.Repository
{
   public class TargetRepository : ITargetRepository
    {
        private QuitMapContext _dbContext;

        public TargetRepository()
        {
            _dbContext = new QuitMapContext();
            _dbContext.Targets.Load();
        }
        public QuitMapContext Context()
        {
            return _dbContext;
        }
        public DbSet<Target> GetDbSet()
        {
            return _dbContext.Targets;
        }
       
        public int GetCount()
        {
            return _dbContext.Targets.Count<Target>();
        }

        public void Add(Target E)
        {
            _dbContext.Targets.Add(E);
            _dbContext.SaveChanges();
        }

        public void Delete(Target E)
        {
            _dbContext.Targets.Remove(E);
            _dbContext.SaveChanges();
        }

        public void Clear()
        {
            var a = this.All();
            _dbContext.Targets.RemoveRange(a);
            _dbContext.SaveChanges();
        }
      
     

        public IEnumerable<Target> All()
        {
            var qu = from Target in _dbContext.Targets select Target;
            return qu.ToList<Target>();
        }

        public Target GetById(int id)
        {
            throw new NotImplementedException();
            //var query = from Target in _dbContext.Targets
            //            where Target.TargetId == id
            //            select Target;
            //return query.First<Target>();
        }

        public List<Target> GetByDate(string d)
        {
            var a = from Target in _dbContext.Targets
                     where Target.Date == d
                     select Target;
            return a.ToList<Target>();
            
        }
        public  IEnumerable<Target> OrderByDate()
        {
            var query = (from Target in _dbContext.Targets
                         orderby Target.Date select Target).ToList();
            _dbContext.SaveChanges();
            return query;
        }
        public IEnumerable<Target> OrderById()
        {
            var query = (from Target in _dbContext.Targets
                         orderby Target.TargetId
                         select Target).ToList();
            _dbContext.SaveChanges();
            return query;
        }  
        public Target FirstEntry()
        {

            var query = from Target in _dbContext.Targets select Target;
            return query.ToList<Target>().ElementAt<Target>(0);

        }
        public Target FindEntry(int i)
        {

            var query = from Target in _dbContext.Targets select Target;
            return query.ToList<Target>().ElementAt<Target>(i);

        }
        public void Dispose()
        {
            _dbContext.Dispose();

        }
    }
}
