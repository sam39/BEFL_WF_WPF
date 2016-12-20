using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebAdmin.Controllers
{
    public class EmpController : Controller
    {
        private BL.UnitOfWork unitOfWork = new BL.UnitOfWork();

        // GET: Emp
        [AllowAnonymous]
        public ActionResult Index()
        {
            var allEmps = unitOfWork.EmpRepository.GetAll().Where(emp => emp.HideInSpr = false) as List<BL.Emp>;

            List<SelectListItem> PosList = new List<SelectListItem>();
            foreach (BL.Pos pos in unitOfWork.PosRepository.GetAll().OrderBy(e=> e.Name))
            {
                PosList.Add(new SelectListItem { Text = pos.Name, Value = pos.Id.ToString() });
            }

            List<SelectListItem> DepList = new List<SelectListItem>();
            foreach (BL.Dep dep in unitOfWork.DivisionRepository.GetAll().OrderBy(e=> e.Name))
            {
                DepList.Add(new SelectListItem { Text = dep.Name, Value = dep.Id.ToString() });
            }
            ViewData["AllPos"] = PosList;
            ViewData["AllDep"] = DepList;

            return View(allEmps);
        }

        [Authorize(Roles = "admin")]
        public ActionResult IndexForAdmin()
        {
            var allEmps = unitOfWork.EmpRepository.GetAll() as List<BL.Emp>;

            List<SelectListItem> PosList = new List<SelectListItem>();
            foreach (BL.Pos pos in unitOfWork.PosRepository.GetAll())
            {
                PosList.Add(new SelectListItem { Text = pos.Name, Value = pos.Id.ToString() });
            }

            List<SelectListItem> DepList = new List<SelectListItem>();
            foreach (BL.Dep dep in unitOfWork.DivisionRepository.GetAll())
            {
                DepList.Add(new SelectListItem { Text = dep.Name, Value = dep.Id.ToString() });
            }
            ViewData["AllPos"] = PosList;
            ViewData["AllDep"] = DepList;

            return PartialView(allEmps);
        }

        public ActionResult EmpSearchForAdm(string Order)
        {
            // Извлечь отправленные данные из Request.Form 
            string LastName = Request.Form["LastName"];
            string Name = Request.Form["Name"];
            string SName = Request.Form["SName"];
            string IntTel = Request.Form["IntTel"];
            string MobTel = Request.Form["MobTel"];
            string Pos = Request.Form["Pos"];
            string Dep = Request.Form["Dep"];
            string Ord = Request.Form["order"];
            string OrdDir = Request.Form["orderDir"];

            int PosId = 0, DepId = 0;
            if (Pos != null) if (Pos.Length > 0) PosId = Int32.Parse(Pos);
            if (Dep != null) if (Dep.Length > 0) DepId = Int32.Parse(Dep);

            IEnumerable<BL.Emp> list = unitOfWork.EmpRepository.Get();
            if (LastName.Length > 0) list = list.Where(emp => emp.LastName != null).Where(emp => emp.LastName.ToLower().Contains(LastName.ToLower())).ToList();
            if (Name.Length > 0) list = list.Where(emp => emp.Name != null).Where(emp => emp.Name.ToLower().Contains(Name.ToLower())).ToList();
            if (SName.Length > 0) list = list.Where(emp => emp.SName != null).Where(emp => emp.SName.ToLower().Contains(SName.ToLower())).ToList();
            if (IntTel.Length > 0) list = list.Where(emp => emp.InternalTel != null).Where(emp => emp.InternalTel.Contains(IntTel)).ToList();
            if (MobTel.Length > 0) list = list.Where(emp => emp.MobileTel != null).Where(emp => emp.MobileTel.Contains(MobTel)).ToList();
            if (PosId > 0) list = list.Where(emp => emp.PosId == PosId).ToList();
            if (DepId > 0) list = list.Where(emp => emp.DepId == DepId).ToList();

            if (Ord == "ordLastName")
            {
                ViewData["ordName"] = "ordLastName";
                if (OrdDir == "on")
                {
                    list = list.OrderBy(s => s.LastName).ToList();
                    ViewData["ordDir"] = "asc";
                }
                else
                {
                    list = list.OrderByDescending(s => s.LastName).ToList();
                    ViewData["ordDir"] = "dsc";
                }
            }

            if (Ord == "ordName")
            {
                ViewData["ordName"] = "ordName";
                if (OrdDir == "on") list = list.OrderBy(s => s.Name).ToList();
                else list = list.OrderByDescending(s => s.Name).ToList();
            }

            if (Ord == "ordSName")
            {
                ViewData["ordName"] = "ordSName";
                if (OrdDir == "on") list = list.OrderBy(s => s.SName).ToList();
                else list = list.OrderByDescending(s => s.SName).ToList();
            }

            if (Ord == "ordPos")
            {
                ViewData["ordName"] = "ordPos";
                if (OrdDir == "on") list = list.OrderBy(s => s.PosName).ToList();
                else list = list.OrderByDescending(s => s.PosName).ToList();
            }

            if (Ord == "ordDep")
            {
                ViewData["ordName"] = "ordDep";
                if (OrdDir == "on") list = list.OrderBy(s => s.DepName).ToList();
                else list = list.OrderByDescending(s => s.DepName).ToList();
            }

            if (Ord == "ordIntTel")
            {
                ViewData["ordName"] = "ordIntTel";
                if (OrdDir == "on") list = list.OrderBy(s => s.InternalTel).ToList();
                else list = list.OrderByDescending(s => s.InternalTel).ToList();
            }

            if (Ord == "ordMobTel")
            {
                ViewData["ordName"] = "ordMobTel";
                if (OrdDir == "on") list = list.OrderBy(s => s.MobileTel).ToList();
                else list = list.OrderByDescending(s => s.MobileTel).ToList();
            }

            if (OrdDir == "on") ViewData["ordDir"] = "asc";
            else ViewData["ordDir"] = "dsc";

            return PartialView(list);
        }

        public ActionResult EmpSearch(string Order)
        {
            // Извлечь отправленные данные из Request.Form 
            string LastName = Request.Form["LastName"];
            string Name = Request.Form["Name"];
            string SName = Request.Form["SName"];
            string Skype = Request.Form["Skype"];
            string Email = Request.Form["Email"];
            string IntTel = Request.Form["IntTel"];
            string MobTel = Request.Form["MobTel"];
            string Pos = Request.Form["Pos"];
            string Dep = Request.Form["Dep"];
            string Ord = Request.Form["order"];
            string OrdDir = Request.Form["orderDir"];

            int PosId =0, DepId = 0;
            if (Pos != null) if (Pos.Length >0) PosId = Int32.Parse(Pos);
            if (Dep != null) if (Dep.Length >0) DepId = Int32.Parse(Dep);

            IEnumerable<BL.Emp> list = unitOfWork.EmpRepository.Get();
            list = list.Where(emp => emp.HideInSpr != true);
            if (LastName.Length > 0) list = list.Where(emp => emp.LastName != null).Where(emp => emp.LastName.ToLower().Contains(LastName.ToLower())).ToList();
            if (Name.Length > 0) list = list.Where(emp => emp.Name != null).Where(emp => emp.Name.ToLower().Contains(Name.ToLower())).ToList();
            if (SName.Length > 0) list = list.Where(emp => emp.SName != null).Where(emp => emp.SName.ToLower().Contains(SName.ToLower())).ToList();
            if (Skype.Length > 0) list = list.Where(emp => emp.SkypeName != null).Where(emp => emp.SkypeName.Contains(Skype)).ToList();   
            if (Email.Length > 0) list = list.Where(emp => emp.Email != null).Where(emp => emp.Email.Contains(Email)).ToList();           
            if (IntTel.Length > 0) list = list.Where(emp => emp.InternalTel != null).Where(emp => emp.InternalTel.Contains(IntTel)).ToList();
            if (MobTel.Length > 0) list = list.Where(emp => emp.MobileTel!=null).Where(emp => emp.MobileTel.Contains(MobTel)).ToList();
            if (PosId > 0) list = list.Where(emp => emp.PosId == PosId).ToList();
            if (DepId > 0) list = list.Where(emp => emp.DepId == DepId).ToList();

            if (Ord == "ordLastName")
            {
                ViewData["ordName"] = "ordLastName";
                if (OrdDir == "on")
                {
                    list = list.OrderBy(s => s.LastName).ToList();
                    ViewData["ordDir"] = "asc";
                }
                else
                { 
                    list = list.OrderByDescending(s => s.LastName).ToList();
                    ViewData["ordDir"] = "dsc";
                }
            }

            if (Ord == "ordName")
            {
                ViewData["ordName"] = "ordName";
                if (OrdDir == "on") list = list.OrderBy(s => s.Name).ToList();
                else list = list.OrderByDescending(s => s.Name).ToList();                
            }

            if (Ord == "ordSName")
            {
                ViewData["ordName"] = "ordSName";
                if (OrdDir == "on") list = list.OrderBy(s => s.SName).ToList();
                else list = list.OrderByDescending(s => s.SName).ToList();
            }

            if (Ord == "ordPos")
            {
                ViewData["ordName"] = "ordPos";
                if (OrdDir == "on") list = list.OrderBy(s => s.PosName).ToList();
                else list = list.OrderByDescending(s => s.PosName).ToList();
            }

            if (Ord == "ordDep")
            {
                ViewData["ordName"] = "ordDep";
                if (OrdDir == "on") list = list.OrderBy(s => s.DepName).ToList();
                else list = list.OrderByDescending(s => s.DepName).ToList();
            }
            if (Ord == "ordSkype")
            {
                ViewData["ordName"] = "ordSkype";
                if (OrdDir == "on") list = list.OrderBy(s => s.SkypeName).ToList();
                else list = list.OrderByDescending(s => s.SkypeName).ToList();
            }
            if (Ord == "ordEmail")
            {
                ViewData["ordName"] = "ordEmail";
                if (OrdDir == "on") list = list.OrderBy(s => s.Email).ToList();
                else list = list.OrderByDescending(s => s.Email).ToList();
            }
            if (Ord == "ordIntTel")
            {
                ViewData["ordName"] = "ordIntTel";
                if (OrdDir == "on") list = list.OrderBy(s => s.InternalTel).ToList();
                else list = list.OrderByDescending(s => s.InternalTel).ToList();
            }

            if (Ord == "ordMobTel")
            {
                ViewData["ordName"] = "ordMobTel";
                if (OrdDir == "on") list = list.OrderBy(s => s.MobileTel).ToList();
                else list = list.OrderByDescending(s => s.MobileTel).ToList();
            }

            if (OrdDir == "on") ViewData["ordDir"] = "asc";
            else ViewData["ordDir"] = "dsc";

            return PartialView(list);
        }


        public ActionResult ShowPass(Int32 id)
        {
            BL.Emp emp = unitOfWork.EmpRepository.GetByID(id) as BL.Emp;
            return PartialView(emp);

        }

        public ActionResult Edit(Int32 id)
        {
            BL.Emp emp = unitOfWork.EmpRepository.GetByID(id) as BL.Emp;

            List<SelectListItem> PosList= new List<SelectListItem>();
            foreach (BL.Pos pos in unitOfWork.PosRepository.GetAll())
            {
                PosList.Add(new SelectListItem { Text = pos.Name, Value = pos.Id.ToString() });                       
            }

            List<SelectListItem> DepList = new List<SelectListItem>();
            foreach (BL.Dep dep in unitOfWork.DivisionRepository.GetAll())
            {
                DepList.Add(new SelectListItem { Text = dep.Name, Value = dep.Id.ToString() });
            }
            ViewData["AllPos"] = PosList;
            ViewData["AllDep"] = DepList;
            return PartialView(emp);
        }

        public ActionResult Save(BL.Emp emp)
        {
            if (emp != null)
            {
                if (emp.Id == 0) unitOfWork.EmpRepository.Insert(emp);
                else unitOfWork.EmpRepository.Update(emp);
            }

            unitOfWork.Save();

            return RedirectToAction("ShowPass", new { Id = emp.Id });
        }

        public ActionResult Create()
        {
            List<SelectListItem> PosList = new List<SelectListItem>();
            foreach (BL.Pos pos in unitOfWork.PosRepository.GetAll())
            {
                PosList.Add(new SelectListItem { Text = pos.Name, Value = pos.Id.ToString() });
            }

            List<SelectListItem> DepList = new List<SelectListItem>();
            foreach (BL.Dep dep in unitOfWork.DivisionRepository.GetAll())
            {
                DepList.Add(new SelectListItem { Text = dep.Name, Value = dep.Id.ToString() });
            }
            ViewData["AllPos"] = PosList;
            ViewData["AllDep"] = DepList;

            BL.Emp newEmp = new BL.Emp();


            return PartialView("Edit", newEmp);               
        }

    }
}