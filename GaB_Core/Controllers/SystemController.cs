using GaB_Core.UnprotectedDbConnector.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GaB_Core.Controllers.SystemControllerModels;

namespace GaB_Core.Controllers
{
    /// <summary>
    /// Котроллер проверки работы системы
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        /// <summary>
        /// Получить миграции защищенной базы данных
        /// </summary>
        [HttpGet("GetProtectedDBMigrations")]
        public IEnumerable<string> GetProtectedDBMigrations()
        {
            return Program.GetProtectedContext().Database.GetMigrations();
        }

        /// <summary>
        /// Получить миграции незащищенной базы данных
        /// </summary>
        [HttpGet("GetUnprotectedDBMigrations")]
        public IEnumerable<string> GetUnprotectedDBMigrations()
        {
            return Program.GetUnprotectedContext().Database.GetMigrations();
        }

        /// <summary>
        /// Получить статус системы
        /// </summary>
        [HttpGet("Status")]
        public Status Status()
        {
            return new Status {
                DateTime = new DateTime(),
                Version = typeof(Program).Assembly.GetName().Version.ToString(),
                ProtectedDBVersion = Program.GetProtectedContext().Database.GetMigrations().ToList()[^1],
                UnprotectedDBVersion = Program.GetUnprotectedContext().Database.GetMigrations().ToList()[^1]
            };
        }

    }
}
