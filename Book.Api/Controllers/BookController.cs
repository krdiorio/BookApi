using BooksApi.Model;
using BooksApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteBook = await _bookRepository.Get(id);

            if (deleteBook == null)
                return NotFound();


            await _bookRepository.Delete(deleteBook.Id);
            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Book book)
        {

            if (id != book.Id)
                return BadRequest();

            await _bookRepository.Update(book);
            return NoContent();

        }






    }
}
