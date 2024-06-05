using BookCatalog.Domain.Entity;
using BookCatalog.Domain.Repository;
using AuthorORM = BookCatalog.Infrastructure.ORM.Author;

namespace BookCatalog.Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private ApplicationContext _context;
        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Author Create(string[] authorData)
        {
            Author author = new Author();
            author.FirstName = authorData[0];
            author.LastName = authorData[1];

            _context.Author.Add(new AuthorORM(author.FirstName, author.LastName));
            _context.SaveChanges();

            return author;
        }

        public void Delete(int id)
        {
            AuthorORM author = _context.Author.FirstOrDefault(a => a.Id == id);

            if (author != null)
            {
                _context.Author.Remove(author);
                _context.SaveChanges();
            }
        }

        public Author? Edit(int id, string[] author)
        {
            AuthorORM authorOrm = _context.Author.FirstOrDefault(a => a.Id == id);

            if (authorOrm != null)
            {
                authorOrm.FirstName = author[0];
                authorOrm.LastName = author[1];
                _context.SaveChanges();

                Author editedAuthor = new Author();
                editedAuthor.FirstName = authorOrm.FirstName;
                editedAuthor.LastName = authorOrm.LastName;
                return editedAuthor;
            }

            return null;
        }

        public List<Author> GetAll()
        {
            return _context.Author
                .Select(a => new Author() { FirstName = a.FirstName, LastName = a.LastName })
                .ToList();
        }

        public Author? GetById(int id)
        {
            AuthorORM? authorOrm = _context.Author.FirstOrDefault(b => b.Id == id);

            if (authorOrm != null)
            {
                Author author = new Author();
                author.FirstName = authorOrm.FirstName;
                author.LastName = authorOrm.LastName;

                return author;
            }

            return null;
        }
    }
}
