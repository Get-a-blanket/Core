using System.ComponentModel.DataAnnotations;

namespace GaB_Core.ProtectedDbConnector.Models
{
    public class PhoneRegionCode
    {
        [Key]
        public Int16 Id {  get; set; } 

        public string Name { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}