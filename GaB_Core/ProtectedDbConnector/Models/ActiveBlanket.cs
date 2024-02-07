using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace GaB_Core.ProtectedDbConnector.Models
{
    public class ActiveBlanket
    {
        [Key]
        public Guid Id { get; set; }

        //public Guid ClientId { get; set; } 

        //public Guid PaymentTariffId { get; set; }

        public DateTime DataOfIssue { get; set; }

        public Client Client {get; set; }

        public PaymentTariff PaymentTariff { get; set; }
    }
}