using Microsoft.EntityFrameworkCore;
using MyDnsShop.Api.Infrastructure;

namespace MyDnsShop.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseMyDnsShopApi(this WebApplication app)
    {
        app.MapGet("/api/cases", async (MyDnsShopDbContext context) =>
        {
            var cases = await context.Cases.AsNoTracking().ToListAsync();
            return cases
                .Select(x => new Shared.Dto.CaseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartType = x.PartType,
                    Image = x.Image,
                    Url = x.Url,
                    Size = x.Size,
                    Price = x.Price

                });
        });
        app.MapGet("/api/coolers", async (MyDnsShopDbContext context) =>
        {
            var coolers = await context.Coolers.AsNoTracking().ToListAsync();
            return coolers
                .Select(x => new Shared.Dto.CoolerDto
                {
                    PartType = x.PartType,
                    Name = x.Name,
                    Image = x.Image,
                    Url = x.Url,
                    Price = x.Price
                });
        });
        app.MapGet("/api/cpus", async (MyDnsShopDbContext context) =>
        {
            var cpu = await context.Cpus.AsNoTracking().ToListAsync();
            return cpu
                .Select(x => new Shared.Dto.CpuDto
                {
                    PartType = x.PartType,
                    Name = x.Name,
                    Image = x.Image,
                    Url = x.Url,
                    Brand = x.Brand,
                    Socket = x.Socket,
                    Speed = x.Speed,
                    CoreCount = x.CoreCount,
                    ThreadCount = x.ThreadCount,
                    Power = x.Power,
                    Price = x.Price
                });
        });
        app.MapGet("/api/gpu", async (MyDnsShopDbContext context) =>
        {
            var gpu = await context.Gpus.AsNoTracking().ToListAsync();
            return gpu
                .Select(x => new Shared.Dto.GpuDto
                {
                    PartType = x.PartType,
                    Name = x.Name,
                    Image = x.Image,
                    Url = x.Url,
                    Brand = x.Brand,
                    Power = x.Power,
                    Vram = x.Vram,
                    Resolution = x.Resolution,
                    Price = x.Price
                });
        });
        app.MapGet("/api/memories", async (MyDnsShopDbContext context) =>
        {
            var memory = await context.Memories.AsNoTracking().ToListAsync();
            return memory
                .Select(x => new Shared.Dto.MemoryDto
                {
                    PartType = x.PartType,
                    Name = x.Name,
                    Image = x.Image,
                    Url = x.Name,
                    Type = x.Type,
                    Size = x.Size,
                    Price = x.Price
                });
        });
        app.MapGet("/api/motherboars", async (MyDnsShopDbContext context) =>
        {
            var motherboard = await context.Motherboards.AsNoTracking().ToListAsync();
            return motherboard
                .Select(x => new Shared.Dto.MotherboardDto
                {
                    PartType = x.PartType,
                    Name = x.Name,
                    Image = x.Image,
                    Url = x.Name,
                    Size = x.Size,
                    Brand = x.Brand,
                    Socket = x.Socket,
                    Price = x.Price
                });
        });
        app.MapGet("/api/psu", async (MyDnsShopDbContext context) =>
        {
            var psu = await context.Psus.AsNoTracking().ToListAsync();
            return psu
                .Select(x => new Shared.Dto.PsuDto
                {
                    PartType = x.PartType,
                    Name = x.Name,
                    Image = x.Image,
                    Url = x.Name,
                    Size = x.Size,
                    Power = x.Power,
                    Price = x.Price
                });
        });
        app.MapGet("/api/storages", async (MyDnsShopDbContext context) =>
        {
            var storage = await context.Storages.AsNoTracking().ToListAsync();
            return storage
                .Select(x => new Shared.Dto.StorageDto
                {
                    PartType = x.PartType,
                    Name = x.Name,
                    Image = x.Image,
                    Url = x.Name,
                    Type = x.Type,
                    Space = x.Space,
                    Price = x.Price
                });
        });
        return app;
    }
}