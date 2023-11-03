using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grumeza_Lab2.Data;
using Grumeza_Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Configuration;

namespace Grumeza_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Grumeza_Lab2.Data.Grumeza_Lab2Context _context;

        public IndexModel(Grumeza_Lab2.Data.Grumeza_Lab2Context context)
            
        {
            _context = context;
            AuthorsList = new List<Authors>();
            AuthorList = new SelectList(new List<Authors>());


        }

        public List<Authors> AuthorsList { get; set; }
        
        public int? SelectedAuthorID { get; set; }

        public IList<Book> Book { get;set; } = default!;
        public SelectList AuthorList { get; set; }

        public async Task OnGetAsync()
            
        {
            if (_context.Authors != null)
                AuthorsList = await _context.Authors
                    .ToListAsync();



            if (_context.Book != null)
            {
                Book = await _context.Book
                    .Include(b => b.Publisher)
                    .ToListAsync();
            }
            AuthorList = new SelectList(AuthorsList, "ID", "FirstName", "LastName");

        }
    }
}
