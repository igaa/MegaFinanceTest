using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Mega.Finance.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Mega.Finance.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiLocationController : ControllerBase
    {
        BPKBDbContext context = new BPKBDbContext();
        // GET: api/<ApiBpkbController>
        [HttpGet]
        public async Task<ApiResponseObj> Get()
        {
            try
            {
                var query = await context.ms_storage_location.ToListAsync();
                return new ApiResponseObj()
                {
                    data = query,
                    message = "Sucess Get Data",
                    status = true,

                };
            }
            catch (Exception ex)
            {

                return new ApiResponseObj()
                {
                    message = "Failed Get Data",
                    status = false,

                };
            }

        }

        // GET api/<ApiLocationController>/5
        [HttpGet("{id}")]
        public async Task<ApiResponseObj> GetBy(int Id)
        {
            try
            {
                var query = await context.ms_storage_location.Where(s => s.location_id == Id).FirstOrDefaultAsync(); 
                return new ApiResponseObj()
                {
                    data = query,
                    message = "Success get  Data!",
                    status = true,
                };
            }
            catch (Exception ex)
            {
                return new ApiResponseObj()
                {
                    message = "Failed get  Data!",
                    status = false,
                };
            }
           
        }
    }
}
