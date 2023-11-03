using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Grumeza_Lab2.Data;
using Grumeza_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Grumeza_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Grumeza_Lab2.Data.Grumeza_Lab2Context _context;

        public CreateModel(Grumeza_Lab2.Data.Grumeza_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
            AuthorList = new SelectList(_context.Authors, "ID", "LastName");
            
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        public SelectList AuthorList { get; set; } = default!;
        public int SelectedAuthorId { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Book == null || Book == null)
            {
                return Page();
            }
            Book.AuthorID = SelectedAuthorId;

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
           
        }

    }
}
