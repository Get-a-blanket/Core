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
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ProtectedDbContext _context;

        public ClientsController()
        {
            _context = GaB_Core.Program.GetProtectedContext();
        }

        // GET: api/Clients
        /// <summary>
        /// Получить полный список клиентов
        /// </summary>
        /// <response code="200">Данные о всех клиентах</response>
        /// <response code="500">Ошибка базы данных</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        /// <summary>
        /// Получить конкретного клиента по ID
        /// </summary>
        /// <param name="id">GUID клиента</param>
        /// <response code="200">Данные о конкретном клиенте</response>
        /// <response code="500">Ошибка базы данных</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Client>> GetClient(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Изменить данные о клиенте
        /// </summary>
        /// <param name="id">GUID клиента</param>
        /// <param name="client">Полное представление клиента</param>
        /// <returns></returns>
        /// <response code="204">Данные о клиенте изменены</response>
        /// <response code="400">GUID не совпадают</response>
        /// <response code="404">Не найден клиент</response>
        /// <response code="500">Ошибка базы данных</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutClient(Guid id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Создать нового клиента
        /// </summary>
        /// <param name="client">Полное представление клиента</param>
        /// <response code="200">Данные сохранены</response>
        /// <response code="500">Ошибка базы данных</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="id">GUID клиента</param>
        /// <response code="200">Данные о кллиенте удалены</response>
        /// <response code="404">Не найден клиент</response>
        /// <response code="500">Ошибка базы данных</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Client>> DeleteClient(Guid id)
        {
            var client = await _context.Clients.Include(c => c.ActiveBlankets).FirstAsync(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            client.ActiveBlankets.Clear();
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return client;
        }

        private bool ClientExists(Guid id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
