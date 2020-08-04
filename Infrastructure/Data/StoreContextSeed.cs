using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data {
    public class StoreContextSeed {
        public static async Task SeedAsync (StoreContext context, ILoggerFactory loggerFactory) {
            try {
                if (!context.ProductBrands.Any ()) {
                    var brandsDate = File.ReadAllText ("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>> (brandsDate);
                    foreach (var item in brands) {
                        context.ProductBrands.Add (item);
                    }
                    await context.SaveChangesAsync ();
                }
                if (!context.ProductTypes.Any ()) {
                    var TypesDate = File.ReadAllText ("../Infrastructure/Data/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>> (TypesDate);
                    foreach (var item in Types) {
                        context.ProductTypes.Add (item);
                    }
                    await context.SaveChangesAsync ();
                }
                if (!context.Products.Any ()) {
                    var productsDate = File.ReadAllText ("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>> (productsDate);
                    foreach (var item in products) {
                        context.Products.Add (item);
                    }
                    await context.SaveChangesAsync ();
                }
            } catch (Exception e) {
                var logger = loggerFactory.CreateLogger<StoreContextSeed> ();
                logger.LogError (e.Message);
            }
        }
    }
}