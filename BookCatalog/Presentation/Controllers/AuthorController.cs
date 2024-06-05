using BookCatalog.Application.Request;
using BookCatalog.Application.UseCase.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Presentation.Controllers
{
    public class AuthorController : ControllerBase
    {
        private IAuthorUseCaseInteractor _interactor;

        public AuthorController(IAuthorUseCaseInteractor interactor)
        {
            _interactor = interactor;
        }

        [HttpPost("/authors/create")]
        public IActionResult Create(AuthorCreateRequest request)
        {
            return Ok(_interactor.CreateAuthor(request));
        }

        [HttpGet("/authors")]
        public IActionResult GetAll()
        {
            return Ok(_interactor.GetAllAuthors());
        }

        [HttpGet("/authors/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_interactor.GetAuthor(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("/authors/{id}")]
        public IActionResult Edit(int id, AuthorEditRequest request)
        {
            return Ok(_interactor.EditAuthor(id, request));
        }

        [HttpDelete("/authors/{id}")]
        public IActionResult Delete(int id)
        {
            _interactor.DeleteAuthor(id);
            return Ok();
        }
    }
}
