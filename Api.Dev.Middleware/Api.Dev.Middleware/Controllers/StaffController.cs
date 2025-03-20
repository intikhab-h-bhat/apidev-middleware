using Api.Dev.Middleware.Application.Dtos.StaffDto;
using Api.Dev.Middleware.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Dev.Middleware.Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private readonly IStaffService _staffService;
        private readonly ILogger<StaffController> _logger;
        public StaffController(IStaffService staffService,ILogger<StaffController> logger)
        {
            _staffService = staffService;
            _logger = logger;
            
        }


        [HttpPost]

        public async Task<ActionResult<StaffDto>> AddStaffAsync([FromBody] StaffDto staffDto)
        {
            try
            {

                if (staffDto==null)
                {
                    _logger.LogWarning("There is no Data to Add");

                    return BadRequest("There is no data to be added");
                }


                var addStaff = await _staffService.AddStaffAsync(staffDto);


                if(addStaff==null)
                {
                    _logger.LogError("staff not saved");
                }


                return Ok(addStaff);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;

            }

        }


    }
}
