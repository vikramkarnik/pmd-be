using Microsoft.EntityFrameworkCore;
using pmd_be.Dto;
using pmd_be.Extensions;
using pmd_be.Models;
using System.Drawing.Printing;

namespace pmd_be.Services;

public interface IProductService
{
    Task<ProductViewDto?> AddProduct(ProductCreateDto product);
    Task<bool> DeleteProduct(Guid id);
    Task<IEnumerable<ProductViewDto>> GetAll();
    Task<ProductViewDto?> GetProduct(Guid id);
    Task<IEnumerable<KeyValuePair<string, int>>> GetProductsByAddDate();
    Task<IEnumerable<ProductByCategoryDto>> GetProductsByCategory();
    Task<PagedResponseDto<ProductViewDto>> GetProductsPaged(int pageNo, int size);
}

public class ProductService : IProductService
{
    //injecting db context here directly instead of creating a repository layer as it does not serve a purpose in this case
    private readonly PmdDbContext _context;
    private readonly ILogger<ProductService> _logger;
    public ProductService(PmdDbContext context, ILogger<ProductService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<ProductViewDto>> GetAll()
    {
        try
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();

            var resp = products.Select(x => x.ToProductView()).ToList();

            return resp;
        }
        catch(Exception ex) 
        {
            _logger.LogError(ex, "Error fetching products");
        }
        return Enumerable.Empty<ProductViewDto>();
    }

    public async Task<ProductViewDto?> AddProduct(ProductCreateDto product)
    {
        try
        {
            var item = product.ToProduct();

            await _context.Products.AddAsync(item);
            await _context.SaveChangesAsync();

            return item.ToProductView();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error adding product {product.Name}");
        }
        return null;
    }

    public async Task<ProductViewDto?> GetProduct(Guid id)
    {
        try
        {
            var product = await _context.Products.FindAsync(id);

            return product?.ToProductView();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"unable to find product with ID {id}");
        }

        return null;
    }


    public async Task<bool> DeleteProduct(Guid id)
    {
        try
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Unable to delete product with ID {id}");
        }
        return false;
    }

    public async Task<PagedResponseDto<ProductViewDto>> GetProductsPaged(int pageNumber, int pageSize)
    {
        //added basic paging, ideally should be with multiple filters and if random access is not allowed then keyset pagination as well
        try
        {
            var totalRecords = await _context.Products.AsNoTracking().CountAsync();
            var products = await _context.Products
                .AsNoTracking()
                .OrderBy(x => x.DateAdded)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var data = products.Select(x => x.ToProductView());

            var resp = new PagedResponseDto<ProductViewDto>(data, pageNumber, pageSize, totalRecords);

            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "unable to fetch requested products");
        }
        return new PagedResponseDto<ProductViewDto>(Enumerable.Empty<ProductViewDto>(), pageNumber, pageSize, 0);
    }

    public async Task<IEnumerable<ProductByCategoryDto>> GetProductsByCategory()
    {
        try
        {
            var products = await _context.Products
                .AsNoTracking()
                .GroupBy(x => x.Category)
                .Select(x => new ProductByCategoryDto { Category = ((Category)x.Key).ToString(), Count = x.Count() })
                .ToListAsync();


            return products;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "unable to fetch requested products by category");
        }
        return Enumerable.Empty<ProductByCategoryDto>();
    }

    public async Task<IEnumerable<KeyValuePair<string, int>>> GetProductsByAddDate()
    {
        try
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(x => x.DateAdded > new DateTimeOffset(DateTimeOffset.UtcNow.Year, 1, 1,0,0,0,TimeSpan.Zero))
                .ToListAsync();

            var thisYear = products.Count;

            var thisMonth = products.Where(x => x.DateAdded > new DateTimeOffset(DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month, 1, 0, 0, 0, TimeSpan.Zero)).Count();
            var thisweek = products.Where(x => x.DateAdded > new DateTimeOffset(DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month, DateTimeOffset.UtcNow.Day - (int)DateTimeOffset.UtcNow.DayOfWeek, 0, 0, 0, TimeSpan.Zero)).Count();
            
            return new List<KeyValuePair<string, int>> 
            { 
                new KeyValuePair<string, int>("This Year", thisYear),
                new KeyValuePair<string, int>("This Month", thisMonth),
                new KeyValuePair<string, int>("This Week", thisweek)
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "unable to fetch requested products by add date");
        }
        return Enumerable.Empty<KeyValuePair<string, int>>();
    }
}
