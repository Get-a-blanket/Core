using GaB_Core.ProtectedDbConnector.Models;
using GaB_Core.UnprotectedDbConnector.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GaB_Core.Controllers
{
    /// <summary>
    /// Контроллер взаимодействия с сервисм Auth
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //TODO: внутренняя авторизация 

        /// <summary>
        /// Получить Client Id по regionCode и phoneNumber
        /// </summary>
        /// <param name="phoneNumber">Телефонный номер в виде числа</param>
        /// <param name="regionCodeId">Id регионального кода</param>
        /// <response code="200">ClientId найден</response>
        /// <response code="404">ClientId не найден</response>
        [HttpGet("GetClientId")]
        public Guid GetClientId(Int16 regionCodeId, long phoneNumber)
        {
            Guid? clientId = Program.GetProtectedContext().Clients.FirstOrDefault(c => c.PhoneRegionCode.Id == regionCodeId && c.PhoneNumber == phoneNumber)?.Id;
            if (clientId != null)
            {
                return clientId.Value;
            }
            else 
            {
                Response.StatusCode = 404;
                return Guid.Empty; 
            }
        }
    }
}
