using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListMVCCore.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async void OnGet(int id)
        {
            Book = await db.Books.FindAsync(id);
        }
    }
}
