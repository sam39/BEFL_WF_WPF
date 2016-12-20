using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BEFLSPR.Models;
using BL;

namespace BEFLSPR.Controllers
{
    public class MCController : ApiController
    {
        private DbContextBEFL db = new DbContextBEFL();

        // GET api/MC
        public IEnumerable<MC> GetMCs()
        {
            return db.MCs.AsEnumerable();
        }

        // GET api/MC/5
        public MC GetMC(int id)
        {
            MC mc = db.MCs.Find(id);
            if (mc == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return mc;
        }

        // PUT api/MC/5
        public HttpResponseMessage PutMC(int id, MC mc)
        {
            if (ModelState.IsValid && id == mc.Id)
            {
                db.Entry(mc).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/MC
        public HttpResponseMessage PostMC()
        {
            if (ModelState.IsValid)
            {
                MC mc = new MC();
                mc.InvNum = "testNum";
                db.MCs.Add(mc);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, mc);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mc.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/MC/5
        public HttpResponseMessage DeleteMC(int id)
        {
            MC mc = db.MCs.Find(id);
            if (mc == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.MCs.Remove(mc);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, mc);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}