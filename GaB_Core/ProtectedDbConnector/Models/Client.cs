using System.ComponentModel.DataAnnotations;

namespace GaB_Core.ProtectedDbConnector.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Int16 PhoneRegionCodeId { get; set; } 

        [Required]
        public Int64 PhoneNumber { get; set; }

        public string? Email { get; set; }

        [Required]
        public DateTime DateOfRegistration { get; set; }

        [Required]
        public PhoneRegionCode PhoneRegionCode { get; set; }

        [Required]
        public ICollection<ActiveBlanket> ActiveBlankets { get; set; }

    }
}