namespace BookCatalog.Domain.Exception
{
    public class BookNotFoundException : ApplicationException
    {
        public BookNotFoundException(string message) : base(message)
        {
        }
    }
}
