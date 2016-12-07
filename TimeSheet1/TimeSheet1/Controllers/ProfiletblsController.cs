using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using TimeSheet1.Models;

namespace TimeSheet1.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using TimeSheet1.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Profiletbl>("Profiletbls");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProfiletblsController : ODataController
    {
        private Sunray12dbDataContext db = new Sunray12dbDataContext();

        // GET: odata/Profiletbls
        [EnableQuery]
        public IQueryable<Profiletbl> GetProfiletbls()
        {
            return db.Profiletbls;
        }

        // GET: odata/Profiletbls(5)
        [EnableQuery]
        public SingleResult<Profiletbl> GetProfiletbl([FromODataUri] string key)
        {
            return SingleResult.Create(db.Profiletbls.Where(profiletbl => profiletbl.FirstName == key));
        }

        // PUT: odata/Profiletbls(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<Profiletbl> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Profiletbl profiletbl = db.Profiletbls.Find(key);
            if (profiletbl == null)
            {
                return NotFound();
            }

            patch.Put(profiletbl);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfiletblExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(profiletbl);
        }

        // POST: odata/Profiletbls
        public IHttpActionResult Post(Profiletbl profiletbl)
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

            return Created(profiletbl);
        }

        // PATCH: odata/Profiletbls(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<Profiletbl> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Profiletbl profiletbl = db.Profiletbls.Find(key);
            if (profiletbl == null)
            {
                return NotFound();
            }

            patch.Patch(profiletbl);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfiletblExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(profiletbl);
        }

        // DELETE: odata/Profiletbls(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            Profiletbl profiletbl = db.Profiletbls.Find(key);
            if (profiletbl == null)
            {
                return NotFound();
            }

            db.Profiletbls.Remove(profiletbl);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfiletblExists(string key)
        {
            return db.Profiletbls.Count(e => e.FirstName == key) > 0;
        }
    }
}
