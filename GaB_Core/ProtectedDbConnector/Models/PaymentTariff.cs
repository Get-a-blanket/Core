using System.ComponentModel.DataAnnotations;

namespace GaB_Core.ProtectedDbConnector.Models
{
    public class PaymentTariff
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } 

        public string Description { get; set; } 

        public decimal Price { get; set; }

        public ICollection<ActiveBlanket> ActiveBlankets { get; set; }
    }
}