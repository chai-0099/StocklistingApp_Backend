using Stocklisting.Model;

namespace Stocklisting.Repsository
{
  public interface ISharesRepo
  {
    //add methods to createShares
    bool createShares(Shares shares);

    //add methods to getAllShares
    ICollection<Shares> allShares();

  }
}
