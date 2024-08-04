using AutoMapper;
using Restaurant.DTOs;
using Restaurant.Models.Db;
using Restaurant.Repositories.Interfaces;
using Restaurant.Services.Interfaces;

namespace Restaurant.Services.Implements
{
    public class ProductSVC(IMapper mapper, IProductRES productRES) : IProductSVC
    {
        public ProductDTO? Add(ProductDTO productDTO)
        {
            var product = mapper.Map<Product>(productDTO);
            var addedProduct = productRES.Add(product);
            return mapper.Map<ProductDTO>(addedProduct);
        }

        public decimal? CaculteSellingUnitPrice(Guid id)
        {
            var product = productRES.GetById(id);
            if (product == null) return null;
            var percent = (100 - product.PercentDiscount) / 100m;
            decimal sellingUnitPrice = (percent * product.UnitPrice) - product.HardDiscount;
            return sellingUnitPrice < 0? 0 : sellingUnitPrice;
        }

        public bool Delete(Guid id)
        {
            return productRES.Delete(id);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = productRES.GetAll();
            return mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public IEnumerable<ProductDTO> GetAllAvailable()
        {
            var availableProducts = productRES.GetAllAvailable();
            return mapper.Map<IEnumerable<ProductDTO>>(availableProducts);
        }

        public ProductDTO? GetById(Guid id)
        {
            var existingProduct = productRES.GetById(id);
            return mapper.Map<ProductDTO>(existingProduct);
        }

        public ProductDTO? Update(ProductDTO productDTO, Guid id)
        {
            var product = mapper.Map<Product>(productDTO);
            var updatedProduct = productRES.Update(product, id);
            return mapper.Map<ProductDTO>(updatedProduct);
        }
    }
}
