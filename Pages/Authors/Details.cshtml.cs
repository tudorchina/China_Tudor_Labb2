using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using China_Tudor_Labb2.Data;
using China_Tudor_Labb2.Models;

namespace China_Tudor_Labb2.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly China_Tudor_Labb2.Data.China_Tudor_Labb2Context _context;

        public DetailsModel(China_Tudor_Labb2.Data.China_Tudor_Labb2Context context)
        {
            _context = context;
        }

        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }
            else
            {
                Author = author;
            }
            return Page();
        }
    }
}
