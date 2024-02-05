namespace GaB_Core.ProtectedDbConnector.Models
{
    public class PayM
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; } 
    }
}