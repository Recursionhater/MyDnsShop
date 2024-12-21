using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;

namespace MyDnsShop.Api.Infrastructure.Seed;

public partial class Seed
{
    public static void Generate()
    {
        var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "./../../../Infrastructure/Seed"));
        var sb = new StringBuilder("using MyDnsShop.Api.Domain;");
        sb.AppendLine();
        sb.AppendLine("namespace MyDnsShop.Api.Infrastructure.Seed;");
        sb.AppendLine("public partial class Seed");
        sb.AppendLine("{");
        sb.AppendLine("    public static void Create(MyDnsShopDbContext context)");
        sb.AppendLine("    {");
        foreach (var path in Directory.EnumerateFiles(basePath,"*.csv"))
        {
            switch (Path.GetFileNameWithoutExtension(path))
            {
                case "Case":
                    Parse<CaseDto>(path, sb);
                    break;
                case "Cooler":
                    Parse<CoolerDto>(path, sb);
                    break;
                case "CPU":
                    Parse<CpuDto>(path, sb);
                    break;
                case "GPU":
                    Parse<GpuDto>(path, sb);
                    break;
                case "Memory":
                    Parse<MemoryDto>(path, sb);
                    break;
                case "Motherboard":
                    Parse<MotherboardDto>(path, sb);
                    break;
                case "PSU":
                    Parse<PsuDto>(path, sb);
                    break;
                case "Storage":
                    Parse<StorageDto>(path, sb);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(path), path, null);
            }
            
        }
        sb.AppendLine("    context.SaveChanges();");
        sb.AppendLine("    }");
        sb.AppendLine("}");
        File.WriteAllText(Path.Combine(basePath, "Seed.Generated.cs"), sb.ToString());
        
        
    }


    private static void Parse<T>(string path, StringBuilder sb)
    {
        using var reader = new StreamReader(path);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => JsonNamingPolicy.CamelCase.ConvertName(args.Header),
        };
        using var csv = new CsvReader(reader, config);
        var items = csv.GetRecords<T>();
        foreach (var item in items)
        {
            var className = typeof(T).Name[..(typeof(T).Name!.Length - 3)]; //delete "Dto..."
            sb.AppendLine($"        context.Add(new {className}");
            sb.AppendLine("        {");
            foreach (var property in typeof(T).GetProperties())
            {
                var name = property.Name;
                var value = property.GetValue(item)?.ToString()?.Replace("\"", "\\\"");
                sb.AppendLine($"            {name} = \"{value}\",");
            }
            sb.AppendLine($"            Price = {Random.Shared.Next(1000, 30000)},");
            sb.AppendLine("        });");
            
        }
    }
    
}
public record CaseDto(string PartType,string Name,string Image,string Url,string Size);
public record CoolerDto(string PartType,string Name,string Image,string Url);
public record CpuDto(string PartType,string Name,string Image,string Url,string Brand,string Socket,string Speed,string CoreCount,string ThreadCount,string Power);
public record GpuDto(string PartType,string Name,string Image,string Url,string Brand,string Vram,string Resolution,string Power); 
public record MemoryDto(string PartType,string Name,string Image,string Url,string Type,string Size);
public record MotherboardDto(string PartType,string Name,string Image,string Url,string Brand,string Socket,string Size);
public record PsuDto(string PartType,string Name,string Image,string Url,string Power,string Size);
public record StorageDto(string PartType,string Name,string Image,string Url,string Type,string Space);

