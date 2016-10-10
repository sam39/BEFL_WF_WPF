using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAdmin.Controllers
{
    public class EmpController : Controller
    {

        //private CodeContext _db = new CodeContext();
        private BL.UnitOfWork unitOfWork = new BL.UnitOfWork();

        //public ActionResult Index(int? CabId)
        //{
        //    if (CabId > 0)
        //    {
        //        ViewBag.CabId = CabId;
        //    }
        //    var allBranchs = _db.Branchs.ToList<Models.Branch>();
        //    return View(allBranchs);
        //}


        // GET: Emp
        public ActionResult Index()
        {
            var allEmps = unitOfWork.EmpRepository.GetAll() as List<BL.Emp>;
            return View(allEmps);
        }

        public ActionResult EmpSearch(string SearchString)
        {
            List<BL.Emp> list = unitOfWork.EmpRepository.Get(filter: emp => emp.LastName.Contains(SearchString)) as List<BL.Emp>;
            list.OrderBy(s => s.LastName);
            return PartialView(list.Take(10));
        }

        public ActionResult ShowPass(Int32 id)
        {
            BL.Emp emp = unitOfWork.EmpRepository.GetByID(id) as BL.Emp;
            return PartialView(emp);

        }

        public ActionResult Edit(Int32 id)
        {
            BL.Emp emp = unitOfWork.EmpRepository.GetByID(id) as BL.Emp;
            IEnumerable<BL.Dep> DepList = unitOfWork.DivisionRepository.GetAll();
            ViewBag.DepList = DepList;
            return View(emp);
        }

    }
}