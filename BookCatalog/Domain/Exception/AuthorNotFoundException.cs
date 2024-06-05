namespace BookCatalog.Domain.Exception
{
    public class AuthorNotFoundException : ApplicationException
    {
        public AuthorNotFoundException(string message) : base(message)
        {
        }
    }
}
