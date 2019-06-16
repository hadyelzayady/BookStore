using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using BookStore.UnitOfWork;
using BookStore.Repositories;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //this is so WROOOOOOOOOOOONG as bookrepos has another context other than unitofwork
        private readonly UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork(new BookStoreContext());
        private IBookRepository bookRepository;
        public BooksController(BookStoreContext context)
        {
            bookRepository = new BookRepository(context);
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return bookRepository.GetAll();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var book = await _context.Books.FindAsync(id);
            var book = bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult PutBook([FromRoute] long id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            unitOfWork.Context.Entry(book).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult PostBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.Books.Add(book);
            //await _context.SaveChangesAsync();
            bookRepository.Insert(book);
            unitOfWork.Save();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        private bool BookExists(long id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}