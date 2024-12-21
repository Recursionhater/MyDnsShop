namespace MyDnsShop.Shared.Dto;

public class GpuDto
{
    public Guid Id { get; set; }
    public required string PartType  { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public required string Url { get; set; }
    public required string Brand { get; set; }
    public required string Vram { get; set; }
    public required string Resolution { get; set; }
    public required string Power { get; set; }
    public decimal Price { get; set; }
}