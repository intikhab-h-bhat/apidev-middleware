using Api.Dev.Middleware.Application.Dtos.ClinicDto;
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
    public class ClinicService : IClinic
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public async Task<bool> AddClinicAsync(ClinicDto clinicDto)
        {
            

            Clinic addClinic = new Clinic();
            addClinic.ClinicName = clinicDto.ClinicName;
            addClinic.Address = clinicDto.Address;
            addClinic.Email = clinicDto.Email;
            addClinic.ContactNumber = clinicDto.ContactNumber;
            addClinic.Website = clinicDto.Website;


            return await _clinicRepository.AddClinicAsync(addClinic);


            
        }

        public async Task<bool> DeleteClinicAsync(int id)
        {

            return await  _clinicRepository.DeleteClinicAsync(id);          

           
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

        public async Task<ClinicDto> GetClinicByIdAsync(int id)
        {
            var getClinic = await _clinicRepository.GetClinicByIdAsync(id);

            if (getClinic == null)
                return null;

            var getClinicDto = new ClinicDto
            {
                ClinicID=getClinic.ClinicID,
                ClinicName=getClinic.ClinicName,
                Address=getClinic.Address,
                ContactNumber=getClinic.ContactNumber,
                Email=getClinic.ContactNumber
            };

            return getClinicDto;
           
        }

        public async Task<ClinicDto> UpdateClinicAsync(int id, ClinicDto clinicDto)
        {
            var existingClinic = await _clinicRepository.GetClinicByIdAsync(id);

            if (existingClinic == null)
                return null;

            existingClinic.ClinicName = clinicDto.ClinicName;
            existingClinic.ContactNumber = clinicDto.ContactNumber;
            existingClinic.Email = clinicDto.Email;
            existingClinic.Address = clinicDto.Address;
            existingClinic.Website = clinicDto.Website;


            var UpdateClinic = await _clinicRepository.UpdateClinicAsync(id, existingClinic);




            return clinicDto;
            
        }
    }
}
