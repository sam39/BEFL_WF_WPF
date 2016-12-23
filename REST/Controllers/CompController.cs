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
using BL;

namespace BEFLSPR.Controllers
{
    public class CompController : ApiController
    {
        private DbContextBEFL db = new DbContextBEFL();

        // GET api/Comp
        public IEnumerable<Comp> GetComps()
        {
            var comps = db.Comps.Include(c => c.User);
            //var mcs = db.MCs.Include(c => c.User);
            return comps.AsEnumerable();
        }

        // GET api/Comp/5
        public Comp GetComp(int id)
        {
            Comp comp = db.MCs.Find(id) as Comp;
            if (comp == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return comp;
        }

        // PUT api/Comp/5
        public HttpResponseMessage PutComp(int id, Comp comp)
        {
            if (ModelState.IsValid && id == comp.Id)
            {
                comp.UserId = comp.User.Id;
                comp.User = null;
                db.Entry(comp).State = EntityState.Modified;

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

        // POST api/Comp
        public HttpResponseMessage PostComp(Comp comp)
        {
            if (ModelState.IsValid)
            {
                comp.UserId = comp.User.Id;
                comp.User = null;
                db.MCs.Add(comp);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, comp);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = comp.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Comp/5
        public HttpResponseMessage DeleteComp(int id)
        {
            Comp comp = db.Comps.Find(id);
            if (comp == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Comps.Remove(comp);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, comp);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}