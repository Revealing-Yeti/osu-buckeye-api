using osu_buckeye_api.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace osu_buckeye_api.Data;

public static class DbInitializer
{
    public static void Initialize(ModelBuilder builder)
    {
        builder.Entity<Item>().HasData(
            new Item("Scarlet Shirt", "Ohio State shirt", "Nike", 29.99m) { Id = 1 },
            new Item("Gray Shorts", "Ohio State shorts", "Nike", 44.99m) { Id = 2 }
        );
    }
}