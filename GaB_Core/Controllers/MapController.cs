using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GaB_Core.Controllers.MapControllerModels;
using GaB_Core.UnprotectedDbConnector.Models;

namespace GaB_Core.Controllers
{
    /// <summary>
    ///  Контроллер функций карты 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        /// <summary>
        /// Выдать полный список всех доступных автоматов
        /// </summary>
        /// <returns>
        /// Список всех вендиговых аппаратов
        /// </returns>
        [HttpGet(Name = "GetAllVendingMachneInformation")]
        public IEnumerable<VendingMachine> GetAllVendingMachneInformation()
        {
            return Program.GetUnprotectedContext().VendingMachines;
        }
    }
}
