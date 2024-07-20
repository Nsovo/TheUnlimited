using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheUnlimited_Backend_.Models;
using TheUnlimited_Backend_.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class CommissionController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly CommissionService _commissionService;
    private readonly CommissionCalculation _commissionCalculation;

    public CommissionController(AppDbContext context, CommissionService commissionService, CommissionCalculation commissionCalculation)
    {
        _context = context;
        _commissionService = commissionService;
        _commissionCalculation = commissionCalculation;
    }

    [HttpGet("debug/commissions")]
    public async Task<ActionResult<IEnumerable<Commission>>> GetAllCommissions()
    {
        var commissions = await _context.Commissions
            .Include(c => c.Agent)
            .Include(c => c.Product)
            .ToListAsync();

        return Ok(commissions);
    }

    [HttpGet("debug/productsales")]
    public async Task<ActionResult<IEnumerable<ProductSales>>> GetAllProductSales()
    {
        var productSales = await _context.ProductSales
            .Include(ps => ps.Agent)
            .Include(ps => ps.Product)
            .ToListAsync();

        return Ok(productSales);
    }

    [HttpGet("CalculateCommission")]
    public async Task<ActionResult<IEnumerable<object>>> CalculateCommissions()
    {
        var productSales = await _context.ProductSales
            .Include(ps => ps.Agent)
            .Include(ps => ps.Product)
            .ToListAsync();

        if (productSales == null || !productSales.Any())
        {
            return NotFound("No product sales found.");
        }

        var commissions = productSales
            .GroupBy(ps => ps.Agent)
            .Select(group => new
            {
                AgentID = group.Key.AgentID,
                AgentName = $"{group.Key.Name} {group.Key.Surname}",
                CommissionAmount = CalculateCommission(group.Sum(ps => ps.SalesAmount)),
                CommissionDate = DateTime.Now // or set the appropriate commission date
            })
            .ToList();

        return Ok(commissions);
    }

    private decimal CalculateCommission(decimal salesAmount)
    {
        // Example commission calculation logic
        decimal commissionRate = 0.10m; // 10%
        return salesAmount * commissionRate;
    }

    [HttpGet("GetSalesRankings")]
    public async Task<ActionResult<IEnumerable<object>>> GetSalesRankings()
    {
        var productSales = await _context.ProductSales
            .Include(ps => ps.Agent)
            .ToListAsync();

        if (productSales == null || !productSales.Any())
        {
            return NotFound("No product sales found.");
        }

        var salesRankings = productSales
            .GroupBy(ps => ps.Agent)
            .Select(group => new
            {
                AgentID = group.Key.AgentID,
                AgentName = $"{group.Key.Name} {group.Key.Surname}",
                TotalSales = group.Sum(ps => ps.SalesAmount)
            })
            .OrderByDescending(agent => agent.TotalSales)
            .ToList();

        return Ok(salesRankings);
    }

    [HttpGet("GetAllCommissions")]
    public ActionResult<IEnumerable<Commission>> GetCommissions()
    {
        try
        {
            var commissions = _commissionService.GetAllCommissions(); // Assuming a method to get all commissions
            return Ok(commissions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("CalculateCommissions")]
    public async Task<IActionResult> CalculateCommission()
    {
        try
        {
            var agents = await _context.Agents.ToListAsync();

            foreach (var agent in agents)
            {
                var sales = await _context.ProductSales
                    .Where(ps => ps.AgentID == agent.AgentID)
                    .ToListAsync();

                var salesCount = sales.Count;

                var commissions = await _context.Commissions
                    .Where(c => c.AgentID == agent.AgentID)
                    .ToListAsync();

                foreach (var commission in commissions)
                {
                    commission.SalesCount = salesCount;
                    commission.CalculateCommission();
                }
            }

            await _context.SaveChangesAsync();

            return Ok("Commissions calculated for all agents.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("CalculateCommission/{agentId}")]
    public async Task<IActionResult> GetCommission(int agentId)
    {
        try
        {
            var commissions = await _context.Commissions
                .Include(c => c.Agent)
                .Include(c => c.Product)
                    .ThenInclude(p => p.ProductCategory)
                .Include(c => c.ProductSales)
                .Where(c => c.AgentID == agentId)
                .ToListAsync();

            if (commissions == null || !commissions.Any())
            {
                return NotFound();
            }

            foreach (var commission in commissions)
            {
                commission.CalculateCommission();
            }

            return Ok(commissions);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("UpdateCommissionStatus/{commissionId}")]
    public async Task<IActionResult> UpdateCommissionStatus(int commissionId, [FromBody] int statusId)
    {
        try
        {
            var commission = await _context.Commissions.FindAsync(commissionId);

            if (commission == null)
            {
                return NotFound();
            }

            commission.CommissionStatusID = statusId;
            await _context.SaveChangesAsync();

            return Ok(commission);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("Commission/{agentId}")]
    public async Task<IActionResult> GetCommissionAsPerAgent(int agentId)
    {
        try
        {
            // Fetch all ProductSales entries for the specified agent
            var sales = await _context.ProductSales
                .Where(ps => ps.AgentID == agentId)
                .ToListAsync();

            // Group sales by agent and count the number of sales
            var salesCount = sales.Count;

            // Fetch commissions for the specified agent
            var commissions = await _context.Commissions
                .Include(c => c.Agent)
                .Include(c => c.Product)
                    .ThenInclude(p => p.ProductCategory)
                .Include(c => c.ProductSales)
                .Where(c => c.AgentID == agentId)
                .ToListAsync();

            if (commissions == null || !commissions.Any())
            {
                return NotFound();
            }

            // Set SalesCount for each commission and calculate commission
            foreach (var commission in commissions)
            {
                commission.SalesCount = salesCount;
                commission.CalculateCommission();
            }

            return Ok(commissions);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}



