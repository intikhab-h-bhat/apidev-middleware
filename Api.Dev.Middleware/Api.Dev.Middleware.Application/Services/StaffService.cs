using Api.Dev.Middleware.Application.Dtos.StaffDto;
using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        public StaffService(IStaffRepository staffRepository)
        {

            _staffRepository = staffRepository;

        }



        public async Task<StaffDto> AddStaffAsync(StaffDto staffDto)
        {
            var addStaff = new Staff
            {
                StaffName = staffDto.StaffName,
                ClinicID = staffDto.ClinicID,
                Role = staffDto.Role,
                ContactNumber = staffDto.ContactNumber,
                Email = staffDto.Email,
                AssignedTests = staffDto.AssignedTests,
                DateOfJoining=staffDto.DateOfJoining,
                

            };


             await _staffRepository.AddStaffAsync(addStaff);


            return staffDto;


        }
    }
}
