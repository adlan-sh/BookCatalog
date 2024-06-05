using BookCatalog.Application.Model;
using BookCatalog.Domain.Entity;

namespace BookCatalog.Application.Mapper
{
    public class AuthorMapper
    {
        public static AuthorDTO ToAuthorDTO(Author author)
        {
            return new AuthorDTO(author.FirstName, author.LastName);
        }
    }
}
