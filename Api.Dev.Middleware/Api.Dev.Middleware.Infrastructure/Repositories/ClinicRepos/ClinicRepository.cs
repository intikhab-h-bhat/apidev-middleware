using Api.Dev.Middleware.Domain.Interfaces;
using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Dev.Middleware.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Dev.Middleware.Infrastructure.Repositories.ClinicRepos

{
    public class ClinicRepository : IClinicRepository
    {
        private readonly ApplicationDbContext _context;
        public ClinicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<bool> AddClinicAsync(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            await _context.SaveChangesAsync();

            return true;


        }

        public async Task<IEnumerable<Clinic>> GeatAllClinicAsync()
        {
            var allClinics = await _context.Clinics.ToListAsync();

            return allClinics;
        }
    }
}
