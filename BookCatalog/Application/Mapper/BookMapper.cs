using BookCatalog.Application.Model;
using BookCatalog.Domain.Entity;

namespace BookCatalog.Application.Mapper
{
    public class BookMapper
    {
        public static BookDTO ToBookDTO(Book book, List<AuthorDTO> authorsDTO = null)
        {
            return new BookDTO(book.Title, book.Description, authorsDTO);
        }
    }
}
