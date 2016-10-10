namespace WFAdmin
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label emailPassLabel;
            System.Windows.Forms.Label eRoomPassLabel;
            System.Windows.Forms.Label gmailLabel;
            System.Windows.Forms.Label icqNameLabel;
            System.Windows.Forms.Label icqPassLabel;
            System.Windows.Forms.Label domainPassLabel;
            System.Windows.Forms.Label mangoLabel;
            System.Windows.Forms.Label skypeNameLabel;
            System.Windows.Forms.Label skypePassLabel;
            System.Windows.Forms.Label trueCryptPassLabel;
            System.Windows.Forms.Label commentsLabel;
            System.Windows.Forms.Label mobileTelLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.empDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DepId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InternalTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailPassTextBox = new System.Windows.Forms.TextBox();
            this.chbShowPass = new System.Windows.Forms.CheckBox();
            this.eRoomPassTextBox = new System.Windows.Forms.TextBox();
            this.gmailTextBox = new System.Windows.Forms.TextBox();
            this.icqNameTextBox = new System.Windows.Forms.TextBox();
            this.icqPassTextBox = new System.Windows.Forms.TextBox();
            this.domainPassTextBox = new System.Windows.Forms.TextBox();
            this.mangoTextBox = new System.Windows.Forms.TextBox();
            this.skypeNameTextBox = new System.Windows.Forms.TextBox();
            this.skypePassTextBox = new System.Windows.Forms.TextBox();
            this.trueCryptPassTextBox = new System.Windows.Forms.TextBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.commentsTextBox = new System.Windows.Forms.TextBox();
            this.mobileTelTextBox = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.Editbutton = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.HideInSprcheckBox = new System.Windows.Forms.CheckBox();
            emailLabel = new System.Windows.Forms.Label();
            emailPassLabel = new System.Windows.Forms.Label();
            eRoomPassLabel = new System.Windows.Forms.Label();
            gmailLabel = new System.Windows.Forms.Label();
            icqNameLabel = new System.Windows.Forms.Label();
            icqPassLabel = new System.Windows.Forms.Label();
            domainPassLabel = new System.Windows.Forms.Label();
            mangoLabel = new System.Windows.Forms.Label();
            skypeNameLabel = new System.Windows.Forms.Label();
            skypePassLabel = new System.Windows.Forms.Label();
            trueCryptPassLabel = new System.Windows.Forms.Label();
            commentsLabel = new System.Windows.Forms.Label();
            mobileTelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.empDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            emailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(46, 380);
            emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 2;
            emailLabel.Text = "Email:";
            // 
            // emailPassLabel
            // 
            emailPassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            emailPassLabel.AutoSize = true;
            emailPassLabel.Location = new System.Drawing.Point(20, 402);
            emailPassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            emailPassLabel.Name = "emailPassLabel";
            emailPassLabel.Size = new System.Drawing.Size(61, 13);
            emailPassLabel.TabIndex = 4;
            emailPassLabel.Text = "Email Pass:";
            // 
            // eRoomPassLabel
            // 
            eRoomPassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            eRoomPassLabel.AutoSize = true;
            eRoomPassLabel.Location = new System.Drawing.Point(208, 358);
            eRoomPassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            eRoomPassLabel.Name = "eRoomPassLabel";
            eRoomPassLabel.Size = new System.Drawing.Size(71, 13);
            eRoomPassLabel.TabIndex = 7;
            eRoomPassLabel.Text = "ERoom Pass:";
            // 
            // gmailLabel
            // 
            gmailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            gmailLabel.AutoSize = true;
            gmailLabel.Location = new System.Drawing.Point(402, 402);
            gmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            gmailLabel.Name = "gmailLabel";
            gmailLabel.Size = new System.Drawing.Size(36, 13);
            gmailLabel.TabIndex = 9;
            gmailLabel.Text = "Gmail:";
            // 
            // icqNameLabel
            // 
            icqNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            icqNameLabel.AutoSize = true;
            icqNameLabel.Location = new System.Drawing.Point(384, 358);
            icqNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            icqNameLabel.Name = "icqNameLabel";
            icqNameLabel.Size = new System.Drawing.Size(56, 13);
            icqNameLabel.TabIndex = 11;
            icqNameLabel.Text = "Icq Name:";
            // 
            // icqPassLabel
            // 
            icqPassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            icqPassLabel.AutoSize = true;
            icqPassLabel.Location = new System.Drawing.Point(389, 380);
            icqPassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            icqPassLabel.Name = "icqPassLabel";
            icqPassLabel.Size = new System.Drawing.Size(51, 13);
            icqPassLabel.TabIndex = 13;
            icqPassLabel.Text = "Icq Pass:";
            // 
            // domainPassLabel
            // 
            domainPassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            domainPassLabel.AutoSize = true;
            domainPassLabel.Location = new System.Drawing.Point(9, 358);
            domainPassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            domainPassLabel.Name = "domainPassLabel";
            domainPassLabel.Size = new System.Drawing.Size(72, 13);
            domainPassLabel.TabIndex = 15;
            domainPassLabel.Text = "Domain Pass:";
            // 
            // mangoLabel
            // 
            mangoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            mangoLabel.AutoSize = true;
            mangoLabel.Location = new System.Drawing.Point(237, 402);
            mangoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            mangoLabel.Name = "mangoLabel";
            mangoLabel.Size = new System.Drawing.Size(43, 13);
            mangoLabel.TabIndex = 17;
            mangoLabel.Text = "Mango:";
            // 
            // skypeNameLabel
            // 
            skypeNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            skypeNameLabel.AutoSize = true;
            skypeNameLabel.Location = new System.Drawing.Point(552, 358);
            skypeNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            skypeNameLabel.Name = "skypeNameLabel";
            skypeNameLabel.Size = new System.Drawing.Size(71, 13);
            skypeNameLabel.TabIndex = 19;
            skypeNameLabel.Text = "Skype Name:";
            // 
            // skypePassLabel
            // 
            skypePassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            skypePassLabel.AutoSize = true;
            skypePassLabel.Location = new System.Drawing.Point(556, 379);
            skypePassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            skypePassLabel.Name = "skypePassLabel";
            skypePassLabel.Size = new System.Drawing.Size(66, 13);
            skypePassLabel.TabIndex = 21;
            skypePassLabel.Text = "Skype Pass:";
            // 
            // trueCryptPassLabel
            // 
            trueCryptPassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            trueCryptPassLabel.AutoSize = true;
            trueCryptPassLabel.Location = new System.Drawing.Point(212, 380);
            trueCryptPassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            trueCryptPassLabel.Name = "trueCryptPassLabel";
            trueCryptPassLabel.Size = new System.Drawing.Size(67, 13);
            trueCryptPassLabel.TabIndex = 23;
            trueCryptPassLabel.Text = "TCrypt Pass:";
            // 
            // commentsLabel
            // 
            commentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            commentsLabel.AutoSize = true;
            commentsLabel.Location = new System.Drawing.Point(0, 428);
            commentsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            commentsLabel.Name = "commentsLabel";
            commentsLabel.Size = new System.Drawing.Size(80, 13);
            commentsLabel.TabIndex = 29;
            commentsLabel.Text = "Комментарий:";
            // 
            // mobileTelLabel
            // 
            mobileTelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            mobileTelLabel.AutoSize = true;
            mobileTelLabel.Location = new System.Drawing.Point(570, 402);
            mobileTelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            mobileTelLabel.Name = "mobileTelLabel";
            mobileTelLabel.Size = new System.Drawing.Size(51, 13);
            mobileTelLabel.TabIndex = 31;
            mobileTelLabel.Text = "Моб тел:";
            // 
            // empDataGridView
            // 
            this.empDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.empDataGridView.AutoGenerateColumns = false;
            this.empDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.PosId,
            this.DepId,
            this.InternalTel});
            this.empDataGridView.DataSource = this.empBindingSource;
            this.empDataGridView.Location = new System.Drawing.Point(16, 44);
            this.empDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.empDataGridView.Name = "empDataGridView";
            this.empDataGridView.ReadOnly = true;
            this.empDataGridView.RowTemplate.Height = 24;
            this.empDataGridView.Size = new System.Drawing.Size(712, 266);
            this.empDataGridView.TabIndex = 1;
            this.empDataGridView.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.empDataGridView_RowLeave);
            this.empDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empDataGridView_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "LastName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Фамилия";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 81;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 54;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Отчество";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 79;
            // 
            // PosId
            // 
            this.PosId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PosId.DataPropertyName = "PosId";
            this.PosId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.PosId.HeaderText = "Должность";
            this.PosId.Name = "PosId";
            this.PosId.ReadOnly = true;
            this.PosId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PosId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PosId.Width = 90;
            // 
            // DepId
            // 
            this.DepId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DepId.DataPropertyName = "DepId";
            this.DepId.HeaderText = "Отдел";
            this.DepId.Name = "DepId";
            this.DepId.ReadOnly = true;
            this.DepId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DepId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InternalTel
            // 
            this.InternalTel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.InternalTel.DataPropertyName = "InternalTel";
            this.InternalTel.HeaderText = "Вн. тел";
            this.InternalTel.Name = "InternalTel";
            this.InternalTel.ReadOnly = true;
            this.InternalTel.Width = 68;
            // 
            // empBindingSource
            // 
            this.empBindingSource.AllowNew = false;
            this.empBindingSource.DataSource = typeof(BL.Emp);
            this.empBindingSource.CurrentItemChanged += new System.EventHandler(this.empBindingSource_CurrentItemChanged);
            this.empBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.empBindingSource_ListChanged);
            this.empBindingSource.PositionChanged += new System.EventHandler(this.empBindingSource_PositionChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Справочник";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 26);
            // 
            // ItemExit
            // 
            this.ItemExit.Name = "ItemExit";
            this.ItemExit.Size = new System.Drawing.Size(108, 22);
            this.ItemExit.Text = "Выход";
            this.ItemExit.Click += new System.EventHandler(this.ItemExit_Click);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(82, 378);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.ReadOnly = true;
            this.emailTextBox.Size = new System.Drawing.Size(122, 20);
            this.emailTextBox.TabIndex = 3;
            this.emailTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            // 
            // emailPassTextBox
            // 
            this.emailPassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.emailPassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "EmailPass", true));
            this.emailPassTextBox.Location = new System.Drawing.Point(82, 401);
            this.emailPassTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.emailPassTextBox.Name = "emailPassTextBox";
            this.emailPassTextBox.ReadOnly = true;
            this.emailPassTextBox.Size = new System.Drawing.Size(122, 20);
            this.emailPassTextBox.TabIndex = 5;
            this.emailPassTextBox.UseSystemPasswordChar = true;
            // 
            // chbShowPass
            // 
            this.chbShowPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbShowPass.AutoSize = true;
            this.chbShowPass.Location = new System.Drawing.Point(19, 319);
            this.chbShowPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chbShowPass.Name = "chbShowPass";
            this.chbShowPass.Size = new System.Drawing.Size(114, 17);
            this.chbShowPass.TabIndex = 6;
            this.chbShowPass.Text = "Показать пароли";
            this.chbShowPass.UseVisualStyleBackColor = true;
            this.chbShowPass.CheckedChanged += new System.EventHandler(this.chbShowPass_CheckedChanged);
            // 
            // eRoomPassTextBox
            // 
            this.eRoomPassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eRoomPassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "ERoomPass", true));
            this.eRoomPassTextBox.Location = new System.Drawing.Point(281, 355);
            this.eRoomPassTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.eRoomPassTextBox.Name = "eRoomPassTextBox";
            this.eRoomPassTextBox.ReadOnly = true;
            this.eRoomPassTextBox.Size = new System.Drawing.Size(102, 20);
            this.eRoomPassTextBox.TabIndex = 8;
            this.eRoomPassTextBox.UseSystemPasswordChar = true;
            // 
            // gmailTextBox
            // 
            this.gmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gmailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "Gmail", true));
            this.gmailTextBox.Location = new System.Drawing.Point(440, 401);
            this.gmailTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gmailTextBox.Name = "gmailTextBox";
            this.gmailTextBox.ReadOnly = true;
            this.gmailTextBox.Size = new System.Drawing.Size(108, 20);
            this.gmailTextBox.TabIndex = 10;
            // 
            // icqNameTextBox
            // 
            this.icqNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.icqNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "IcqName", true));
            this.icqNameTextBox.Location = new System.Drawing.Point(440, 355);
            this.icqNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.icqNameTextBox.Name = "icqNameTextBox";
            this.icqNameTextBox.ReadOnly = true;
            this.icqNameTextBox.Size = new System.Drawing.Size(108, 20);
            this.icqNameTextBox.TabIndex = 12;
            // 
            // icqPassTextBox
            // 
            this.icqPassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.icqPassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "IcqPass", true));
            this.icqPassTextBox.Location = new System.Drawing.Point(440, 378);
            this.icqPassTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.icqPassTextBox.Name = "icqPassTextBox";
            this.icqPassTextBox.ReadOnly = true;
            this.icqPassTextBox.Size = new System.Drawing.Size(108, 20);
            this.icqPassTextBox.TabIndex = 14;
            this.icqPassTextBox.UseSystemPasswordChar = true;
            // 
            // domainPassTextBox
            // 
            this.domainPassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.domainPassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "DomainPass", true));
            this.domainPassTextBox.Location = new System.Drawing.Point(82, 355);
            this.domainPassTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainPassTextBox.Name = "domainPassTextBox";
            this.domainPassTextBox.ReadOnly = true;
            this.domainPassTextBox.Size = new System.Drawing.Size(122, 20);
            this.domainPassTextBox.TabIndex = 16;
            this.domainPassTextBox.UseSystemPasswordChar = true;
            // 
            // mangoTextBox
            // 
            this.mangoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mangoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "Mango", true));
            this.mangoTextBox.Location = new System.Drawing.Point(281, 401);
            this.mangoTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mangoTextBox.Name = "mangoTextBox";
            this.mangoTextBox.ReadOnly = true;
            this.mangoTextBox.Size = new System.Drawing.Size(102, 20);
            this.mangoTextBox.TabIndex = 18;
            this.mangoTextBox.UseSystemPasswordChar = true;
            // 
            // skypeNameTextBox
            // 
            this.skypeNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.skypeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "SkypeName", true));
            this.skypeNameTextBox.Location = new System.Drawing.Point(623, 355);
            this.skypeNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.skypeNameTextBox.Name = "skypeNameTextBox";
            this.skypeNameTextBox.ReadOnly = true;
            this.skypeNameTextBox.Size = new System.Drawing.Size(104, 20);
            this.skypeNameTextBox.TabIndex = 20;
            // 
            // skypePassTextBox
            // 
            this.skypePassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.skypePassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "SkypePass", true));
            this.skypePassTextBox.Location = new System.Drawing.Point(623, 378);
            this.skypePassTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.skypePassTextBox.Name = "skypePassTextBox";
            this.skypePassTextBox.ReadOnly = true;
            this.skypePassTextBox.Size = new System.Drawing.Size(104, 20);
            this.skypePassTextBox.TabIndex = 22;
            this.skypePassTextBox.UseSystemPasswordChar = true;
            // 
            // trueCryptPassTextBox
            // 
            this.trueCryptPassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trueCryptPassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "TrueCryptPass", true));
            this.trueCryptPassTextBox.Location = new System.Drawing.Point(281, 378);
            this.trueCryptPassTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trueCryptPassTextBox.Name = "trueCryptPassTextBox";
            this.trueCryptPassTextBox.ReadOnly = true;
            this.trueCryptPassTextBox.Size = new System.Drawing.Size(102, 20);
            this.trueCryptPassTextBox.TabIndex = 24;
            this.trueCryptPassTextBox.UseSystemPasswordChar = true;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(70, 15);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(240, 20);
            this.textBoxSearch.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Поиск:";
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commentsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "Comments", true));
            this.commentsTextBox.Location = new System.Drawing.Point(82, 426);
            this.commentsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.commentsTextBox.Multiline = true;
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.ReadOnly = true;
            this.commentsTextBox.Size = new System.Drawing.Size(644, 38);
            this.commentsTextBox.TabIndex = 30;
            // 
            // mobileTelTextBox
            // 
            this.mobileTelTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mobileTelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empBindingSource, "MobileTel", true));
            this.mobileTelTextBox.Location = new System.Drawing.Point(623, 401);
            this.mobileTelTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mobileTelTextBox.Name = "mobileTelTextBox";
            this.mobileTelTextBox.ReadOnly = true;
            this.mobileTelTextBox.Size = new System.Drawing.Size(104, 20);
            this.mobileTelTextBox.TabIndex = 32;
            // 
            // ClearButton
            // 
            this.ClearButton.Image = global::WFAdmin.Properties.Resources.clear_left;
            this.ClearButton.Location = new System.Drawing.Point(315, 14);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(30, 20);
            this.ClearButton.TabIndex = 34;
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Editbutton
            // 
            this.Editbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Editbutton.Image = global::WFAdmin.Properties.Resources.edit1;
            this.Editbutton.Location = new System.Drawing.Point(612, 318);
            this.Editbutton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Editbutton.Name = "Editbutton";
            this.Editbutton.Size = new System.Drawing.Size(56, 24);
            this.Editbutton.TabIndex = 33;
            this.Editbutton.UseVisualStyleBackColor = true;
            this.Editbutton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Image = global::WFAdmin.Properties.Resources.save_64;
            this.buttonSave.Location = new System.Drawing.Point(554, 318);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(52, 24);
            this.buttonSave.TabIndex = 28;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNew.Image = global::WFAdmin.Properties.Resources.document_add;
            this.buttonAddNew.Location = new System.Drawing.Point(673, 318);
            this.buttonAddNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(55, 24);
            this.buttonAddNew.TabIndex = 27;
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.button1_Click);
            // 
            // HideInSprcheckBox
            // 
            this.HideInSprcheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HideInSprcheckBox.AutoSize = true;
            this.HideInSprcheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.empBindingSource, "HideInSpr", true));
            this.HideInSprcheckBox.Enabled = false;
            this.HideInSprcheckBox.Location = new System.Drawing.Point(281, 325);
            this.HideInSprcheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.HideInSprcheckBox.Name = "HideInSprcheckBox";
            this.HideInSprcheckBox.Size = new System.Drawing.Size(135, 17);
            this.HideInSprcheckBox.TabIndex = 35;
            this.HideInSprcheckBox.Text = "Скрыть в справчнике";
            this.HideInSprcheckBox.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 470);
            this.Controls.Add(this.HideInSprcheckBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.Editbutton);
            this.Controls.Add(mobileTelLabel);
            this.Controls.Add(this.mobileTelTextBox);
            this.Controls.Add(commentsLabel);
            this.Controls.Add(this.commentsTextBox);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAddNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(trueCryptPassLabel);
            this.Controls.Add(this.trueCryptPassTextBox);
            this.Controls.Add(skypePassLabel);
            this.Controls.Add(this.skypePassTextBox);
            this.Controls.Add(skypeNameLabel);
            this.Controls.Add(this.skypeNameTextBox);
            this.Controls.Add(mangoLabel);
            this.Controls.Add(this.mangoTextBox);
            this.Controls.Add(domainPassLabel);
            this.Controls.Add(this.domainPassTextBox);
            this.Controls.Add(icqPassLabel);
            this.Controls.Add(this.icqPassTextBox);
            this.Controls.Add(icqNameLabel);
            this.Controls.Add(this.icqNameTextBox);
            this.Controls.Add(gmailLabel);
            this.Controls.Add(this.gmailTextBox);
            this.Controls.Add(eRoomPassLabel);
            this.Controls.Add(this.eRoomPassTextBox);
            this.Controls.Add(this.chbShowPass);
            this.Controls.Add(emailPassLabel);
            this.Controls.Add(this.emailPassTextBox);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.empDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdmSpr";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.empDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource empBindingSource;
        private System.Windows.Forms.DataGridView empDataGridView;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ItemExit;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox emailPassTextBox;
        private System.Windows.Forms.CheckBox chbShowPass;
        private System.Windows.Forms.TextBox eRoomPassTextBox;
        private System.Windows.Forms.TextBox gmailTextBox;
        private System.Windows.Forms.TextBox icqNameTextBox;
        private System.Windows.Forms.TextBox icqPassTextBox;
        private System.Windows.Forms.TextBox domainPassTextBox;
        private System.Windows.Forms.TextBox mangoTextBox;
        private System.Windows.Forms.TextBox skypeNameTextBox;
        private System.Windows.Forms.TextBox skypePassTextBox;
        private System.Windows.Forms.TextBox trueCryptPassTextBox;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn PosId;
        private System.Windows.Forms.DataGridViewComboBoxColumn DepId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternalTel;
        private System.Windows.Forms.TextBox commentsTextBox;
        private System.Windows.Forms.TextBox mobileTelTextBox;
        private System.Windows.Forms.Button Editbutton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox HideInSprcheckBox;
    }
}