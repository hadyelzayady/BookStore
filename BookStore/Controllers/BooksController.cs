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
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books=await _unitOfWork.BookRepository.GetAll();
            return Ok(books);
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
            var book = await _unitOfWork.BookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook([FromRoute] int id, [FromBody] Book book)
        {
            try
            {
                if (!ModelState.IsValid)
            {
                return  BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }
           
                _unitOfWork.BookRepository.Update(book);
                 var result=await _unitOfWork.SaveAsync();
                 return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
           
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult >PostBook([FromBody] Book book)
        {
            try
            {
                if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.BookRepository.Insert(book);
           
            var result=await _unitOfWork.SaveAsync();
            if (result == 0)
                return BadRequest();
             _unitOfWork.BookRepository.LoadBookCategory(book);
             return CreatedAtAction("GetBook", new { id = book.Id }, book);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }

        //DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _unitOfWork.BookRepository.Delete(id);

                var result = await _unitOfWork.SaveAsync();
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }catch
            {
                return  StatusCode(500, "Internal server error");
            }
           
        }

    }
}