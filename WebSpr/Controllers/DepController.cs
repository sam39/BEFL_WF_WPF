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
    public class DepController : ApiController
    {
        private DbContextBEFL db = new DbContextBEFL();

        // GET api/Dep
        public IEnumerable<Dep> GetDeps()
        {
            return db.Deps.AsEnumerable();
        }

        // GET api/Dep/5
        public Dep GetDep(int id)
        {
            Dep dep = db.Deps.Find(id);
            if (dep == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return dep;
        }

        // PUT api/Dep/5
        public HttpResponseMessage PutDep(int id, Dep dep)
        {
            if (ModelState.IsValid && id == dep.Id)
            {
                db.Entry(dep).State = EntityState.Modified;

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

        // POST api/Dep
        public HttpResponseMessage PostDep(Dep dep)
        {
            if (ModelState.IsValid)
            {
                db.Deps.Add(dep);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, dep);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dep.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Dep/5
        public HttpResponseMessage DeleteDep(int id)
        {
            Dep dep = db.Deps.Find(id);
            if (dep == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Deps.Remove(dep);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, dep);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}