using BookCatalog.Application.Model;
using BookCatalog.Application.Request;

namespace BookCatalog.Application.UseCase.Interface
{
    public interface IBookUseCaseInteractor
    {
        public BookDTO CreateBook(BookCreateRequest request);

        public List<BookDTO> GetAllBooks();

        public BookDTO GetBook(int id);

        public BookDTO EditBook(int id, BookEditRequest request);

        public void DeleteBook(int id);

        public BookDTO AddAuthor(int bookId, int authorId);
    }
}
