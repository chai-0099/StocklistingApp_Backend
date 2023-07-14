namespace Stocklisting.Exception
{
    public class SharesNotFoundException: IOException
    {
        public SharesNotFoundException(string message): base(message)
        {
        }
    }
    
}
