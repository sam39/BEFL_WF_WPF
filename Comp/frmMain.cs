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
    public partial class frmMain : Form, IfrmMain
    {
        private bool EditMode =false;
        private bool DataChanged;
        private bool systrayrunning = true;
        public event EventHandler Search;
        public event EventHandler AddNew;
        public event EventHandler Save;
        public frmMain()
        {
            InitializeComponent();
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            buttonAddNew.Click += ButtonAddNew_Click;
        }

        public BL.Emp EmpForSave
        {
            get { if (empBindingSource.Current != null) return empBindingSource.Current as BL.Emp; else return null; }
        }

        private List<BL.Pos> poslist;
        public List<BL.Pos> PosList
        {
            set
            {
                poslist = value;
                DataGridViewComboBoxColumn column = empDataGridView.Columns[3] as DataGridViewComboBoxColumn;
                column.DataSource = value;
                column.ValueMember = "Id";
                column.DisplayMember = "Name";
                column.DataPropertyName = "PosId";
            }
        }
        private List<BL.Dep> deplist;
        public List<BL.Dep> DepList
        {
            set
            {
                deplist = value;
                DataGridViewComboBoxColumn column = empDataGridView.Columns[4] as DataGridViewComboBoxColumn;
                column.DataSource = value;
                column.ValueMember = "Id";
                column.DisplayMember = "Name";
                column.DataPropertyName = "DepId";
            }
        }



        private void ButtonAddNew_Click(object sender, EventArgs e)
        {
            if (AddNew != null) AddNew(sender, EventArgs.Empty);
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (Search != null) Search(sender, EventArgs.Empty);
        }

        public String SearchSrting
        {
            get { return textBoxSearch.Text; }
        }

        public List<BL.Emp> EmpList
        {
            set
            {
                empBindingSource.DataSource = value;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (this.systrayrunning)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }

        private void ItemExit_Click(object sender, EventArgs e)
        {
            systrayrunning = false;
            this.Close();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void chbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowPass.Checked == true)
            {
                emailPassTextBox.UseSystemPasswordChar = false;
                domainPassTextBox.UseSystemPasswordChar = false;
                eRoomPassTextBox.UseSystemPasswordChar = false;
                trueCryptPassTextBox.UseSystemPasswordChar = false;
                mangoTextBox.UseSystemPasswordChar = false;
                icqPassTextBox.UseSystemPasswordChar = false;
                skypePassTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                emailPassTextBox.UseSystemPasswordChar = true;
                domainPassTextBox.UseSystemPasswordChar = true;
                eRoomPassTextBox.UseSystemPasswordChar = true;
                trueCryptPassTextBox.UseSystemPasswordChar = true;
                mangoTextBox.UseSystemPasswordChar = true;
                icqPassTextBox.UseSystemPasswordChar = true;
                skypePassTextBox.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL.Emp newEmp = new BL.Emp();
            newEmp.DepId = 1;
            newEmp.PosId = 1;
            empBindingSource.DataSource = newEmp;
            empDataGridView.BeginEdit(false);
            EditMode = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            empBindingSource.EndEdit();
            if (Save != null) Save(sender, EventArgs.Empty);
            EditMode = false;
            empDataGridView.ReadOnly = true;
            empDataGridView.ReadOnly = true;
            emailTextBox.ReadOnly = true;
            emailPassTextBox.ReadOnly = true;
            eRoomPassTextBox.ReadOnly = true;
            trueCryptPassTextBox.ReadOnly = true;
            mangoTextBox.ReadOnly = true;
            icqNameTextBox.ReadOnly = true;
            icqPassTextBox.ReadOnly = true;
            gmailTextBox.ReadOnly = true;
            skypeNameTextBox.ReadOnly = true;
            skypePassTextBox.ReadOnly = true;
            domainPassTextBox.ReadOnly = true;
            mobileTelTextBox.ReadOnly = true;
            commentsTextBox.ReadOnly = true;
            HideInSprcheckBox.Enabled = false;
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (e.Control)
                    {
                        button1_Click(buttonAddNew, EventArgs.Empty);
                    }
                    break;

                case Keys.S:
                    if (e.Control)
                    {
                        //empDataGridView.EndEdit();
                        buttonSave_Click(buttonSave, EventArgs.Empty);
                    }
                    break;
            }
        }

        private void empDataGridView_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void empDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (EditMode == true)
            //{
            //    if (MessageBox.Show("Сохранить изменения?", "Данные были изменены", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        buttonSave_Click(buttonSave, EventArgs.Empty);
            //    }
            //    EditMode = false;
            //}

        }

        private void empBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {

        }

        private void empBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //MessageBox.Show("данные в источнике изменились");
            //DataChanged = true;
        }

        private void empBindingSource_PositionChanged(object sender, EventArgs e)
        {
           //if (DataChanged) MessageBox.Show("данные в источнике изменились");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            EditMode = true;
            empDataGridView.ReadOnly = false;
            emailTextBox.ReadOnly = false;
            emailPassTextBox.ReadOnly = false;
            eRoomPassTextBox.ReadOnly = false;
            trueCryptPassTextBox.ReadOnly = false;
            mangoTextBox.ReadOnly = false;
            icqNameTextBox.ReadOnly = false;
            icqPassTextBox.ReadOnly = false;
            gmailTextBox.ReadOnly = false;
            skypeNameTextBox.ReadOnly = false;
            skypePassTextBox.ReadOnly = false;
            domainPassTextBox.ReadOnly = false;
            mobileTelTextBox.ReadOnly = false;
            commentsTextBox.ReadOnly = false;
            HideInSprcheckBox.Enabled = true;
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            textBoxSearch.Focus();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
        }
    }
}
