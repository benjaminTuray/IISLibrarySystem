using IISLibrarySystem.Dto;
using IISLibrarySystem.Dto.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IISLibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IISLibController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IISLibController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var ISLibs = await _context.ISLibs.ToListAsync();
            return Ok(ISLibs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleBook(int id)
        {
            var book = await _context.ISLibs.FindAsync(id);
            if (book is null)
                return BadRequest("Book Not Found");
            return Ok(book);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<ISLib>> AddBook(ISLibDto bookdto)
        {
            var newCharacter = new ISLib
            {
                Id = bookdto.Id,
                Title = bookdto.Title,
                Author = bookdto.Author,
                Grade = bookdto.Grade,
                Category = bookdto.Category,
                Published_date = bookdto.Published_date,
                Quantity = bookdto.Quantity,
                Available_quantity = bookdto.Available_quantity

            };
            _context.ISLibs.Add(newCharacter);
            await _context.SaveChangesAsync();
            return Ok(new Response { Data = "record added successfully", Status = "Success", Message = "ISLib Updated Successfully" });

        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateBook([FromBody] ISLib isbk)
        {
            var existingBook = await _context.ISLibs.FindAsync(isbk.Id);
            if (existingBook is null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Book  not found." });

            existingBook.Title = isbk.Title;
            existingBook.Author = isbk.Author;
            existingBook.Grade = isbk.Grade;
            existingBook.Category = isbk.Category;
            existingBook.Published_date = isbk.Published_date;
            existingBook.Quantity = isbk.Quantity;
            existingBook.Available_quantity = isbk.Available_quantity;

            await _context.SaveChangesAsync();
            return Ok(new Response { Data = existingBook.ToString(), Status = "Success", Message = "Book Record Deleted Successfully" });

        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.ISLibs.FindAsync(id);
            if (book is null)
                return BadRequest("Book Not Found");

            _context.ISLibs.Remove(book);
            await _context.SaveChangesAsync();
            return Ok(new Response { Data = GetAllBooks().ToString(), Status = "Success", Message = " Book Updated Successfully" });

        }
    }
}
