namespace MyDnsShop.Shared.Dto;

public class MemoryDto
{
    public Guid Id { get; set; }
    public required string PartType  { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public required string Url { get; set; }
    public required string Type { get; set; }
    public required string Size { get; set; }
    public decimal Price { get; set; }
}