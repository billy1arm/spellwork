namespace SpellWork
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._status = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._rtSpellInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._lvSpellList = new System.Windows.Forms.ListView();
            this.chSpellID = new System.Windows.Forms.ColumnHeader();
            this.chSpellName = new System.Windows.Forms.ColumnHeader();
            this.chSpellFamily = new System.Windows.Forms.ColumnHeader();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._cbTarget2 = new System.Windows.Forms.ComboBox();
            this._cbTarget1 = new System.Windows.Forms.ComboBox();
            this._cbSpellEffect = new System.Windows.Forms.ComboBox();
            this._cbSpellAura = new System.Windows.Forms.ComboBox();
            this._cbSpellFamilyNames = new System.Windows.Forms.ComboBox();
            this._bSearch = new System.Windows.Forms.Button();
            this._tbSearch = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this._bProcFlag = new System.Windows.Forms.Button();
            this._clbProcFlaf = new System.Windows.Forms.CheckedListBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this._tvFamilyMask = new System.Windows.Forms.TreeView();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this._lvFiltredSpell = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this._chID = new System.Windows.Forms.ColumnHeader();
            this._chName = new System.Windows.Forms.ColumnHeader();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this._bProc = new System.Windows.Forms.Button();
            this._bSpellInfo = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 434);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(856, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _status
            // 
            this._status.Name = "_status";
            this._status.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(856, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(856, 410);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(848, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Spell Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._rtSpellInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(842, 378);
            this.splitContainer1.SplitterDistance = 564;
            this.splitContainer1.TabIndex = 0;
            // 
            // _rtSpellInfo
            // 
            this._rtSpellInfo.BackColor = System.Drawing.Color.Gainsboro;
            this._rtSpellInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtSpellInfo.Location = new System.Drawing.Point(0, 0);
            this._rtSpellInfo.Name = "_rtSpellInfo";
            this._rtSpellInfo.Size = new System.Drawing.Size(564, 378);
            this._rtSpellInfo.TabIndex = 0;
            this._rtSpellInfo.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._lvSpellList);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this._cbTarget2);
            this.groupBox1.Controls.Add(this._cbTarget1);
            this.groupBox1.Controls.Add(this._cbSpellEffect);
            this.groupBox1.Controls.Add(this._cbSpellAura);
            this.groupBox1.Controls.Add(this._cbSpellFamilyNames);
            this.groupBox1.Controls.Add(this._bSearch);
            this.groupBox1.Controls.Add(this._tbSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 378);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // _lvSpellList
            // 
            this._lvSpellList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lvSpellList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSpellID,
            this.chSpellName,
            this.chSpellFamily});
            this._lvSpellList.FullRowSelect = true;
            this._lvSpellList.GridLines = true;
            this._lvSpellList.Location = new System.Drawing.Point(0, 179);
            this._lvSpellList.MultiSelect = false;
            this._lvSpellList.Name = "_lvSpellList";
            this._lvSpellList.Size = new System.Drawing.Size(277, 199);
            this._lvSpellList.TabIndex = 7;
            this._lvSpellList.UseCompatibleStateImageBehavior = false;
            this._lvSpellList.View = System.Windows.Forms.View.Details;
            this._lvSpellList.SelectedIndexChanged += new System.EventHandler(this._lvSpellList_SelectedIndexChanged);
            // 
            // chSpellID
            // 
            this.chSpellID.Text = "ID";
            // 
            // chSpellName
            // 
            this.chSpellName.Text = "Название";
            this.chSpellName.Width = 200;
            // 
            // chSpellFamily
            // 
            this.chSpellFamily.Text = "SpellFamily";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1, 153);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(271, 20);
            this.textBox1.TabIndex = 6;
            // 
            // _cbTarget2
            // 
            this._cbTarget2.FormattingEnabled = true;
            this._cbTarget2.Location = new System.Drawing.Point(150, 126);
            this._cbTarget2.Name = "_cbTarget2";
            this._cbTarget2.Size = new System.Drawing.Size(121, 21);
            this._cbTarget2.TabIndex = 5;
            // 
            // _cbTarget1
            // 
            this._cbTarget1.FormattingEnabled = true;
            this._cbTarget1.Location = new System.Drawing.Point(1, 126);
            this._cbTarget1.Name = "_cbTarget1";
            this._cbTarget1.Size = new System.Drawing.Size(126, 21);
            this._cbTarget1.TabIndex = 5;
            // 
            // _cbSpellEffect
            // 
            this._cbSpellEffect.FormattingEnabled = true;
            this._cbSpellEffect.Location = new System.Drawing.Point(1, 99);
            this._cbSpellEffect.Name = "_cbSpellEffect";
            this._cbSpellEffect.Size = new System.Drawing.Size(265, 21);
            this._cbSpellEffect.TabIndex = 4;
            // 
            // _cbSpellAura
            // 
            this._cbSpellAura.FormattingEnabled = true;
            this._cbSpellAura.Location = new System.Drawing.Point(1, 72);
            this._cbSpellAura.Name = "_cbSpellAura";
            this._cbSpellAura.Size = new System.Drawing.Size(265, 21);
            this._cbSpellAura.TabIndex = 3;
            this._cbSpellAura.SelectedIndexChanged += new System.EventHandler(this._cbSpellAura_SelectedIndexChanged);
            // 
            // _cbSpellFamilyNames
            // 
            this._cbSpellFamilyNames.FormattingEnabled = true;
            this._cbSpellFamilyNames.Location = new System.Drawing.Point(1, 45);
            this._cbSpellFamilyNames.Name = "_cbSpellFamilyNames";
            this._cbSpellFamilyNames.Size = new System.Drawing.Size(265, 21);
            this._cbSpellFamilyNames.TabIndex = 2;
            this._cbSpellFamilyNames.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _bSearch
            // 
            this._bSearch.Location = new System.Drawing.Point(196, 17);
            this._bSearch.Name = "_bSearch";
            this._bSearch.Size = new System.Drawing.Size(75, 23);
            this._bSearch.TabIndex = 1;
            this._bSearch.Text = "Поиск";
            this._bSearch.UseVisualStyleBackColor = true;
            this._bSearch.Click += new System.EventHandler(this._bSearch_Click);
            // 
            // _tbSearch
            // 
            this._tbSearch.Location = new System.Drawing.Point(1, 19);
            this._tbSearch.Name = "_tbSearch";
            this._tbSearch.Size = new System.Drawing.Size(184, 20);
            this._tbSearch.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(848, 384);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Spell Proc Event";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Panel2.Controls.Add(this.listView2);
            this.splitContainer2.Size = new System.Drawing.Size(848, 384);
            this.splitContainer2.SplitterDistance = 338;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer3.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(848, 338);
            this.splitContainer3.SplitterDistance = 94;
            this.splitContainer3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 94);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this._bProcFlag);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this._clbProcFlaf);
            this.splitContainer6.Size = new System.Drawing.Size(848, 94);
            this.splitContainer6.SplitterDistance = 45;
            this.splitContainer6.TabIndex = 0;
            // 
            // _bProcFlag
            // 
            this._bProcFlag.Location = new System.Drawing.Point(816, 3);
            this._bProcFlag.Name = "_bProcFlag";
            this._bProcFlag.Size = new System.Drawing.Size(29, 23);
            this._bProcFlag.TabIndex = 0;
            this._bProcFlag.Text = "button2";
            this._bProcFlag.UseVisualStyleBackColor = true;
            this._bProcFlag.Click += new System.EventHandler(this._bProcFlag_Click);
            // 
            // _clbProcFlaf
            // 
            this._clbProcFlaf.ColumnWidth = 250;
            this._clbProcFlaf.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clbProcFlaf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._clbProcFlaf.FormattingEnabled = true;
            this._clbProcFlaf.Location = new System.Drawing.Point(0, 0);
            this._clbProcFlaf.MultiColumn = true;
            this._clbProcFlaf.Name = "_clbProcFlaf";
            this._clbProcFlaf.Size = new System.Drawing.Size(848, 34);
            this._clbProcFlaf.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer4.Panel1.Controls.Add(this.comboBox4);
            this.splitContainer4.Panel1.Controls.Add(this._tvFamilyMask);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(848, 240);
            this.splitContainer4.SplitterDistance = 194;
            this.splitContainer4.TabIndex = 0;
            // 
            // comboBox4
            // 
            this.comboBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(0, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(193, 21);
            this.comboBox4.TabIndex = 1;
            // 
            // _tvFamilyMask
            // 
            this._tvFamilyMask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tvFamilyMask.Location = new System.Drawing.Point(1, 25);
            this._tvFamilyMask.Name = "_tvFamilyMask";
            this._tvFamilyMask.Size = new System.Drawing.Size(192, 215);
            this._tvFamilyMask.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.richTextBox1);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer5.Panel2.Controls.Add(this.button1);
            this.splitContainer5.Panel2.Controls.Add(this.textBox2);
            this.splitContainer5.Panel2.Controls.Add(this.comboBox3);
            this.splitContainer5.Panel2.Controls.Add(this.comboBox2);
            this.splitContainer5.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer5.Panel2.Controls.Add(this._lvFiltredSpell);
            this.splitContainer5.Size = new System.Drawing.Size(650, 240);
            this.splitContainer5.SplitterDistance = 420;
            this.splitContainer5.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(420, 240);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(177, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(3, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(171, 20);
            this.textBox2.TabIndex = 4;
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(3, 68);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(220, 21);
            this.comboBox3.TabIndex = 3;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(3, 46);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(220, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // _lvFiltredSpell
            // 
            this._lvFiltredSpell.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lvFiltredSpell.Location = new System.Drawing.Point(3, 91);
            this._lvFiltredSpell.Name = "_lvFiltredSpell";
            this._lvFiltredSpell.Size = new System.Drawing.Size(220, 149);
            this._lvFiltredSpell.TabIndex = 0;
            this._lvFiltredSpell.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._chID,
            this._chName});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(848, 42);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // _chID
            // 
            this._chID.Text = "Entry";
            this._chID.Width = 100;
            // 
            // _chName
            // 
            this._chName.Text = "Name";
            this._chName.Width = 685;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(848, 384);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Update Log";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(848, 384);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Location = new System.Drawing.Point(3, 43);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(844, 345);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // _bProc
            // 
            this._bProc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bProc.Location = new System.Drawing.Point(820, 0);
            this._bProc.Name = "_bProc";
            this._bProc.Size = new System.Drawing.Size(19, 23);
            this._bProc.TabIndex = 3;
            this._bProc.Text = "_";
            this._bProc.UseVisualStyleBackColor = true;
            this._bProc.Visible = false;
            this._bProc.Click += new System.EventHandler(this._bProc_Click);
            // 
            // _bSpellInfo
            // 
            this._bSpellInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._bSpellInfo.Location = new System.Drawing.Point(820, 433);
            this._bSpellInfo.Name = "_bSpellInfo";
            this._bSpellInfo.Size = new System.Drawing.Size(19, 23);
            this._bSpellInfo.TabIndex = 4;
            this._bSpellInfo.Text = "_";
            this._bSpellInfo.UseVisualStyleBackColor = true;
            this._bSpellInfo.Visible = false;
            this._bSpellInfo.Click += new System.EventHandler(this._bSpellInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 456);
            this.Controls.Add(this._bSpellInfo);
            this.Controls.Add(this._bProc);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            this.splitContainer5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox _rtSpellInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _bSearch;
        private System.Windows.Forms.TextBox _tbSearch;
        private System.Windows.Forms.ComboBox _cbSpellFamilyNames;
        private System.Windows.Forms.ListView _lvSpellList;
        private System.Windows.Forms.ColumnHeader chSpellID;
        private System.Windows.Forms.ColumnHeader chSpellName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox _cbTarget2;
        private System.Windows.Forms.ComboBox _cbTarget1;
        private System.Windows.Forms.ComboBox _cbSpellEffect;
        private System.Windows.Forms.ComboBox _cbSpellAura;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ColumnHeader chSpellFamily;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button _bProc;
        private System.Windows.Forms.Button _bSpellInfo;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView _lvFiltredSpell;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.TreeView _tvFamilyMask;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ColumnHeader _chID;
        private System.Windows.Forms.ColumnHeader _chName;
        private System.Windows.Forms.ToolStripStatusLabel _status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox _clbProcFlaf;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Button _bProcFlag;
    }
}

