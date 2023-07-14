
using Stocklisting.Exception;
using Stocklisting.Model;

namespace Stocklisting.Repsository
{
  public class SharesRepo: ISharesRepo
  {

        //add the application db context
        private readonly ApplicationDBContext context; 

        //add the constructor to inject the application db context
        public SharesRepo(ApplicationDBContext context)
        {
            this.context = context;
        }


        //add the mthod to get all shares from the interface ISharesRepo
        public ICollection<Shares> GetAllShares()
        {
            //add try catch block with SharesNotFoundException
            try
            {
                //add the return statement to return all shares
                return context.Shares.ToList();
            }
            catch (SharesNotFoundException)
            {
                //add the throw statement to throw the SharesNotFoundException
                return null;
            }
            
        }


        //add the method to save the shares 
        public bool CreateShares(Shares shares)
        {
            //add try catch block with SharesAlreadyExistsException
            try
            {
                //add the context shares add method
                context.Shares.Add(shares);
                //add the context save changes method
                context.SaveChanges();
                //add the return statement to return true
                return true;
            }
            catch (SharesAlreadyExistsException)
            {
                //add the throw statement to throw the SharesAlreadyExistsException
                return false;
            }
            
        }

    
  }
}
