using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAdmin
{
        public interface IfrmMain
        {
            List<BL.Emp> EmpList { set; }
            event EventHandler Search;
            event EventHandler AddNew;
            event EventHandler Save;
            List<BL.Dep> DepList { set; }
            List<BL.Pos> PosList { set; }
             BL.Emp EmpForSave { get; }
            String SearchSrting { get; }
        }

    class PresenterMain
    {


        private readonly IfrmMain _view;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public PresenterMain(IfrmMain form)
        {
            _view = form;
            _view.Search += _view_Search;
            _view.AddNew += _view_AddNew;
            _view.Save += _view_Save;
            form.EmpList = unitOfWork.EmpRepository.GetAll() as List<BL.Emp>;
            _view.DepList = unitOfWork.DivisionRepository.GetAll() as List<BL.Dep>;
            _view.PosList = unitOfWork.PosRepository.GetAll() as List<BL.Pos>;
        }

        private void _view_Save(object sender, EventArgs e)
        {
            if (_view.EmpForSave != null)
            {
                if(_view.EmpForSave.Id == 0) unitOfWork.EmpRepository.Insert(_view.EmpForSave);
            }
            unitOfWork.Save();
        }

        private void _view_AddNew(object sender, EventArgs e)
        {
            //PresenterEmpDetail PresenterEmpDetail = new PresenterEmpDetail(new frmEmpDetail());

        }

        private void _view_Search(object sender, EventArgs e)
        {
            List<BL.Emp> list = unitOfWork.EmpRepository.Get(filter: emp => emp.LastName.Contains(_view.SearchSrting)) as List<BL.Emp>;
            list.OrderBy(s => s.LastName);
            _view.EmpList = list;
        }
    }
}
