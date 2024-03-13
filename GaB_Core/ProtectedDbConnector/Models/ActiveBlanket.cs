using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace GaB_Core.ProtectedDbConnector.Models
{
    public class ActiveBlanket
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public Guid PaymentTariffId { get; set; }

        [Required]
        public DateTime DataOfIssue { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public PaymentTariff PaymentTariff { get; set; }
    }
}