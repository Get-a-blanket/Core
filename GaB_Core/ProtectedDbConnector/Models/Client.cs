using System.ComponentModel.DataAnnotations;

namespace GaB_Core.ProtectedDbConnector.Models
{
    /// <summary>
    /// Аккаунт клиента
    /// </summary>
    public class Client
    {
        /// <summary>
        /// GUID клиента 
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        //public Int16 PhoneRegionCodeId { get; set; } 

        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public Int64 PhoneNumber { get; set; } 

        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; } 

        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime DateOfRegistration { get; set; }

        //public PhoneRegionCode PhoneRegionCode { get; set; }
        
        /// <summary>
        /// Пледы находящиеся в аренде
        /// </summary>
        public ICollection<ActiveBlanket> ActiveBlankets { get; set; }

    }
}