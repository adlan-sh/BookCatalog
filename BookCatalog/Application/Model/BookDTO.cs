namespace BookCatalog.Application.Model
{
    public class BookDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<AuthorDTO> Authors { get; set; } = new List<AuthorDTO>();

        public BookDTO(string title, string description, List<AuthorDTO> authors) 
        {
            Title = title;
            Description = description;
            Authors = authors;
        }
    }
}
