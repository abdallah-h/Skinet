using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data {
    /// <summary>
    /// Read json data from SeedData file, Deserialize it and add it to database
    /// </summary>
    public class StoreContextSeed {
        public static async Task SeedAsync (StoreContext context, ILoggerFactory loggerFactory) {
            try {
                string path = "../Infrastructure/Data/SeedData/";
                if (!context.ProductBrands.Any ()) {
                    var brandsDate = File.ReadAllText (path + "brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>> (brandsDate);
                    foreach (var item in brands) {
                        context.ProductBrands.Add (item);
                    }
                    await context.SaveChangesAsync ();
                }
                if (!context.ProductTypes.Any ()) {
                    var TypesDate = File.ReadAllText (path + "types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>> (TypesDate);
                    foreach (var item in Types) {
                        context.ProductTypes.Add (item);
                    }
                    await context.SaveChangesAsync ();
                }
                if (!context.Products.Any ()) {
                    var productsDate = File.ReadAllText (path + "products.json");
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