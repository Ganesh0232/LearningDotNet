using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UserStories.Data;
using UserStories.Models;

namespace UserStories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStoriesController : ControllerBase
    {
        private readonly UserStoriesContext _context;
        private readonly IDbConnection _connectionString;

        public UserStoriesController(UserStoriesContext context)
        {
            _context = context;
        }

        // GET: api/UserStories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterModel>>> GetRegisterModel()
        {
          if (_context.RegisterModel == null)
          {
              return NotFound();
          }
            return await _context.RegisterModel.ToListAsync();
        }

        // GET: api/UserStories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterModel>> GetRegisterModel(int id)
        {
          if (_context.RegisterModel == null)
          {
              return NotFound();
          }
            var registerModel = await _context.RegisterModel.FindAsync(id);

            if (registerModel == null)
            {
                return NotFound();
            }

            return registerModel;
        }

        // PUT: api/UserStories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update")]
        public async Task<IActionResult> PutRegisterModel(int id, RegisterModel registerModel)
        {
            if (id != registerModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(registerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterModelExists(id))
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


        //[HttpPut("UpdateUsingDapper")]
        //public async Task<IActionResult> Update(int id, [FromBody] RegisterModel model)
        //{
        //    if (model == null || id != model.Id)
        //    {
        //        return BadRequest();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var query = "UPDATE MyTable SET Name = @Name, Age = @Age WHERE Id = @Id";
        //        var parameters = new { Name = model.FirstName,PhoneNumber = model.phoneNumber, Id = id };
        //        await connection.ExecuteAsync(query, parameters);
        //    }

        //    return NoContent();
        //}

        // POST: api/UserStories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPost]
        public async Task<ActionResult<RegisterModel>> PostRegisterModel(RegisterModel registerModel)
        {
          if (_context.RegisterModel == null)
          {
              return Problem("Entity set 'UserStoriesContext.RegisterModel'  is null.");
          }
            _context.RegisterModel.Add(registerModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisterModel", new { id = registerModel.Id }, registerModel);
        }

        // DELETE: api/UserStories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisterModel(int id)
        {
            if (_context.RegisterModel == null)
            {
                return NotFound();
            }
            var registerModel = await _context.RegisterModel.FindAsync(id);
            if (registerModel == null)
            {
                return NotFound();
            }

            _context.RegisterModel.Remove(registerModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterModelExists(int id)
        {
            return (_context.RegisterModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
