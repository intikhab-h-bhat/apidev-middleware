using Api.Dev.Middleware.Application.Dtos.StaffDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Interfaces
{
   public interface IStaffService
    {

        Task<StaffDto> AddStaffAsync(StaffDto staffDto);


    }
}
