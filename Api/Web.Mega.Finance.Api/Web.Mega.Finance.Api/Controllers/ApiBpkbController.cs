using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Mega.Finance.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Mega.Finance.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiBpkbController : ControllerBase
    {

        BPKBDbContext context = new BPKBDbContext(); 

        // GET: api/<ApiBpkbController>
        [HttpGet]
        public async Task<ApiResponseObj> Get()
        {
            try
            {
                var query =context.tr_bpkb;
                var datalist = await query.ToListAsync();
                return new ApiResponseObj()
                {
                    data = datalist,
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

        // GET api/<ApiBpkbController>/5
        [HttpGet("{id}")]
        public async Task<ApiResponseObj> GetBy(int Id)
        {
            try
            {
                var query = await context.tr_bpkb.Where(s => s.id == Id).ToListAsync();
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

        // POST api/<ApiBpkbController>
        [HttpPost]
        public async Task<ApiResponseObj> Post()
        {
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    tr_bpkb form = HttpContext.Request.ReadFromJsonAsync<tr_bpkb>().Result;
                    await context.tr_bpkb.AddAsync(form);

                    await context.SaveChangesAsync(); 
                    await trans.CommitAsync();

                    return new ApiResponseObj()
                    {
                        data = form,
                        message = "Success update Data!",
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


        // POST api/<ApiBpkbController>
        [HttpPost]
        public async Task<ApiResponseObj> Update()
        {
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    tr_bpkb form = HttpContext.Request.ReadFromJsonAsync<tr_bpkb>().Result;
                    var getData = await context.tr_bpkb.Where(s => s.id == form.id).FirstOrDefaultAsync();
                    getData.agreement_number = context.tr_bpkb.Count().ToString();
                    getData.bpkb_no = form.bpkb_no; 
                    getData.branch_id = form.branch_id;
                    getData.bpkb_date = form.bpkb_date;
                    getData.faktur_no = form.faktur_no;
                    getData.faktur_date = form.faktur_date;
                    getData.location_id = form.location_id;
                    getData.police_no = form.police_no;
                    getData.bpkb_date_in = form.bpkb_date_in;
                    getData.last_updated_by = form.last_updated_by;
                    getData.last_updated_on = form.last_updated_on; 
                    context.tr_bpkb.Update(getData);
                    await context.SaveChangesAsync();
         
                    await trans.CommitAsync();

                    return new ApiResponseObj()
                    {
                        data = form,
                        message = "Success update Data!",
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

        // POST api/<ApiBpkbController>
        [HttpPost]
        public async Task<ApiResponseObj> Delete()
        {
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    tr_bpkb form = HttpContext.Request.ReadFromJsonAsync<tr_bpkb>().Result;
                    var getData = await context.tr_bpkb.Where(s => s.id == form.id).FirstOrDefaultAsync();
                    context.tr_bpkb.Remove(getData);
                    await context.SaveChangesAsync(); 
                    await trans.CommitAsync();

                    return new ApiResponseObj()
                    {
                        data = form,
                        message = "Success update Data!",
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
