using BookCatalog.Domain.Entity;
using BookCatalog.Domain.Exception;
using BookCatalog.Domain.Repository;

namespace BookCatalog.Domain.Service
{
    public class BookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book CreateBook(string[] book)
        {
            return _bookRepository.Create(book);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            Book? book = _bookRepository.GetById(id);

            if (book == null)
            {
                throw new BookNotFoundException("Книга не найдена");
            }

            return book;
        }

        public Book EditBook(int id, string[] bookData)
        {
            if (_bookRepository.GetById(id) == null)
            {
                throw new BookNotFoundException("Книга не найдена");
            }

            return _bookRepository.Edit(id, bookData);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

        public Book AddAuthor(int bookId, int authorId)
        {
            Book? book = _bookRepository.AddAuthor(bookId, authorId);

            if (book == null)
            {
                throw new BookNotFoundException("Книга не найдена");
            }

            return book;
        }
    }
}
