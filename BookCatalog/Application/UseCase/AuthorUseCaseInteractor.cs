using BookCatalog.Application.Mapper;
using BookCatalog.Application.Model;
using BookCatalog.Application.Request;
using BookCatalog.Application.UseCase.Interface;
using BookCatalog.Domain.Service;

namespace BookCatalog.Application.UseCase
{
    public class AuthorUseCaseInteractor : IAuthorUseCaseInteractor
    {
        private AuthorService _authorService;

        public AuthorUseCaseInteractor(AuthorService authorService)
        {
            _authorService = authorService;
        }

        public AuthorDTO CreateAuthor(AuthorCreateRequest request)
        {
            string[] authorData = request.ToArray();
            return AuthorMapper.ToAuthorDTO(_authorService.CreateAuthor(authorData));
        }

        public List<AuthorDTO> GetAllAuthors()
        {
            return _authorService.GetAllAuthors().Select(a => AuthorMapper.ToAuthorDTO(a)).ToList();
        }

        public AuthorDTO GetAuthor(int id)
        {
            return AuthorMapper.ToAuthorDTO(_authorService.GetAuthorById(id));
        }

        public AuthorDTO EditAuthor(int id, AuthorEditRequest request)
        {
            string[] authorData = request.ToArray();
            return AuthorMapper.ToAuthorDTO(_authorService.EditAuthor(id, authorData));
        }

        public void DeleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);
        }
    }
}
