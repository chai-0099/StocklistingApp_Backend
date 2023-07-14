using Stocklisting.Model;

namespace Stocklisting.Repsository
{
  public class SharesRepo: ISharesRepo
  {

    //add the ApplicationDBContext as a variable
    private readonly ApplicationDBContext _dbContext;


    //add the constructor to the class SharesRepo
    public SharesRepo(ApplicationDBContext applicationDbContext)
    {
      _dbContext = applicationDbContext;
    }


    //add the method allShares to the class SharesRepo
    ICollection<Shares> ISharesRepo.allShares()
    {
      return _dbContext.Shares.OrderBy(a => a.symbol).ToList();
    }



    //add the method createShares to the class SharesRepo
    bool ISharesRepo.createShares(Shares s)
    {
      _dbContext.Shares.Add(s);
      return save();
    }


    //add the method save to the class SharesRepo
    public bool save()
    {
      return (_dbContext.SaveChanges() >= 0 ? true : false);
    }


  }
}
