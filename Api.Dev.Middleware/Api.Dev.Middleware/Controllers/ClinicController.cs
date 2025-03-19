using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Ui.ExceptionHandling;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dev.Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinic _clinicService;


        public ClinicController(IClinic clinicService)
        {
            _clinicService = clinicService;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClinicDto>>> GeatAllClinicsAsync()
        {
            try
            {

                var allClinics = await _clinicService.GetAllClinicsAsync();
                if (allClinics == null)
                // return NotFound("No Record Exists");
                {
                    throw new KeyNotFoundException($"No Clinic Found.");
                }

                return Ok(allClinics);
            }
            catch (Exception ex)
            {
                return NotFound(ex);

            }
            finally
            {

            }
        }

        [HttpPost]

        public async Task<ActionResult<bool>> AddClinicAsync([FromBody] ClinicDto clinicDto)
        {

            return await _clinicService.AddClinicAsync(clinicDto);
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClinicDto>> GetClinicByIdAsync(int id)
        {
            //try
            //{

                if (id <= 0)
                return BadRequest("The id must be greater than 0");

                var getClinic = await _clinicService.GetClinicByIdAsync(id);

                if (getClinic == null)
                // return NotFound($"Clinic with {id} not found");
                {
                    throw new NotFoundException($"Clinic with {id} not found");
                }


                return Ok(getClinic);
            //}
            //catch (Exception ex)
            //{
            //    //_logger.LogError(ex, "Error fetching Clinic details for ID {id}", id);
            //    return StatusCode(500, "An internal server error occurred.");
            //}


        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<bool>> DeleteClinicAsync(int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot bel less than or equal to 0");

            var status = await _clinicService.DeleteClinicAsync(id);

            if (status == false)
                return NotFound("clinic not found");

            return Ok(status);
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult<ClinicDto>> UpdateClinicAsync(int id, [FromBody] ClinicDto clinicDto)
        {

            if (id <= 0 || clinicDto==null)
            {
                return BadRequest();
            }

            var updateClinic = await _clinicService.UpdateClinicAsync(id, clinicDto);
            if (updateClinic == null)
                return NotFound();



            return Ok(updateClinic);


        }



    }
}
