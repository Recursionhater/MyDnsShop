using MyDnsShop.Shared.Dto;
using Refit;

namespace MyDnsShop.Client;

public interface IMyDnsShopClient
{
    [Get("/api/cases")]
    Task<IReadOnlyCollection<CaseDto>> GetCasesAsync();
    
    [Get("/api/coolers")]
    Task<IReadOnlyCollection<CoolerDto>> GetCoolersAsync();
    
    [Get("/api/cpus")]
    Task<IReadOnlyCollection<CpuDto>> GetCpuAsync();
    
    [Get("/api/gpu")]
    Task<IReadOnlyCollection<GpuDto>> GetGpuAsync();
    
    [Get("/api/memories")]
    Task<IReadOnlyCollection<MemoryDto>> GetMemoriesAsync();
    
    [Get("/api/motherboars")]
    Task<IReadOnlyCollection<MotherboardDto>> GetMotherboardsAsync();
    
    [Get("/api/psu")]
    Task<IReadOnlyCollection<PsuDto>> GetPsuAsync();
    
    [Get("/api/storages")]
    Task<IReadOnlyCollection<StorageDto>> GetStoragesAsync();
    
}