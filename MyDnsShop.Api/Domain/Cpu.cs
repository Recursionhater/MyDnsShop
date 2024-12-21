namespace MyDnsShop.Api.Domain;

public class Cpu
{
    public Guid Id { get; set; }
    public required string PartType  { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public required string Url { get; set; }
    public required string Brand { get; set; }
    public required string Socket { get; set; }
    public required string Speed { get; set; }
    public required string CoreCount { get; set; }
    public required string ThreadCount { get; set; }
    public required string Power { get; set; }
    public decimal Price { get; set; }
}