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

        public async Task<bool> DeleteClinicAsync(int id)
        {
            var getClinic = await _context.Clinics.FirstOrDefaultAsync(c => c.ClinicID == id);
            if (getClinic == null)
                return false;

            _context.Clinics.Remove(getClinic);
            await _context.SaveChangesAsync();

            return true;
           
        }

        public async Task<IEnumerable<Clinic>> GeatAllClinicAsync()
        {
            var allClinics = await _context.Clinics.ToListAsync();

            return allClinics;
        }

        public async Task<Clinic> GetClinicByIdAsync(int id)
        {
            var getClinic = await _context.Clinics.FirstOrDefaultAsync(c=> c.ClinicID==id);

            if (getClinic == null)
                return null;

            return getClinic;
        }

        public async Task<Clinic> UpdateClinicAsync(int id, Clinic clinic)
        {
            var existingClinic = await _context.Clinics.FirstOrDefaultAsync(c=>c.ClinicID==id);

            if (existingClinic == null)
            {
                return null; 
            }

            // Update fields
            existingClinic.ClinicName = clinic.ClinicName;
            existingClinic.ContactNumber = clinic.ContactNumber;
            existingClinic.Email = clinic.Email;
            existingClinic.Address = clinic.Address;
            existingClinic.Website = clinic.Website;

            _context.Clinics.Update(existingClinic);
            await _context.SaveChangesAsync();

            return existingClinic; // Return updated entity

        }
    }
}
