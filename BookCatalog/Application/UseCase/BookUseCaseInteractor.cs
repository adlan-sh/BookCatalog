using BookCatalog.Application.Mapper;
using BookCatalog.Application.Model;
using BookCatalog.Application.Request;
using BookCatalog.Application.UseCase.Interface;
using BookCatalog.Domain.Service;

namespace BookCatalog.Application.UseCase
{
    public class BookUseCaseInteractor : IBookUseCaseInteractor
    {
        private BookService _bookService;

        public BookUseCaseInteractor(BookService bookService) 
        {
            _bookService = bookService;
        }

        public BookDTO CreateBook(BookCreateRequest request)
        {
            string[] bookData = request.ToArray();
            return BookMapper.ToBookDTO(_bookService.CreateBook(bookData));
        }

        public List<BookDTO> GetAllBooks()
        {
            return _bookService.GetAllBooks().Select(b => BookMapper.ToBookDTO(b)).ToList();
        }

        public BookDTO GetBook(int id)
        {
            var book = _bookService.GetBookById(id);
            return BookMapper.ToBookDTO(book, book.Authors.Select(a => AuthorMapper.ToAuthorDTO(a)).ToList());
        }

        public BookDTO EditBook(int id, BookEditRequest request)
        {
            string[] bookData = request.ToArray();
            return BookMapper.ToBookDTO(_bookService.EditBook(id, bookData));
        }

        public void DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
        }

        public BookDTO AddAuthor(int bookId, int authorId)
        {
            var book = _bookService.AddAuthor(bookId, authorId);
            return BookMapper.ToBookDTO(book, book.Authors.Select(a => AuthorMapper.ToAuthorDTO(a)).ToList());
        }
    }
}
