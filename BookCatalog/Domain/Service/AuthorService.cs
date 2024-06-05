using BookCatalog.Domain.Entity;
using BookCatalog.Domain.Exception;
using BookCatalog.Domain.Repository;

namespace BookCatalog.Domain.Service
{
    public class AuthorService
    {
        private IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author CreateAuthor(string[] author)
        {
            return _authorRepository.Create(author);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public Author GetAuthorById(int id)
        {
            Author? author = _authorRepository.GetById(id);

            if (author == null)
            {
                throw new AuthorNotFoundException("Автор не найден");
            }

            return author;
        }

        public Author EditAuthor(int id, string[] authorData)
        {
            if (_authorRepository.GetById(id) == null)
            {
                throw new AuthorNotFoundException("Автор не найден");
            }

            return _authorRepository.Edit(id, authorData);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
        }
    }
}
