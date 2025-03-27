using Microsoft.EntityFrameworkCore;
using osu_buckeye_api.Domain.Catalog;

namespace osu_buckeye_api.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    public DbSet<Item> Items { get; set; }
}