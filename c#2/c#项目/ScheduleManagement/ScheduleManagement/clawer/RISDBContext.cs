using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.clawer
{
    class RISDBContext
    {
        public DbSet<Zc> News { get; set; }
        void SaveChanges() { }
    }
}
