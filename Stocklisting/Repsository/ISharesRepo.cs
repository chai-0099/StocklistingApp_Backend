
using Stocklisting.Model;

namespace Stocklisting.Repsository
{
  public interface ISharesRepo
  {
    
        //add method to create a new share with boolean

        bool CreateShares(Shares shares);

        //add a method to get all shares using ICollection

        ICollection<Shares> GetAllShares();
 
  }
}
