using BlazorServerCrud.Data;
using BlazorServerCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCrud.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public PersonsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var records = await _context.Persons.ToListAsync();

            return Ok(records);
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var record = await _context.Persons.FindAsync(id);

            return Ok(record!);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            //var record = await _context.Persons.FindAsync(id);


            //if (record == null)
            //{
            //    return NotFound();
            //}


            try
            {
                _context.Entry(person).State = EntityState.Modified;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpPost]
        public async Task<ActionResult> PostPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                await _context.Persons.AddAsync(person);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var record = await _context.Persons.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
