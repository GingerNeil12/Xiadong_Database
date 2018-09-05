using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebFront.Models;
using WebFront.Services;

namespace WebFront.Controllers
{
    public class ContactController : ApiController
    {
        private IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        // GET api/<controller>
        public IEnumerable<Contact> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var contact = _service.GetById(id);
            if(contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Contact contact)
        {
            var added = _service.Add(contact);
            if(added)
            {
                return Ok(contact);
            }
            return Content(HttpStatusCode.InternalServerError, _service.GetError());
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Contact contact)
        {
            var updated = _service.Update(contact);
            if(updated)
            {
                return Ok(contact);
            }
            return Content(HttpStatusCode.InternalServerError, _service.GetError());
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}