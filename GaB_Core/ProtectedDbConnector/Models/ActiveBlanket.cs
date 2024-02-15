using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace GaB_Core.ProtectedDbConnector.Models
{
    /// <summary>
    /// Плед взятый в данный момент в аренду
    /// </summary>
    public class ActiveBlanket
    {
        /// <summary>
        /// GUID активного пледа
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        //public Guid ClientId { get; set; } 

        //public Guid PaymentTariffId { get; set; }
        
        /// <summary>
        /// ДатаВремя выдачи
        /// </summary>
        public DateTime DataOfIssue { get; set; }

        /// <summary>
        /// Клиент, которому выдан плед
        /// </summary>
        //public Client Client {get; set; }

        /// <summary>
        /// Тип тарифа, по которому выдан плед
        /// </summary>
        public PaymentTariff PaymentTariff { get; set; }
    }
}