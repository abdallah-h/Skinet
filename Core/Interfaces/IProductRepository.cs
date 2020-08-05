using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces {
    /// <summary>
    /// Interface for ProductRepository
    /// </summary>
    public interface IProductRepository {

        Task<Product> GetProductByIdAsync (int id);
        Task<IReadOnlyList<Product>> GetProductsAsync ();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync ();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync ();

    }
}