using System.ComponentModel.DataAnnotations;

namespace GaB_Core.ProtectedDbConnector.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        //public Int16 PhoneRegionCodeId { get; set; } 

        public Int64 PhoneNumber { get; set; } 

        public string Email { get; set; } 

        public DateTime DateOfRegistration { get; set; }

        public PhoneRegionCode PhoneRegionCode { get; set; }

        public ICollection<ActiveBlanket> ActiveBlankets { get; set; }

    }
}