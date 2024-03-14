using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GaB_Core.Controllers.MapControllerModels;
using GaB_Core.UnprotectedDbConnector.Models;
using GaB_Core.ProtectedDbConnector.Models;

namespace GaB_Core.Controllers
{
    /// <summary>
    ///  Контроллер функций нетребующих авторизации
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PublicOperationsController : ControllerBase
    {
        /// <summary>
        /// Выдать полный список всех доступных автоматов
        /// </summary>
        /// <returns>
        /// Список всех вендиговых аппаратов
        /// </returns>
        [HttpGet("GetAllVendingMachneInformation")]
        public IEnumerable<VendingMachine> GetAllVendingMachneInformation()
        {
            return Program.GetUnprotectedContext().VendingMachines;
        }

        /// <summary>
        /// Получить доступные региональные коды
        /// </summary>
        [HttpGet("GetAllRegionCodes")]
        public IEnumerable<PhoneRegionCode> GetRegionCodes()
        {
            return Program.GetProtectedContext().PhoneRegionCodes;
        }
    }
}
