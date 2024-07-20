using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheUnlimited_Backend_.Models;


[ApiController]
[Route("api/[controller]")]
public class ReportController : Controller
{
    private readonly AppDbContext _context;

    public ReportController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("debug/monthlysalescomparison")]
    public async Task<ActionResult<object>> GetMonthlySalesComparison()
    {
        //var currentMonthSales = await _context.ProductSales
        //    .Where(ps => ps.SalesDate.Month == DateTime.Now.Month && ps.SalesDate.Year == DateTime.Now.Year)
        //    .SumAsync(ps => ps.SalesAmount);

        var currentMonth = 12; // December
        var currentYear = 2023;
        var currentMonthSales = await _context.ProductSales
            .Where(ps => ps.SalesDate.Month == currentMonth && ps.SalesDate.Year == currentYear)
            .SumAsync(ps => ps.SalesAmount);


        var previousMonthSales = await _context.ProductSales
            .Where(ps => ps.SalesDate.Month == DateTime.Now.AddMonths(-1).Month && ps.SalesDate.Year == DateTime.Now.AddMonths(-1).Year)
            .SumAsync(ps => ps.SalesAmount);

        var result = new MonthlySalesComparison
        {
            CurrentMonthSales = currentMonthSales,
            PreviousMonthSales = previousMonthSales,
            PercentageChange = (previousMonthSales != 0) ? (currentMonthSales - previousMonthSales) / previousMonthSales * 100 : 0
        };

        return Ok(result);
    }

    [HttpGet("debug/dailysalescomparison")]
    public async Task<ActionResult<object>> GetDailySalesComparison()
    {
        var specificDate = new DateTime(2023, 08, 18); // Replace with your desired date
        var currentDaySales = await _context.ProductSales
            .Where(ps => ps.SalesDate.Date == specificDate)
            .SumAsync(ps => ps.SalesAmount);

        var pastWeekStart = specificDate.AddDays(-6);
        var pastWeekSales = await _context.ProductSales
            .Where(ps => ps.SalesDate >= pastWeekStart && ps.SalesDate < specificDate)
            .GroupBy(ps => ps.SalesDate.Date)
            .Select(g => new DailySalesData
            {
                Date = g.Key,
                SalesAmount = g.Sum(ps => ps.SalesAmount)
            })
            .OrderBy(s => s.Date)
            .ToListAsync();

        var result = new DailySalesComparison
        {
            CurrentDaySales = currentDaySales,
            PastWeekSales = pastWeekSales
        };

        return Ok(result);
    }


    [HttpGet("debug/mostsalesbycategory")]
    public async Task<ActionResult<IEnumerable<object>>> GetMostSalesByCategory()
    {
        var salesByCategory = await _context.ProductSales
            .GroupBy(ps => ps.Product.ProductCategory)
            .Select(g => new SalesByCategory
            {
                Category = g.Key,
                SalesAmount = g.Sum(ps => ps.SalesAmount)
            })
            .OrderByDescending(s => s.SalesAmount)
            .ToListAsync();

        return Ok(salesByCategory);
    }

    [HttpGet("debug/salestargets")]
    public async Task<ActionResult<IEnumerable<SalesTarget>>> GetSalesTargets()
    {
        var salesTargets = await _context.SalesTargets.ToListAsync();
        return Ok(salesTargets);
    }

    //[HttpGet("monthlysalescomparison")]
    //public async Task<ActionResult<object>> GetMonthlySales()
    //{
    //    var currentMonth = 12; // December
    //    var currentYear = 2023;

    //    var currentMonthSales = await _context.ProductSales
    //        .Where(ps => ps.SalesDate.Month == currentMonth && ps.SalesDate.Year == currentYear)
    //        .SumAsync(ps => ps.SalesAmount);

    //    var previousMonthSales = await _context.ProductSales
    //        .Where(ps => ps.SalesDate.Month == currentMonth - 1 && ps.SalesDate.Year == currentYear)
    //        .SumAsync(ps => ps.SalesAmount);

    //    var percentageChange = (previousMonthSales != 0)
    //        ? (currentMonthSales - previousMonthSales) / previousMonthSales * 100
    //        : 0;

    //    if (percentageChange > 0)
    //    {
    //        var result = new
    //        {
    //            CurrentMonthSales = currentMonthSales,
    //            PreviousMonthSales = previousMonthSales,
    //            PercentageChange = percentageChange
    //        };

    //        return Ok(result);
    //    }
    //    else
    //    {
    //        // Handle cases where there's no positive change (optional)
    //        return NotFound("No positive change in sales for the current month.");
    //    }
    //}

    [HttpGet("monthlysalescomparison")]
    public async Task<ActionResult<object>> GetSalesComparison()
    {
        var currentMonth = 12; // December
        var currentYear = 2023;

        // Fetch sales data for each month of the current year
        var monthlySales = await _context.ProductSales
            .Where(ps => ps.SalesDate.Year == currentYear)
            .GroupBy(ps => ps.SalesDate.Month)
            .Select(g => new
            {
                Month = g.Key,
                SalesAmount = g.Sum(ps => ps.SalesAmount)
            })
            .OrderBy(m => m.Month)
            .ToListAsync();

        // Find the current month's sales and the previous month's sales
        var currentMonthSales = monthlySales.FirstOrDefault(m => m.Month == currentMonth)?.SalesAmount ?? 0;
        var previousMonthSales = monthlySales.FirstOrDefault(m => m.Month == (currentMonth - 1))?.SalesAmount ?? 0;

        var percentageChange = (previousMonthSales != 0)
            ? (currentMonthSales - previousMonthSales) / previousMonthSales * 100
            : 0;

        if (percentageChange > 0)
        {

            var result = new
            {
                MonthlySales = monthlySales,
                CurrentMonthSales = currentMonthSales,
                PreviousMonthSales = previousMonthSales,
                PercentageChange = percentageChange
            };

            return Ok(result);

        }
        else
        {
            // Handle cases where there's no positive change (optional)
            return NotFound("No positive change in sales for the current month.");
        }
    }


    private class DailySalesData
    {
        public DateTime Date { get; set; }
        public decimal SalesAmount { get; set; }
    }

    private class DailySalesComparison
    {
        public decimal CurrentDaySales { get; set; }
        public List<DailySalesData> PastWeekSales { get; set; }
    }

    private class SalesByCategory
    {
        public ProductCategory Category { get; set; }
        public decimal SalesAmount { get; set; }
    }

    private class MonthlySalesComparison
    {
        public decimal CurrentMonthSales { get; set; }
        public decimal PreviousMonthSales { get; set; }
        public decimal PercentageChange { get; set; }
    }
}
