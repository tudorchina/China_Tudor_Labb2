﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using China_Tudor_Labb2.Data;
using China_Tudor_Labb2.Models;

namespace China_Tudor_Labb2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly China_Tudor_Labb2.Data.China_Tudor_Labb2Context _context;

        public EditModel(China_Tudor_Labb2.Data.China_Tudor_Labb2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = _context.Borrowing
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefault(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }

            var bookList = _context.Book
                .Include(b => b.Author)
                .Select(x => new
                {
                    x.ID,
                    BookFullName = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName
                });

            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}
