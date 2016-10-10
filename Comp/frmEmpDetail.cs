using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAdmin
{
    public partial class frmEmpDetail : Form, IfViewEmpDetail
    {
        
        public event EventHandler Save;

        public frmEmpDetail()
        {
            InitializeComponent();
            buttonSave.Click += ButtonSave_Click;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (Save != null) Save(sender, EventArgs.Empty);
            this.Close();
        }

        public BL.Emp Emp
        {
            get
            {
                if (empBindingSource.Current != null)
                {
                    return empBindingSource.Current as BL.Emp;
                }
                else return null;
            }
            set
            {
                empBindingSource.DataSource = value;
            }
        }

        public List<BL.Pos> PosList
        {
            set
            {
                PosComboBox.DataSource = value;
                PosComboBox.DisplayMember = "Name";
                PosComboBox.ValueMember = "Id";
             }
        }

        public List<BL.Dep> DepList
        {
            set { DepComboBox.DataSource = value; }
        }

        private void frmEmpDetail_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
