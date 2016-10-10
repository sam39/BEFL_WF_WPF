using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAdmin
{

    public interface IfViewEmpDetail
    {
        BL.Emp Emp { get; set; }
        List<BL.Dep> DepList { set;}
        List<BL.Pos> PosList { set;}

        event EventHandler Save;
    }
    public class PresenterEmpDetail
    {
        private readonly IfViewEmpDetail _view;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public PresenterEmpDetail(frmEmpDetail form)
        {
            _view = form;
            _view.Save += _view_Save;
            _view.Emp = new BL.Emp();
            _view.PosList = unitOfWork.PosRepository.GetAll() as List<BL.Pos>;
            _view.DepList = unitOfWork.DivisionRepository.GetAll() as List<BL.Dep>;

            form.Show();
        }

        private void _view_Save(object sender, EventArgs e)
        {
            if (_view.Emp != null)
            {
                unitOfWork.EmpRepository.Insert(_view.Emp);
                unitOfWork.Save();
            }
        }
    }
}
