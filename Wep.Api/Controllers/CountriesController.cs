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
using Wep.Api.Models;
using Wep.Api.Models.DTO;

namespace Wep.Api.Controllers
{   [Authorize]
    public class CountriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Countries
        public List<CountryDTO> GetCountries()
        {
            List<City> cities = db.Cities.ToList();

            return db.Countries.ToList().Select(e => new CountryDTO
            {
                Id = e.Id,
                Name = e.Name,
                Cities = e.Cities.Select(c => new CityDto { Id = c.Id, Name = c.Name , CountryID = c.country.Id ,
                    CountryName = c.country.Name }).ToList()
            }).ToList(); ;
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult GetCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(new CountryDTO { Id = country.Id,Name = country.Name , Cities = country.Cities.Select(c => new CityDto {
                Id = c.Id,
                Name = c.Name,
                CountryID = c.country.Id,
                CountryName = c.country.Name
            }).ToList() });
        }


        public HttpResponseMessage GetCities()
        {
            List<City> cities = db.Cities.ToList();

            var returnedCities = db.Cities.Select(e => new CityDto
            {
                Id =e.Id,
                Name = e.Name,
                CountryID = e.country.Id,
                CountryName = e.country.Name
            }).ToList(); ;
            var response = Request.CreateResponse(HttpStatusCode.OK, returnedCities);
            return response;
        }

        /// <summary>
        /// return city by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Country))]
        public IHttpActionResult GetCity(int id)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                CountryID = city.country.Id,
                CountryName = city.country.Name
            });
        }

        //// PUT: api/Countries/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCountry(int id, Country country)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != country.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(country).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CountryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Countries
        [ResponseType(typeof(Country))]
        public IHttpActionResult PostCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Countries.Add(country);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult DeleteCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            db.Countries.Remove(country);
            db.SaveChanges();

            return Ok(country);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryExists(int id)
        {
            return db.Countries.Count(e => e.Id == id) > 0;
        }
    }
}