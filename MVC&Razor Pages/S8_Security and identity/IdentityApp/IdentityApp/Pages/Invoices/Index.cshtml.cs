using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityApp;
using IdentityApp.Data;

namespace IdentityApp.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly IdentityApp.Data.IdentityAppContext _context;

        public IndexModel(IdentityApp.Data.IdentityAppContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Invoice != null)
            {
                Invoice = await _context.Invoice.ToListAsync();
            }
        }
    }
}
