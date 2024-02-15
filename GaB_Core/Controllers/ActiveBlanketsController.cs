using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GaB_Core.ProtectedDbConnector;
using GaB_Core.ProtectedDbConnector.Models;

namespace GaB_Core.Controllers
{
    /// <summary>
    /// Контроллер управления активными пледами (находящимеся в аренде)
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ActiveBlanketsController : ControllerBase
    {
        private readonly ProtectedDbContext _context;
        
        public ActiveBlanketsController()
        {
            _context = GaB_Core.Program.GetProtectedContext();
        }

        // GET: api/ActiveBlankets
        /// <summary>
        /// Получить полный список пледов в аренде
        /// </summary>
        /// <response code="200">Данные о всех пледах</response>
        /// <response code="500">Ошибка базы данных</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActiveBlanket>>> GetActiveBlankets()
        {
            return await _context.ActiveBlankets.ToListAsync();
        }

        // GET: api/ActiveBlankets/5
        /// <summary>
        /// Получить конкретный плед по ID
        /// </summary>
        /// <param name="id">GUID пледа</param>
        /// <response code="200">Данные о конкретном пледе</response>
        /// <response code="500">Ошибка базы данных</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ActiveBlanket>> GetActiveBlanket(Guid id)
        {
            var activeBlanket = await _context.ActiveBlankets.FindAsync(id);

            if (activeBlanket == null)
            {
                return NotFound();
            }

            return activeBlanket;
        }

        // PUT: api/ActiveBlankets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Изменить данные о активном пледе
        /// </summary>
        /// <param name="id">GUID пледа</param>
        /// <param name="activeBlanket">Полное представление активного пледа</param>
        /// <returns></returns>
        /// <response code="204">Данные о пледе изменены</response>
        /// <response code="400">GUID не совпадают</response>
        /// <response code="404">Не найден плед</response>
        /// <response code="500">Ошибка базы данных</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActiveBlanket(Guid id, ActiveBlanket activeBlanket)
        {
            if (id != activeBlanket.Id)
            {
                return BadRequest();
            }

            _context.Entry(activeBlanket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiveBlanketExists(id))
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

        /// <summary>
        /// Создать новый активный плед
        /// </summary>
        /// <param name="activeBlanket">Полное представление активного пледа</param>
        /// <response code="200">Данные сохранены</response>
        /// <response code="500">Ошибка базы данных</response>
        // POST: api/ActiveBlankets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ActiveBlanket>> PostActiveBlanket(ActiveBlanket activeBlanket)
        {
            _context.ActiveBlankets.Add(activeBlanket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActiveBlanket", new { id = activeBlanket.Id }, activeBlanket);
        }

        /// <summary>
        /// Удалить активный плед
        /// </summary>
        /// <param name="id">GUID пледа</param>
        /// <response code="200">Данные о пледе удалены</response>
        /// <response code="404">Не найден плед</response>
        /// <response code="500">Ошибка базы данных</response>
        // DELETE: api/ActiveBlankets/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ActiveBlanket>> DeleteActiveBlanket(Guid id)
        {
            var activeBlanket = await _context.ActiveBlankets.FindAsync(id);
            if (activeBlanket == null)
            {
                return NotFound();
            }

            _context.ActiveBlankets.Remove(activeBlanket);
            await _context.SaveChangesAsync();

            return activeBlanket;
        }

        private bool ActiveBlanketExists(Guid id)
        {
            return _context.ActiveBlankets.Any(e => e.Id == id);
        }
    }
}
