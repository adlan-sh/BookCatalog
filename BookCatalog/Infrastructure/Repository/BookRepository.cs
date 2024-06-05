using BookCatalog.Domain.Entity;
using BookCatalog.Domain.Repository;
using BookORM = BookCatalog.Infrastructure.ORM.Book;
using AuthorORM = BookCatalog.Infrastructure.ORM.Author;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private ApplicationContext _context;
        public BookRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public Book? GetById(int id)
        {
            BookORM? bookOrm = _context.Books.Include(b => b.Authors).FirstOrDefault(b => b.Id == id);

            if (bookOrm != null)
            {
                Book book = new Book();
                book.Title = bookOrm.Title;
                book.Description = bookOrm.Description;
                foreach (AuthorORM author in bookOrm.Authors)
                {
                    Author authorBook = new Author();
                    authorBook.FirstName = author.FirstName;
                    authorBook.LastName = author.LastName;
                    book.Authors.Add(authorBook);
                }

                return book;
            }

            return null;
        }

        public Book? AddAuthor(int bookId, int authorId)
        {
            BookORM? bookOrm = _context.Books.Include(b => b.Authors).FirstOrDefault(b => b.Id == bookId);
            AuthorORM? authorOrm = _context.Author.FirstOrDefault(a => a.Id == authorId);

            if (bookOrm != null && authorOrm != null)
            {
                bookOrm.Authors.Add(authorOrm);
                _context.SaveChanges();

                Book book = new Book();
                book.Title = bookOrm.Title;
                book.Description = bookOrm.Description;
                foreach (AuthorORM author in bookOrm.Authors)
                {
                    Author authorBook = new Author();
                    authorBook.FirstName = author.FirstName;
                    authorBook.LastName = author.LastName;
                    book.Authors.Add(authorBook);
                }
                return book;
            }

            return null;
        }

        public Book Create(string[] bookData)
        {
            Book book = new Book();
            book.Title = bookData[0];
            book.Description = bookData[1];

            BookORM bookOrm = new BookORM();
            bookOrm.Title = book.Title;
            bookOrm.Description = book.Description;

            _context.Books.Add(bookOrm);
            _context.SaveChanges();

            return book;
        }

        public void Delete(int id)
        {
            BookORM book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public Book? Edit(int id, string[] book)
        {
            BookORM bookOrm = _context.Books.FirstOrDefault(b => b.Id == id);

            if (bookOrm != null)
            {
                bookOrm.Title = book[0];
                bookOrm.Description = book[1];
                _context.SaveChanges();

                Book editedBook = new Book();
                editedBook.Title = bookOrm.Title;
                editedBook.Description = bookOrm.Description;
                return editedBook;
            }

            return null;
        }

        public List<Book> GetAll()
        {
            return _context.Books
                .Select(b => new Book() { Title = b.Title, Description = b.Description})
                .ToList();
        }
    }
}
