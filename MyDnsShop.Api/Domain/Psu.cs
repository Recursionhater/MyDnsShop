namespace MyDnsShop.Api.Domain;

public class Psu
{
    public Guid Id { get; set; }
    public required string PartType  { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public required string Url { get; set; }
    public required string Power { get; set; }
    public required string Size { get; set; }
    public decimal Price { get; set; }
}