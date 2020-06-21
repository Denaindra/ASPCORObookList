using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListMVCCore.Models;
using BookListMVCCore.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListMVCCore.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext db;
        private readonly ILoading loading;
        public EditModel(ApplicationDbContext db,ILoading loading)
        {
            this.db = db;
            this.loading = loading;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async void OnGet(int id)
        {
            Book = await db.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            loading.GetName();

            if (ModelState.IsValid) 
            {
              var bookFromdb = await db.Books.FindAsync(Book.Id);
                bookFromdb.Name = Book.Name;
                bookFromdb.ISBN = Book.ISBN;
                bookFromdb.Author = Book.Author;
                await db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
