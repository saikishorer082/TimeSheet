using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TimeSheet1.Models;

namespace TimeSheet1.Controllers
{
    public class NewTimeEntrytblsController : ApiController
    {
        private Sunray12dbDataContext db = new Sunray12dbDataContext();

        // GET: api/NewTimeEntrytbls
        public IQueryable<NewTimeEntrytbl> GetNewTimeEntrytbls()
        {
            return db.NewTimeEntrytbls;
        }

        // GET: api/NewTimeEntrytbls/5
        [ResponseType(typeof(NewTimeEntrytbl))]
        public async Task<IHttpActionResult> GetNewTimeEntrytbl(DateTime id)
        {
            NewTimeEntrytbl newTimeEntrytbl = await db.NewTimeEntrytbls.FindAsync(id);
            if (newTimeEntrytbl == null)
            {
                return NotFound();
            }

            return Ok(newTimeEntrytbl);
        }

        // PUT: api/NewTimeEntrytbls/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNewTimeEntrytbl(DateTime id, NewTimeEntrytbl newTimeEntrytbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newTimeEntrytbl.WorkDay)
            {
                return BadRequest();
            }

            db.Entry(newTimeEntrytbl).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewTimeEntrytblExists(id))
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

        // POST: api/NewTimeEntrytbls
        [ResponseType(typeof(NewTimeEntrytbl))]
        public async Task<IHttpActionResult> PostNewTimeEntrytbl(NewTimeEntrytbl newTimeEntrytbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewTimeEntrytbls.Add(newTimeEntrytbl);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NewTimeEntrytblExists(newTimeEntrytbl.WorkDay))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = newTimeEntrytbl.WorkDay }, newTimeEntrytbl);
        }

        // DELETE: api/NewTimeEntrytbls/5
        [ResponseType(typeof(NewTimeEntrytbl))]
        public async Task<IHttpActionResult> DeleteNewTimeEntrytbl(DateTime id)
        {
            NewTimeEntrytbl newTimeEntrytbl = await db.NewTimeEntrytbls.FindAsync(id);
            if (newTimeEntrytbl == null)
            {
                return NotFound();
            }

            db.NewTimeEntrytbls.Remove(newTimeEntrytbl);
            await db.SaveChangesAsync();

            return Ok(newTimeEntrytbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewTimeEntrytblExists(DateTime id)
        {
            return db.NewTimeEntrytbls.Count(e => e.WorkDay == id) > 0;
        }
    }
}