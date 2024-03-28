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
using MVCCRUDAPI.Models;

namespace MVCCRUDAPI.Controllers
{
    public class PEOPLEController : ApiController
    {
        private CRUDMVCAPIEntities db = new CRUDMVCAPIEntities();

        // GET: api/PEOPLE
        public IQueryable<PEOPLE> GetPEOPLE()
        {
            return db.PEOPLE;
        }

        // GET: api/PEOPLE/5
        [ResponseType(typeof(PEOPLE))]
        public IHttpActionResult GetPEOPLE(int id)
        {
            PEOPLE pEOPLE = db.PEOPLE.Find(id);
            if (pEOPLE == null)
            {
                return NotFound();
            }

            return Ok(pEOPLE);
        }

        // PUT: api/PEOPLE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPEOPLE(int id, PEOPLE pEOPLE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pEOPLE.id)
            {
                return BadRequest();
            }

            db.Entry(pEOPLE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PEOPLEExists(id))
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

        // POST: api/PEOPLE
        [ResponseType(typeof(PEOPLE))]
        public IHttpActionResult PostPEOPLE(PEOPLE pEOPLE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PEOPLE.Add(pEOPLE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pEOPLE.id }, pEOPLE);
        }

        // DELETE: api/PEOPLE/5
        [ResponseType(typeof(PEOPLE))]
        public IHttpActionResult DeletePEOPLE(int id)
        {
            PEOPLE pEOPLE = db.PEOPLE.Find(id);
            if (pEOPLE == null)
            {
                return NotFound();
            }

            db.PEOPLE.Remove(pEOPLE);
            db.SaveChanges();

            return Ok(pEOPLE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PEOPLEExists(int id)
        {
            return db.PEOPLE.Count(e => e.id == id) > 0;
        }
    }
}