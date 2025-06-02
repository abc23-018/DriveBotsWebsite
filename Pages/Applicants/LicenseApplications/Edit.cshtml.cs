using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DriveBotsWebsite.Models;
using DriveBotsWebsite.Services;

namespace DriveBotsWebsite.Pages.Applicants.LicenseApplications
{
    public class EditModel : PageModel
    {
        private readonly DriveBotsWebsite.Services.ApplicationDbContext _context;

        public EditModel(DriveBotsWebsite.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LicenseApplication LicenseApplication { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseapplication =  await _context.LicenseApplications.FirstOrDefaultAsync(m => m.Id == id);
            if (licenseapplication == null)
            {
                return NotFound();
            }
            LicenseApplication = licenseapplication;
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

            _context.Attach(LicenseApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicenseApplicationExists(LicenseApplication.Id))
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

        private bool LicenseApplicationExists(int id)
        {
            return _context.LicenseApplications.Any(e => e.Id == id);
        }
    }
}
