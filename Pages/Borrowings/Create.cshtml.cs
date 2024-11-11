﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using China_Tudor_Labb2.Data;
using China_Tudor_Labb2.Models;
using Microsoft.EntityFrameworkCore;

namespace China_Tudor_Labb2.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly China_Tudor_Labb2.Data.China_Tudor_Labb2Context _context;

        public CreateModel(China_Tudor_Labb2.Data.China_Tudor_Labb2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
                   .Include(b => b.Author)
                   .Select(x => new
                   {
                       x.ID,
                       BookFullName = x.Title + " - " + x.Author.LastName + " " +
   x.Author.FirstName
                   });
            ViewData["BookID"] = new SelectList(bookList, "ID",
"BookFullName");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID",
"FullName");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
