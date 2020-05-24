using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListMVCCore.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly  ApplicationDbContext _db;


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        public IEnumerable<Book> Books { get; set; }
    }
}