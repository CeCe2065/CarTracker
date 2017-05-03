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
using CarTracker.Models;

namespace CarTracker.Controllers
{
    public class CarMakesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CarMakesApi
        public IQueryable<CarMake> GetCarMakes()
        {
            return db.CarMakes;
        }

        // GET: api/CarMakesApi/5
        [ResponseType(typeof(CarMake))]
        public IHttpActionResult GetCarMake(int id)
        {
            CarMake carMake = db.CarMakes.Find(id);
            if (carMake == null)
            {
                return NotFound();
            }

            return Ok(carMake);
        }

        // PUT: api/CarMakesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarMake(int id, CarMake carMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carMake.CarMakeID)
            {
                return BadRequest();
            }

            db.Entry(carMake).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarMakeExists(id))
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

        // POST: api/CarMakesApi
        [ResponseType(typeof(CarMake))]
        public IHttpActionResult PostCarMake(CarMake carMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarMakes.Add(carMake);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carMake.CarMakeID }, carMake);
        }

        // DELETE: api/CarMakesApi/5
        [ResponseType(typeof(CarMake))]
        public IHttpActionResult DeleteCarMake(int id)
        {
            CarMake carMake = db.CarMakes.Find(id);
            if (carMake == null)
            {
                return NotFound();
            }

            db.CarMakes.Remove(carMake);
            db.SaveChanges();

            return Ok(carMake);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarMakeExists(int id)
        {
            return db.CarMakes.Count(e => e.CarMakeID == id) > 0;
        }
    }
}