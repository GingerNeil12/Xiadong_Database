using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebFront.Models;
using WebFront.Services;

namespace WebFront.Controllers
{
    public class RegionController : ApiController
    {
        private IRegionService _service;

        public RegionController(IRegionService service)
        {
            _service = service;
        }

        // GET api/<controller>
        public IEnumerable<Region> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var region = _service.GetById(id);
            if(region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Region region)
        {
            bool added = _service.Add(region);
            if(added)
            {
                return Ok(region);
            }
            return Content(HttpStatusCode.InternalServerError, _service.GetError());
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Region region)
        {
            var updated = _service.Update(region);
            if(updated)
            {
                return Ok(region);
            }
            return Content(HttpStatusCode.InternalServerError, _service.GetError());
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}