using BookCatalog.Domain.Entity;

namespace BookCatalog.Domain.Repository
{
    public interface IAuthorRepository
    {
        public Author Create(string[] author);

        public List<Author> GetAll();

        public Author? GetById(int id);

        public Author? Edit(int id, string[] author);

        public void Delete(int id);
    }
}
