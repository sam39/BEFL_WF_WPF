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
    public class PosController : ApiController
    {
        private DbContextBEFL db = new DbContextBEFL();
        private BL.UnitOfWork unitOfWork = new BL.UnitOfWork();
        // GET api/Pos
        public IEnumerable<Pos> GetPos()
        {

            return db.Poss.AsEnumerable();
   
        }

        // GET api/Pos/5
        public Pos GetPos(int id)
        {
            Pos pos = db.Poss.Find(id);
            if (pos == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return pos;
        }

        // PUT api/Pos/5
        public HttpResponseMessage PutPos(int id, Pos pos)
        {
            if (ModelState.IsValid && id == pos.Id)
            {
                db.Entry(pos).State = EntityState.Modified;

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

        // POST api/Pos
        public HttpResponseMessage PostPos(Pos pos)
        {
            if (ModelState.IsValid)
            {
                db.Poss.Add(pos);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, pos);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = pos.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Pos/5
        public HttpResponseMessage DeletePos(int id)
        {
            Pos pos = db.Poss.Find(id);
            if (pos == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Poss.Remove(pos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, pos);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}