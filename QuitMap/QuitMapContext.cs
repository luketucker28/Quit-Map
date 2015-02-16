using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using QuitMap.Model;

namespace QuitMap
{
    public class QuitMapContext : DbContext
    {
        public DbSet<Target> Targets { get; set; }
        public DbSet<DataEntry> DataEntries { get; set; }
    }
}
