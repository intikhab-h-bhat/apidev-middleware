using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Services
{
    public class ClinicService : IClinic
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }


        public async Task<IEnumerable<ClinicDto>> GetAllClinicsAsync()
        {

            var allClinics = await _clinicRepository.GeatAllClinicAsync();
            var allClinicsDto = allClinics.Select(s => new ClinicDto
            {
                ClinicID = s.ClinicID,
                ClinicName=s.ClinicName,
                Address=s.Address,
                ContactNumber=s.ContactNumber,
                Email=s.Email
            });


            return allClinicsDto;

          
        }
    }
}
