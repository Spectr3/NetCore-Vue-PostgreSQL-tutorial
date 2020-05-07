using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialisation
{
    public static class ProductMapper
    {
        /// <summary>
        /// Maps a product data model to a productmodel view model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductModel SerialiseProductModel(Data.Models.Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                Description = product.Description,
                IsArchived = product.IsArchived,
                IsTaxable = product.IsTaxable,
                Name = product.Name,
                Price = product.Price,
                UpdatedOn = product.UpdatedOn
            };
        }
        
        /// <summary>
        /// Maps a productmodel view model to a product data model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Data.Models.Product SerialiseProductModel(ProductModel product)
        {
            return new Data.Models.Product
            {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                Description = product.Description,
                IsArchived = product.IsArchived,
                IsTaxable = product.IsTaxable,
                Name = product.Name,
                Price = product.Price,
                UpdatedOn = product.UpdatedOn
            };
        }
    }
}