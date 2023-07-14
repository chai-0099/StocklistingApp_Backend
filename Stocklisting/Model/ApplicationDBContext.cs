using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Stocklisting.Model
{
  public class ApplicationDBContext: DbContext
  {
    //add the following constructor to the class ApplicationDBContext
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
      //add the try catch block to the constructor
      try
      {
        //add databaseCreator as a variable of type RelationalDatabaseCreator
        var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

        //add if statement to check if databaseCreator is not null
        if (databaseCreator != null)
        {
          //add if statement to check if databaseCreator can connect
          if (!databaseCreator.CanConnect())
          {
            //create the databaseCreator
            databaseCreator.Create();
          }
          //add if statement to check if databaseCreator has tables
          if (!databaseCreator.HasTables())
          {
            //create the tables
            databaseCreator.CreateTables();
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    //add the DbSet of type Shares to the class ApplicationDBContext
    public DbSet<Shares> Shares { get; set; }
  }
}
