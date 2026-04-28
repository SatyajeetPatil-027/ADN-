using campusMaintainance_Tracker.Data;
using campusMaintainance_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace campusMaintainance_Tracker.Controllers
{
    public class MaintenanceRequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MaintenanceRequestController> _logger;
        private readonly IMemoryCache _cache;

        public MaintenanceRequestController(
            ApplicationDbContext context,
            ILogger<MaintenanceRequestController> logger,
            IMemoryCache cache)
        {
            _context = context;
            _logger = logger;
            _cache = cache;
        }

        private void LoadDropdownData()
        {
            ViewBag.Categories = new List<string>
            {
                "Hardware",
                "Software",
                "Network",
                "Electrical",
                "Classroom",
                "Lab",
                "Other"
            };

            ViewBag.Priorities = new List<string>
            {
                "Low",
                "Medium",
                "High"
            };

            ViewBag.StatusList = new List<string>
            {
                "Pending",
                "In Progress",
                "Completed",
                "Rejected"
            };
        }

        public async Task<IActionResult> Index(string searchText, string statusFilter, string categoryFilter)
        {
            var requests = _context.MaintenanceRequests.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                requests = requests.Where(r =>
                    r.Title.Contains(searchText) ||
                    r.Description.Contains(searchText) ||
                    r.Location.Contains(searchText));
            }

            if (!string.IsNullOrEmpty(statusFilter))
            {
                requests = requests.Where(r => r.Status == statusFilter);
            }

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                requests = requests.Where(r => r.Category == categoryFilter);
            }

            ViewBag.SearchText = searchText;
            ViewBag.StatusFilter = statusFilter;
            ViewBag.CategoryFilter = categoryFilter;

            ViewBag.TotalRequests = await _context.MaintenanceRequests.CountAsync();
            ViewBag.PendingRequests = await _context.MaintenanceRequests.CountAsync(r => r.Status == "Pending");
            ViewBag.InProgressRequests = await _context.MaintenanceRequests.CountAsync(r => r.Status == "In Progress");
            ViewBag.CompletedRequests = await _context.MaintenanceRequests.CountAsync(r => r.Status == "Completed");

            LoadDropdownData();

            var result = await requests
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();

            return View(result);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.MaintenanceRequests
                .FirstOrDefaultAsync(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        public IActionResult Create()
        {
            LoadDropdownData();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaintenanceRequest request)
        {
            if (ModelState.IsValid)
            {
                request.RequestDate = DateTime.Now;

                _context.MaintenanceRequests.Add(request);
                await _context.SaveChangesAsync();

                _logger.LogInformation("New maintenance request created: {Title}", request.Title);

                return RedirectToAction(nameof(Index));
            }

            LoadDropdownData();
            return View(request);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.MaintenanceRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            LoadDropdownData();
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MaintenanceRequest request)
        {
            if (id != request.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Maintenance request updated: {RequestId}", request.RequestId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceRequestExists(request.RequestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            LoadDropdownData();
            return View(request);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.MaintenanceRequests
                .FirstOrDefaultAsync(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.MaintenanceRequests.FindAsync(id);

            if (request != null)
            {
                _context.MaintenanceRequests.Remove(request);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Maintenance request deleted: {RequestId}", id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceRequestExists(int id)
        {
            return _context.MaintenanceRequests.Any(r => r.RequestId == id);
        }
    }
}