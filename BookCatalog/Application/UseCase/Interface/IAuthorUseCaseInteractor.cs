using BookCatalog.Application.Model;
using BookCatalog.Application.Request;

namespace BookCatalog.Application.UseCase.Interface
{
    public interface IAuthorUseCaseInteractor
    {
        public AuthorDTO CreateAuthor(AuthorCreateRequest request);

        public List<AuthorDTO> GetAllAuthors();

        public AuthorDTO GetAuthor(int id);

        public AuthorDTO EditAuthor(int id, AuthorEditRequest request);

        public void DeleteAuthor(int id);
    }
}
