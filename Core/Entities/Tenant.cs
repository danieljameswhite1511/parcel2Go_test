namespace Core.Entities
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; }

        public string  Host { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Scope { get; set; }
        
        
    }
}