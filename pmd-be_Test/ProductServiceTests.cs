using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pmd_be.Models;
using pmd_be.Services;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using pmd_be.Dto;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq.EntityFrameworkCore;

namespace pmd_be_Test;

[TestClass]
public class ProductServiceTests
{

    private MockRepository mockRepository;
    private PmdDbContext _context;
    private Mock<ILogger<ProductService>> _mockLogger;
    private ProductService _productService;
    private static bool runOnce = false;

    [TestInitialize]
    public async Task Setup()
    {
        var options = new DbContextOptionsBuilder<PmdDbContext>()
            .UseInMemoryDatabase(databaseName: "ProductsDb")
            .Options;
        _context = new PmdDbContext(options);
       if(!runOnce)
        {

            var products = new Product[]
            {
            new Product{ Id = new Guid("34c58bee-7c66-4c35-92fa-78e5e27b3e97"), Name = "Product 01", Code = "NA74-7443H", Price = 22.85M, SKU = "837462-A1", StockQuantity = 89, DateAdded =  DateTimeOffset.Parse("2023-09-19T13:20:02.289Z"), Category = 1},
            new Product{ Id = new Guid("e96a6ce2-eddf-4e0e-aeae-1f98e168ffd2"), Name = "Product 02", Code = "KGT8-UH66W", Price = 12.85M, SKU = "493857-B5", StockQuantity = 132, DateAdded =  DateTimeOffset.Parse("2022-09-19T13:20:02.289Z"), Category = 2},
            new Product{ Id = new Guid("62480b14-a661-41bf-a8e0-736dc46f709a"), Name = "Product 03", Code = "DELT-8A223", Price = 24.85M, SKU = "209374-C9", StockQuantity = 194, DateAdded =  DateTimeOffset.Parse("2021-09-19T13:20:02.289Z"), Category = 3},
            new Product{ Id = new Guid("1f11fe5d-7359-4ffe-aca7-7ff75c95a6e8"), Name = "Product 04", Code = "90TE-XZ34T", Price = 42.65M, SKU = "745839-D3", StockQuantity = 10, DateAdded =  DateTimeOffset.Parse("2024-09-19T13:20:02.289Z"), Category = 4},
            new Product{ Id = new Guid("f304fa61-5301-4a45-a603-5e4ca4ab4839"), Name = "Product 05", Code = "GOA7-RR93T", Price = 22.35M, SKU = "659472-E7", StockQuantity = 99, DateAdded =  DateTimeOffset.Parse("2024-03-19T13:20:02.289Z"), Category = 5},
            new Product{ Id = new Guid("4f051576-87c8-4913-8e3a-a1dca6caa5bc"), Name = "Product 06", Code = "J8HY-TR56L", Price = 35.92M, SKU = "837462-A1", StockQuantity = 54, DateAdded = DateTimeOffset.Parse("2024-09-01T12:20:02.289Z"), Category = 3},
            };

            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();
            runOnce = true;
        }
        mockRepository = new MockRepository(MockBehavior.Strict);
        _mockLogger = mockRepository.Create<ILogger<ProductService>>();
        _productService = new ProductService(_context, _mockLogger.Object);
    }

    [TestMethod]
    public async Task GetAll_ShouldReturnAllProducts()
    {
        // Arrange
        // Act
        var result = await _productService.GetAll();

        // Assert
        Assert.AreEqual(6, result.Count());
    }

    [TestMethod]
    public async Task GetProduct_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange

        // Act
        var result = await _productService.GetProduct(new Guid("34c58bee-7c66-4c35-92fa-78e5e27b3e97"));

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Product 01", result.Name);
    }

    [TestMethod]
    public async Task DeleteProduct_ShouldReturnTrue_WhenProductIsDeleted()
    {
        // Arrange

        // Act
        var result = await _productService.DeleteProduct(new Guid("1f11fe5d-7359-4ffe-aca7-7ff75c95a6e8"));

        // Assert
        Assert.IsTrue(result);
    }

    // Add more tests for other methods like AddProduct, GetProductsByAddDate, GetProductsByCategory, and GetProductsPaged

    // Example:
    [TestMethod]
    public async Task AddProduct_ShouldAddProductAndReturnViewDto()
    {
        // Arrange
        var newProduct = new ProductCreateDto { Name = "Product 15", Code = "U3RK-BH77P", Price = 29.99M, SKU = "948572-J8", StockQuantity = 76, Category = 5 };

        // Act
        var result = await _productService.AddProduct(newProduct);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(newProduct.Name, result.Name);
    }
}

