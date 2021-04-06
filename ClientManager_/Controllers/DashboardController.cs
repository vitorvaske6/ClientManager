using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientManager_.Models;

namespace ClientManager_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardContext _context;

        public DashboardController(DashboardContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Dashboard>> GetDashboardAll()
        {
            var dashboardAll = await _context.DashboardItens.FindAsync();
            return dashboardAll;
        }

        [HttpGet("{id_dashboard}")]
        public async Task<ActionResult<Dashboard>> GetDashboardById(long id)
        {
            var dashboardById = await _context.DashboardItens.FindAsync(id);

            if (dashboardById == null)
            {
                return NotFound();
            }

            return dashboardById;
        }

        [HttpPut("{id_dashboard}")]
        public async Task<IActionResult> UpdateDashboard(long id, Dashboard dashboard)
        {
            if (id != dashboard.Id_dashboard)
            {
                return BadRequest();
            }

            var updateDashboard = await _context.DashboardItens.FindAsync(id);
            if (updateDashboard == null)
            {
                return NotFound();
            }

            updateDashboard.Servicos__dashboard = dashboard.Servicos__dashboard;
            updateDashboard.Total_dashboard = dashboard.Total_dashboard;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!DashboardExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Dashboard>> CreateDashboard(Dashboard dashboard)
        {
            var createDashboard = new Dashboard
            {
                Servicos__dashboard = dashboard.Servicos__dashboard,
                Total_dashboard = dashboard.Total_dashboard
            };

            _context.DashboardItens.Add(createDashboard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetDashboardById),
                new { id = dashboard.Id_dashboard });
        }

        [HttpDelete("{id_dashboard}")]
        public async Task<IActionResult> DeleteDashboard(long id)
        {
            var deleteDashboard = await _context.DashboardItens.FindAsync(id);

            if (deleteDashboard == null)
            {
                return NotFound();
            }

            _context.DashboardItens.Remove(deleteDashboard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DashboardExists(long id) =>
             _context.DashboardItens.Any(e => e.Id_dashboard == id);

    }
}
