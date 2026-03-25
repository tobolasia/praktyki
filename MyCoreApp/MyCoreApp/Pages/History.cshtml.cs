using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyCoreApp.Data;
using MyCoreApp.Models;

namespace MyCoreApp.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly AppDbContext _db;

        public HistoryModel(AppDbContext db)
        {
            _db = db;
        }

        public List<WeatherHistory> Records { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? City { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? DateFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? DateTo { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; } = "date_desc";

        public async Task OnGet()
        {
            var query = _db.WeatherHistories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(City))
            {
                query = query.Where(x => x.City.Contains(City));
            }

            if (DateFrom.HasValue)
            {
                query = query.Where(x => x.CreatedAt >= DateFrom.Value);
            }

            if (DateTo.HasValue)
            {
                query = query.Where(x => x.CreatedAt <= DateTo.Value.AddDays(1));
            }

            query = SortBy switch
            {
                "date_asc" => query.OrderBy(x => x.CreatedAt),
                "temp_desc" => query.OrderByDescending(x => x.Temperature),
                "temp_asc" => query.OrderBy(x => x.Temperature),
                _ => query.OrderByDescending(x => x.CreatedAt)
            };

            Records = await query.ToListAsync();
        }
    }
}