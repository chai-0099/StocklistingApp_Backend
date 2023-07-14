using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Stocklisting.Model
{
    public class ApplicationDBContext : DbContext
    {
        //add the the constructor to the class ApplicationDBContext
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            //add the try catch block to the constructor
            try
            {
               //add the databasecreator as a variable to type RelationalDatabaseCreator
                var databaseCreator = Database.GetService<IRelationalDatabaseCreator>() as RelationalDatabaseCreator;

               //add the if statement to check if the databaseCreator is not null

                if (databaseCreator != null)
                {
                    //add the if statement to check if the databaseCreator CanConnect
                    if (!databaseCreator.CanConnect())
                    {
                        //add the databaseCreator Create method
                        databaseCreator.Create();
                    }

                    //add the if statement to check if the databaseCreator has tables
                    if (!databaseCreator.HasTables())
                    {
                        //add the databaseCreator CreateTables method
                        databaseCreator.CreateTables();
                    }

                }
            }
            catch (IOException)
            {
               Console.WriteLine("Error creating database");
            }
        }

        //add the DbSet of the type shares to the class ApplicationDBContext

        public DbSet<Shares> Shares { get; set; }

    }
}
