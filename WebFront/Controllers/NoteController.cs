using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebFront.Models;
using WebFront.Services;

namespace WebFront.Controllers
{
    public class NoteController : ApiController
    {
        private INoteService _service;

        public NoteController(INoteService service)
        {
            _service = service;
        }

        // GET api/<controller>
        public IEnumerable<Note> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var note = _service.GetById(id);
            if(note != null)
            {
                return Ok(note);
            }
            return NotFound();
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Note note)
        {
            var added = _service.Add(note);
            if(added)
            {
                return Ok(note);
            }
            return Content(HttpStatusCode.InternalServerError, _service.GetError());
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Note note)
        {
            var updated = _service.Update(note);
            if(updated)
            {
                return Ok(note);
            }
            return Content(HttpStatusCode.InternalServerError, _service.GetError());
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}