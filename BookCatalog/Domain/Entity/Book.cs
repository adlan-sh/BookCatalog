namespace BookCatalog.Domain.Entity
{
    public class Book
    {
        public int Id { get; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
