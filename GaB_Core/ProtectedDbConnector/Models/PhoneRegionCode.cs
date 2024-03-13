using System.ComponentModel.DataAnnotations;

namespace GaB_Core.ProtectedDbConnector.Models
{
    public class PhoneRegionCode
    {
        /// <summary>
        /// Номер региона
        /// </summary>
        [Key]
        public Int16 Id {  get; set; } 
        
        /// <summary>
        /// Кодовое имя региона
        /// </summary>
        public string Name { get; set; }

        //public ICollection<Client> Clients { get; set; }
    }
}