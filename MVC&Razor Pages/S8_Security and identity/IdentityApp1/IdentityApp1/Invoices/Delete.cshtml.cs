using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityApp1;
using IdentityApp1.Data.Migrations;

namespace IdentityApp1.Invoices
{
    public class DeleteModel : PageModel
    {
        private readonly IdentityApp1.Data.Migrations.IdentityAppContext _context;

        public DeleteModel(IdentityApp1.Data.Migrations.IdentityAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Invoice Invoice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FirstOrDefaultAsync(m => m.InvoiceId == id);

            if (invoice == null)
            {
                return NotFound();
            }
            else 
            {
                Invoice = invoice;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }
            var invoice = await _context.Invoice.FindAsync(id);

            if (invoice != null)
            {
                Invoice = invoice;
                _context.Invoice.Remove(Invoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
