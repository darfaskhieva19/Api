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
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PerformancesController : ApiController
    {
        private PerfomEntities db = new PerfomEntities();

        // GET: api/Performances
        [ResponseType(typeof(List<ModelPerfomance>))]
        public IHttpActionResult GetPerformances()
        {
            return Ok(db.Performances.ToList().ConvertAll(x => new ModelPerfomance(x)));
        }

        // GET: api/Performances/5
        [ResponseType(typeof(Performances))]
        public IHttpActionResult GetPerformances(int id)
        {
            Performances performances = db.Performances.Find(id);
            if (performances == null)
            {
                return NotFound();
            }

            return Ok(performances);
        }

        // PUT: api/Performances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerformances(int id, Performances performances)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != performances.ID)
            {
                return BadRequest();
            }

            db.Entry(performances).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformancesExists(id))
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

        // POST: api/Performances
        [ResponseType(typeof(Performances))]
        public IHttpActionResult PostPerformances(Performances performances)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Performances.Add(performances);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = performances.ID }, performances);
        }

        // DELETE: api/Performances/5
        [ResponseType(typeof(Performances))]
        public IHttpActionResult DeletePerformances(int id)
        {
            Performances performances = db.Performances.Find(id);
            if (performances == null)
            {
                return NotFound();
            }

            db.Performances.Remove(performances);
            db.SaveChanges();

            return Ok(performances);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerformancesExists(int id)
        {
            return db.Performances.Count(e => e.ID == id) > 0;
        }
    }
}