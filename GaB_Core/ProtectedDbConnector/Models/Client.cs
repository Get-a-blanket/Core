using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Numerics;

namespace GaB_Core.ProtectedDbConnector.Models
{
    public class Client
    {
        public Guid Id { get; set; }

        public Int16 PhoneRegionCodeId { get; set; } 

        public Int64 PhoneNumber { get; set; } 

        public string Email { get; set; } 

        public DateTime DateOfRegistration { get; set; }

        public PhRCode PhoneRegionCode { get; set; }

        public ICollection<ActiveB> ActiveBlankets { get; set; }

        public ICollection<PayM> PaymentMethod { get; set; }
    }
}