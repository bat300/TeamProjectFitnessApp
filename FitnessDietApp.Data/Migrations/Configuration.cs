namespace FitnessDietApp.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FitnessDietApp.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "FitnessDietApp.Data.Context";
        }

        protected override void Seed(Context context)
        {
            //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "ALTER DATABASE " + context.Database.Connection.Database + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "ALTER DATABASE " + context.Database.Connection.Database + " SET MULTI_USER");

            //context.Database.Delete();
            //context.Database.Create();

            Dictionary<string, Products> products = new Dictionary<string, Products>();

            using (var reader = new StreamReader("productsInfo.csv"))
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(';');
                    if (values.Length == 5)
                    {
                        if (!products.Keys.Contains(values[0]))
                            products[values[0]] = new Products()
                            {
                                Name = values[0],
                                Proteins = double.Parse(values[2]),
                                Fat = double.Parse(values[3]),
                                Carbohydrates = double.Parse(values[4]),
                                Ñalories = double.Parse(values[1])
                            };
                    }
                }
                context.Products.AddRange(products.Values);

                context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}
