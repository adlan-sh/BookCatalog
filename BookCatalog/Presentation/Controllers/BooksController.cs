using BookCatalog.Application.Request;
using BookCatalog.Application.UseCase;
using BookCatalog.Application.UseCase.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Presentation.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookUseCaseInteractor _interactor;

        public BooksController(IBookUseCaseInteractor interactor)
        {
            _interactor = interactor;
        }

        [HttpPost("/books/create")]
        public IActionResult Create(BookCreateRequest request)
        {
            return Ok(_interactor.CreateBook(request));
        }

        [HttpGet("/books")]
        public IActionResult GetAll()
        {
            return Ok(_interactor.GetAllBooks());
        }

        [HttpGet("/books/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_interactor.GetBook(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("books/{id}")]
        public IActionResult Edit(int id, BookEditRequest request)
        {
            return Ok(_interactor.EditBook(id, request));
        }

        [HttpDelete("books/{id}")]
        public IActionResult Delete(int id)
        {
            _interactor.DeleteBook(id);
            return Ok();
        }

        [HttpPost("/books/{bookId}/author/{authorId}")]
        public IActionResult AddAuthor(int bookId, int authorId)
        {
            try
            {
                return Ok(_interactor.AddAuthor(bookId, authorId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
