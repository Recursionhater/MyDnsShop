namespace MyDnsShop.Shared.Dto;

public class StorageDto
{
    public Guid Id { get; set; }
    public required string PartType  { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public required string Url { get; set; }
    public required string Type { get; set; }
    public required string Space { get; set; }
    public decimal Price { get; set; }
}