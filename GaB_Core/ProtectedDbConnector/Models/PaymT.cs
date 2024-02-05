namespace GaB_Core.ProtectedDbConnector.Models
{
    public class PaymT
    {
        public Guid Id { get; set; }

        public string Name { get; set; } 

        public string Description { get; set; } 

        public decimal Price { get; set; }

        public ICollection<ActiveB> ActiveBlankets { get; set; }
    }
}