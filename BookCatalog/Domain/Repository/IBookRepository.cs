using BookCatalog.Domain.Entity;

namespace BookCatalog.Domain.Repository
{
    public interface IBookRepository
    {
        public Book Create(string[] book);

        public List<Book> GetAll();

        public Book? GetById(int id);

        public Book? Edit(int id, string[] book);

        public void Delete(int id);

        public Book? AddAuthor(int bookId, int authorId);
    }
}
