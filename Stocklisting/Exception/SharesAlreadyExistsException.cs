namespace Stocklisting.Exception
{
    public class SharesAlreadyExistsException: IOException
    {
        public SharesAlreadyExistsException(string message): base(message)
        {
        }
    }
}
