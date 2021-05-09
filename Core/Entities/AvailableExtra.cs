namespace Core.Entities
{
    public class AvailableExtra
    {
     public string Type { get; set; }   
     public decimal Price { get; set; }

    public decimal Vat { get; set; }
    public decimal Total { get; set; }

    public Details Details { get; set; }

    }
}