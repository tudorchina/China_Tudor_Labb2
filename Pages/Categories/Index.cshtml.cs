using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using China_Tudor_Labb2.Data;
using China_Tudor_Labb2.Models;
using China_Tudor_Labb2.Models.ViewModels;

namespace China_Tudor_Labb2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly China_Tudor_Labb2.Data.China_Tudor_Labb2Context _context;

        public IndexModel(China_Tudor_Labb2.Data.China_Tudor_Labb2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData
            {
                Categories = await _context.Category
                    .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                    .ThenInclude(b => b.Author)
                    .AsNoTracking()
                    .ToListAsync()
            };

            if (id != null)
            {
                CategoryID = id.Value;
                var selectedCategory = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();
                CategoryData.Books = selectedCategory.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}
