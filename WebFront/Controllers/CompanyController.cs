using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebFront.Models;
using WebFront.Services;

namespace WebFront.Controllers
{
    public class CompanyController : ApiController
    {
        private ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        // GET api/<controller>
        public IEnumerable<Company> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var company = _service.GetById(id);
            if(company != null)
            {
                return Ok(company);
            }
            return NotFound();
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Company company)
        {
            bool added = _service.Add(company);
            if(added)
            {
                return Ok(company);
            }
            return Content(HttpStatusCode.InternalServerError, _service.GetError());
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Company company)
        {
            bool updated = _service.Update(company);
            if(updated)
            {
                return Ok(updated);
            }
            return Content(HttpStatusCode.InternalServerError, _service.GetError());
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}