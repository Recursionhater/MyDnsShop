using Microsoft.EntityFrameworkCore;
using MyDnsShop.Api.Domain;

namespace MyDnsShop.Api.Infrastructure;

public class MyDnsShopDbContext(DbContextOptions<MyDnsShopDbContext> options) : DbContext(options)
{
   public DbSet<Case> Cases => Set<Case>();
   public DbSet<Cooler> Coolers => Set<Cooler>();
   public DbSet<Cpu> Cpus => Set<Cpu>();
   public DbSet<Gpu> Gpus => Set<Gpu>();
   public DbSet<Memory> Memories => Set<Memory>();
   public DbSet<Motherboard> Motherboards => Set<Motherboard>();
   public DbSet<Psu> Psus => Set<Psu>();
   public DbSet<Storage> Storages => Set<Storage>();
}