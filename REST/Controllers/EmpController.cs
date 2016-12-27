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
//using System.Web.Mvc;
using BL;

namespace REST.Controllers
{
        
    public class EmpController : ApiController
    {
        private BL.UnitOfWork uow = new UnitOfWork();
        private DbContextBEFL db = new DbContextBEFL();

        // GET api/EmpApi
        //[Authorize(Roles = "admin")]
        public IEnumerable<Emp> GetEmps()
        {
            //return uow.EmpRepository.GetAll(false);
            db.Configuration.ProxyCreationEnabled = false;
            var emps = db.Emps.Include(e => e.Pos).Include(e => e.Dep);
            return emps.AsEnumerable();
        }

        // GET api/EmpApi/5
        //[Authorize(Roles = "admin")]
        public Emp GetEmp(int id)
        {
            Emp emp = uow.EmpRepository.GetByID(id);
            //Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return emp;
        }

        // PUT api/EmpApi/5
        //[Authorize(Roles = "admin")]
        public HttpResponseMessage PutEmp(int id, [FromBody]Emp emp)
        {
            if (ModelState.IsValid && id == emp.Id)
            {

                //emp.DepId = emp.Dep.Id;
                //emp.PosId = emp.Pos.Id;
                //emp.Dep = null;
                //emp.Pos = null;
                //db.Entry(emp).State = EntityState.Modified;
                uow.EmpRepository.Update(emp);

                try
                {
                    uow.Save();
                    //db.SaveChanges();
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

        // POST api/EmpApi
        //[Authorize(Roles = "admin")]
        public HttpResponseMessage PostEmp([FromBody]Emp emp)
        {
            if (ModelState.IsValid)
            {
                uow.EmpRepository.Insert(emp);
                uow.Save();
                //emp.DepId  = emp.Dep.Id;
                //emp.PosId = emp.Pos.Id;
                //emp.Dep = null;
                //emp.Pos = null;
                //db.Emps.Add(emp);
                //db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, emp);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = emp.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/EmpApi/5
        //[Authorize(Roles = "admin")]
        public HttpResponseMessage DeleteEmp(int id)
        {
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Emps.Remove(emp);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, emp);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}