using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TimeSheet1.Models;

namespace TimeSheet1.Controllers
{
    public class ProfileController : ApiController
    {
        private Sunray12dbDataContext db = new Sunray12dbDataContext();

        // GET: api/Profile
        public IQueryable<Profiletbl> GetProfiletbls()
        {
            return db.Profiletbls;
        }

        // GET: api/Profile/5
        [ResponseType(typeof(Profiletbl))]
        public IHttpActionResult GetProfiletbl(string id)
        {
            Profiletbl profiletbl = db.Profiletbls.Find(id);
            if (profiletbl == null)
            {
                return NotFound();
            }

            return Ok(profiletbl);
        }

        // PUT: api/Profile/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfiletbl(string id, Profiletbl profiletbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profiletbl.FirstName)
            {
                return BadRequest();
            }

            db.Entry(profiletbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfiletblExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Profile
        [ResponseType(typeof(Profiletbl))]
        public IHttpActionResult PostProfiletbl(Profiletbl profiletbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiletbls.Add(profiletbl);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProfiletblExists(profiletbl.FirstName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = profiletbl.FirstName }, profiletbl);
        }

        // DELETE: api/Profile/5
        [ResponseType(typeof(Profiletbl))]
        public IHttpActionResult DeleteProfiletbl(string id)
        {
            Profiletbl profiletbl = db.Profiletbls.Find(id);
            if (profiletbl == null)
            {
                return NotFound();
            }

            db.Profiletbls.Remove(profiletbl);
            db.SaveChanges();

            return Ok(profiletbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfiletblExists(string id)
        {
            return db.Profiletbls.Count(e => e.FirstName == id) > 0;
        }
    }
}