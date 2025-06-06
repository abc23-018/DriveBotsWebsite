﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DriveBotsWebsite.Models;
using DriveBotsWebsite.Services;

namespace DriveBotsWebsite.Pages.Applicants.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly DriveBotsWebsite.Services.ApplicationDbContext _context;

        public IndexModel(DriveBotsWebsite.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointments.ToListAsync();
        }
    }
}
