using System.ComponentModel.DataAnnotations;

namespace GaB_Core.ProtectedDbConnector.Models
{
    public class PaymentTariff
    {
        /// <summary>
        /// GUID тарифа
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Отображаемое короткое имя
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// Описание тарифа
        /// </summary>
        public string Description { get; set; } 
        
        //public ICollection<ActiveBlanket> ActiveBlankets { get; set; }
    }
}