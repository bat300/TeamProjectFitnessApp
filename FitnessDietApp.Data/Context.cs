using System.Data.Entity;

namespace FitnessDietApp.Data
{
    public class Context: DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Diary> Diary { get; set; }
        public DbSet<DiaryItem> DiaryItems { get; set; }
        public DbSet<PersonInfo> PersonInfo { get; set; }
        public DbSet<PersonNorm> PersonNorms { get; set; }

        public Context() : base("localsql")
        {

        }
    }
}
