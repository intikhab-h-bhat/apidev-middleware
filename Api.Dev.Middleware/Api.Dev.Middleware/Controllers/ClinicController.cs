using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dev.Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : Controller
    {
        private readonly IClinic _clinicService;


        public ClinicController(IClinic clinicService)
        {
            _clinicService = clinicService;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClinicDto>>> GeatAllClinicAsync()
        {
            try
            {

                var allClinics = await _clinicService.GetAllClinicsAsync();
                if (allClinics == null)
                    return NotFound("No Record exists");

                return Ok(allClinics);
            }
            catch(Exception ex)
            {
                return NotFound(ex);

            }
            finally
            {

            }
        }



    }
}
