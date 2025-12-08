using Contracts.Enums.Store;
using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models.Store.Common;
using DataLayer.Models.Store.Products;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DataLayer.Repositories.Store.Products
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly StoreDbContext _context;
        private readonly ILogger<ProductsRepository> _logger;
        public ProductsRepository(StoreDbContext context, ILogger<ProductsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<StoreOverviewModel> GetProductOverviewByGender(Genders gender)
        {
            try
            {
                return _context.Products
                    .Where(t => t.Gender == gender)
                    .Select(t => new StoreOverviewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Price = t.Price,
                        InStock = t.Variants.Any(v => v.Quantity > 0),
                        Category = t.Category,  
                        Gender = t.Gender
                    })
                    .AsNoTracking()
                    .ToList();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "A database error while retrieving T-shirt with Gender {Gender}", gender);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error in GetTShirtByGender{Gender}", gender);
                throw;
            }
        }

        public ProductsModel? GetById(int? id)
        {
            try
            {
                return _context.Products
                    .Include(t => t.Variants)
                    .AsNoTracking()
                    .FirstOrDefault(t => t.Id == id);
            }

            catch (SqlException ex)
            {
                _logger.LogError(ex, "A database error while retrieving T-shirt with ID {Id}", id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error in GetById({Id})", id);
                throw;
            }
        }

        public ProductsModel? UpdateStock(ProductsModel model)
        {
            try
            {
                var product = _context.Products
                    .Include(p => p.Variants)
                    .FirstOrDefault(p => p.Id == model.Id);

                if (product == null)
                {
                    return null;
                }

                foreach (var updatedVariant in model.Variants)
                {
                    var existingVariant = product.Variants
                        .FirstOrDefault(v => v.VariantId == updatedVariant.VariantId);

                    if (existingVariant != null)
                    {
                        existingVariant.Quantity = updatedVariant.Quantity;
                    }
                }
                _context.SaveChanges();
                return product;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Database error while retrieving product {Id}", model.Id);
                throw;
            }
        }
    }
}



