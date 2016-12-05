using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    class Context:DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Diary> Diary { get; set; }
        public DbSet<PersonInfo> PersonInfo { get; set; }
        public DbSet<PersonNorm> PersonNorms { get; set; }
        public Context() : base("localsql")
        {
        }
    }
}
