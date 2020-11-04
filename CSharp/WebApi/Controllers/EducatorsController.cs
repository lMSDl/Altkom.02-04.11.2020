using DAL.Services;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApi.Controllers
{
    public class EducatorsController : ApiController
    {
        private EducatorsService Service { get; } = new EducatorsService();

        [HttpGet]
        public async Task<IHttpActionResult> Get(int? limit = null, string specialization = null)
        {
            IEnumerable<Educator> educators = null;
            if (limit == null && specialization == null)
                educators = await Service.ReadAsync();
            else if(specialization != null)
                    educators = await Service.ReadBySpecializationAsync(specialization);

            if (educators == null)
                educators = await Service.ReadWithLimitAsync(limit.Value);
            else if(limit.HasValue)
                educators = educators.Take(limit.Value);

            return Ok(educators);
        }


        [Route("api/Educators/{id}", Name = "GetEducator")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var educator = await Service.ReadAsync(id);
            if (educator == null)
                return NotFound();
            return Ok(educator);
        }

        public async Task<IHttpActionResult> Post(Educator educator)
        {
            educator = await Service.CreateAsync(educator);
            return CreatedAtRoute("GetEducator", new {id = educator.EducatorId } , educator.EducatorId);
        }

        public async Task<IHttpActionResult> Put(int id, Educator educator)
        {
            if (await Service.ReadAsync(id) != null)
                return NotFound();
            educator.EducatorId = id;
            await Service.UpdateAsync(educator);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            if (await Service.ReadAsync(id) != null)
                return NotFound();

            await Service.DeleteAsync(id);

            //var result = new NegotiatedContentResult<string>(System.Net.HttpStatusCode.InternalServerError, "Memory overflow", this);
            //return result;
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}