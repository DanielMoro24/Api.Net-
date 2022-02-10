#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Net.Models;

namespace Api.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class botasFutbolsController : ControllerBase
    {
        private readonly BotasContext _context;

        public botasFutbolsController(BotasContext context)
        {
            _context = context;
        }

        // GET: api/botasFutbols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<botasFutbol>>> GetBotasFutbols()
        {
            return await _context.BotasFutbols.ToListAsync();
        }

        // GET: api/botasFutbols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<botasFutbol>> GetbotasFutbol(long id)
        {
            var botasFutbol = await _context.BotasFutbols.FindAsync(id);

            if (botasFutbol == null)
            {
                return NotFound();
            }

            return botasFutbol;
        }

        // PUT: api/botasFutbols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutbotasFutbol(long id, botasFutbol botasFutbol)
        {
            if (id != botasFutbol.Id)
            {
                return BadRequest();
            }

            _context.Entry(botasFutbol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!botasFutbolExists(id))
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

        // POST: api/botasFutbols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<botasFutbol>> PostbotasFutbol(botasFutbol botasFutbol)
        {
            _context.BotasFutbols.Add(botasFutbol);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetbotasFutbol", new { id = botasFutbol.Id }, botasFutbol);
            return CreatedAtAction(nameof(GetbotasFutbol), new { id = botasFutbol.Id }, botasFutbol);
        }

        // DELETE: api/botasFutbols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletebotasFutbol(long id)
        {
            var botasFutbol = await _context.BotasFutbols.FindAsync(id);
            if (botasFutbol == null)
            {
                return NotFound();
            }

            _context.BotasFutbols.Remove(botasFutbol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool botasFutbolExists(long id)
        {
            return _context.BotasFutbols.Any(e => e.Id == id);
        }
    }
}
