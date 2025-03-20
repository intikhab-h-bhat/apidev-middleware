using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Domain.Interfaces;
using Api.Dev.Middleware.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Infrastructure.Repositories
{
 

    public class StaffReppository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;
        public StaffReppository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Staff> AddStaffAsync(Staff staff)
        {

                _context.Staff.AddAsync(staff);
                await _context.SaveChangesAsync();

                 return staff;



        }
    }
}
