using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Mega.Finance.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Mega.Finance.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiUserController : ControllerBase
    {
        BPKBDbContext context = new BPKBDbContext();

        [HttpGet]
        public async Task<ApiResponseObj> Get()
        {
            try
            {
                var query = await context.ms_user.ToListAsync();
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
                var query = await context.ms_user.Where(s => s.user_id == Id).FirstOrDefaultAsync();
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

        // POST api/<userController>
        [HttpPost]
        public async Task<ApiResponseObj> Login()
        {
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    ms_user form =  HttpContext.Request.ReadFromJsonAsync<ms_user>().Result;

                    var checkLogin = await context.ms_user.Where(s => s.user_name == form.user_name && s.password == form.password).FirstOrDefaultAsync(); 
                    if (checkLogin == null) {
                        return new ApiResponseObj()
                        {
                            message = "Failed Login, Invalid user or password!",
                            status = false,
                        };
                    }
                    //await context.tr_bpkb.AddAsync(form);

                    //await trans.CommitAsync();

                    return new ApiResponseObj()
                    {
                        data = form,
                        message = "Success Login!",
                        status = true,
                    };

                }
                catch (Exception ex)
                {
                    return new ApiResponseObj()
                    {
                        message = "Success update Data!",
                        status = false,
                    };
                }


            }
        }

    }
}
