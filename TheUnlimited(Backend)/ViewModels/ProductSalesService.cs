using TheUnlimited_Backend_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Faker;
using Microsoft.EntityFrameworkCore;
using TheUnlimited_Backend_.Models;

namespace TheUnlimited_Backend_.ViewModels
{
    public class ProductSalesService
    {
        private readonly AppDbContext _context;
        private readonly IRepository _repository;
        private readonly DbContextOptions<AppDbContext> _options;

        public ProductSalesService(AppDbContext context, IRepository repository, DbContextOptions<AppDbContext> options)
        {
            _context = context;
            _repository = repository;
            _options = options;
        }

        public List<ProductSales> GenerateProductSales(int agentID, int numberOfSales)
        {
            var products = _context.Products.ToList(); // Fetch products from the database
            var salesChannels = _context.SalesChannels.ToList(); // Fetch sales channels from the database

            var productSalesFaker = new Faker<ProductSales>()
                .RuleFor(ps => ps.AgentID, f => agentID)
                .RuleFor(ps => ps.ProductID, f => f.PickRandom(products).ProductID)
                .RuleFor(ps => ps.SalesAmount, f => f.Finance.Amount(10, 500))
                .RuleFor(ps => ps.SalesDate, f => f.Date.Past(1))
                .RuleFor(ps => ps.SalesChannelID, f => f.PickRandom(salesChannels).SalesChannelID)
                .RuleFor(ps => ps.Agent, f => null) // Relationships handled later
                .RuleFor(ps => ps.Product, (f, ps) => products.Find(p => p.ProductID == ps.ProductID))
                .RuleFor(ps => ps.SalesChannel, (f, ps) => salesChannels.Find(s => s.SalesChannelID == ps.SalesChannelID));

            return productSalesFaker.Generate(numberOfSales);
        }


        public async Task<IEnumerable<ProductSales>> GetProductSales()
        {
            var productSales = new Faker<ProductSales>()
                .RuleFor(o => o.ProductSalesID, f => f.IndexFaker)
                .RuleFor(o => o.ProductID, f => f.Random.Number(1, 100))
                .RuleFor(o => o.SalesDate, f => f.Date.Past())
                .RuleFor(o => o.SalesAmount, f => f.Random.Decimal(1, 1000))
                .Generate(100);
            return productSales;
        }

        public async Task<IEnumerable<ProductSales>> GetProductSalesByAgentID(int AgentID)
        {
            return await _context.ProductSales.Where(x => x.AgentID == AgentID).ToListAsync();
        }

        public async Task<ProductSales> GetProductSalesByID(int ProductSalesID)
        {
            return await _context.ProductSales.FindAsync(ProductSalesID);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void AddProductSales(ProductSales productSales)
        {
            _repository.Add(productSales);
        }

        public void UpdateProductSales(ProductSales productSales)
        {
            _repository.Update(productSales);
        }

        public void DeleteProductSales(ProductSales productSales)
        {
            _repository.Delete(productSales);
        }
    }

}
