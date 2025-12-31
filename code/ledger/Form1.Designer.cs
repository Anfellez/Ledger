namespace ledger
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.chkAmountFilter = new System.Windows.Forms.CheckBox();
            this.chkDateFilter = new System.Windows.Forms.CheckBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.numAmountMax = new System.Windows.Forms.NumericUpDown();
            this.numAmountMin = new System.Windows.Forms.NumericUpDown();
            this.labelAmountDash = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.comboBoxTypeFilter = new System.Windows.Forms.ComboBox();
            this.labelTypeFilter = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelDateTo = new System.Windows.Forms.Label();
            this.labelDateFrom = new System.Windows.Forms.Label();
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSummary = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.ColumnCount = 5;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelTop.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.btnEdit, 1, 0);
            this.tableLayoutPanelTop.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanelTop.Controls.Add(this.btnSave, 3, 0);
            this.tableLayoutPanelTop.Controls.Add(this.btnLoad, 4, 0);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 1;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1646, 100);
            this.tableLayoutPanelTop.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(8, 8);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(313, 84);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(337, 8);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(313, 84);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(666, 8);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(313, 84);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(995, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(313, 84);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoad.Location = new System.Drawing.Point(1324, 8);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(8);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(314, 84);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "加载";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.chkAmountFilter);
            this.panelFilter.Controls.Add(this.chkDateFilter);
            this.panelFilter.Controls.Add(this.btnClearFilter);
            this.panelFilter.Controls.Add(this.btnApplyFilter);
            this.panelFilter.Controls.Add(this.numAmountMax);
            this.panelFilter.Controls.Add(this.numAmountMin);
            this.panelFilter.Controls.Add(this.labelAmountDash);
            this.panelFilter.Controls.Add(this.labelAmount);
            this.panelFilter.Controls.Add(this.comboBoxTypeFilter);
            this.panelFilter.Controls.Add(this.labelTypeFilter);
            this.panelFilter.Controls.Add(this.dateTimePickerTo);
            this.panelFilter.Controls.Add(this.dateTimePickerFrom);
            this.panelFilter.Controls.Add(this.labelDateTo);
            this.panelFilter.Controls.Add(this.labelDateFrom);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 100);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(6);
            this.panelFilter.Size = new System.Drawing.Size(1646, 56);
            this.panelFilter.TabIndex = 1;
            // 
            // chkAmountFilter
            // 
            this.chkAmountFilter.AutoSize = true;
            this.chkAmountFilter.Location = new System.Drawing.Point(829, 9);
            this.chkAmountFilter.Name = "chkAmountFilter";
            this.chkAmountFilter.Size = new System.Drawing.Size(114, 28);
            this.chkAmountFilter.TabIndex = 0;
            this.chkAmountFilter.Text = "按金额";
            this.chkAmountFilter.UseVisualStyleBackColor = true;
            // 
            // chkDateFilter
            // 
            this.chkDateFilter.AutoSize = true;
            this.chkDateFilter.Location = new System.Drawing.Point(16, 18);
            this.chkDateFilter.Name = "chkDateFilter";
            this.chkDateFilter.Size = new System.Drawing.Size(114, 28);
            this.chkDateFilter.TabIndex = 1;
            this.chkDateFilter.Text = "按时间";
            this.chkDateFilter.UseVisualStyleBackColor = true;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClearFilter.Location = new System.Drawing.Point(1532, 12);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(96, 32);
            this.btnClearFilter.TabIndex = 13;
            this.btnClearFilter.Text = "清除";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnApplyFilter.Location = new System.Drawing.Point(1430, 12);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(96, 32);
            this.btnApplyFilter.TabIndex = 12;
            this.btnApplyFilter.Text = "筛选";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            // 
            // numAmountMax
            // 
            this.numAmountMax.DecimalPlaces = 2;
            this.numAmountMax.Location = new System.Drawing.Point(1120, 9);
            this.numAmountMax.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numAmountMax.Name = "numAmountMax";
            this.numAmountMax.Size = new System.Drawing.Size(120, 35);
            this.numAmountMax.TabIndex = 14;
            // 
            // numAmountMin
            // 
            this.numAmountMin.DecimalPlaces = 2;
            this.numAmountMin.Location = new System.Drawing.Point(949, 4);
            this.numAmountMin.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numAmountMin.Name = "numAmountMin";
            this.numAmountMin.Size = new System.Drawing.Size(120, 35);
            this.numAmountMin.TabIndex = 15;
            // 
            // labelAmountDash
            // 
            this.labelAmountDash.AutoSize = true;
            this.labelAmountDash.Location = new System.Drawing.Point(1075, 15);
            this.labelAmountDash.Name = "labelAmountDash";
            this.labelAmountDash.Size = new System.Drawing.Size(22, 24);
            this.labelAmountDash.TabIndex = 16;
            this.labelAmountDash.Text = "-";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(741, 9);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(82, 24);
            this.labelAmount.TabIndex = 17;
            this.labelAmount.Text = "金额：";
            // 
            // comboBoxTypeFilter
            // 
            this.comboBoxTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeFilter.Items.AddRange(new object[] {
            "All",
            "Income",
            "Expense"});
            this.comboBoxTypeFilter.Location = new System.Drawing.Point(585, 6);
            this.comboBoxTypeFilter.Name = "comboBoxTypeFilter";
            this.comboBoxTypeFilter.Size = new System.Drawing.Size(100, 32);
            this.comboBoxTypeFilter.TabIndex = 18;
            // 
            // labelTypeFilter
            // 
            this.labelTypeFilter.AutoSize = true;
            this.labelTypeFilter.Location = new System.Drawing.Point(497, 6);
            this.labelTypeFilter.Name = "labelTypeFilter";
            this.labelTypeFilter.Size = new System.Drawing.Size(82, 24);
            this.labelTypeFilter.TabIndex = 19;
            this.labelTypeFilter.Text = "类型：";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(362, 8);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(110, 35);
            this.dateTimePickerTo.TabIndex = 20;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(206, 8);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(110, 35);
            this.dateTimePickerFrom.TabIndex = 21;
            // 
            // labelDateTo
            // 
            this.labelDateTo.AutoSize = true;
            this.labelDateTo.Location = new System.Drawing.Point(322, 13);
            this.labelDateTo.Name = "labelDateTo";
            this.labelDateTo.Size = new System.Drawing.Size(34, 24);
            this.labelDateTo.TabIndex = 22;
            this.labelDateTo.Text = "至";
            // 
            // labelDateFrom
            // 
            this.labelDateFrom.AutoSize = true;
            this.labelDateFrom.Location = new System.Drawing.Point(142, 14);
            this.labelDateFrom.Name = "labelDateFrom";
            this.labelDateFrom.Size = new System.Drawing.Size(58, 24);
            this.labelDateFrom.TabIndex = 23;
            this.labelDateFrom.Text = "从：";
            this.labelDateFrom.Click += new System.EventHandler(this.labelDateFrom_Click);
            // 
            // dataGridViewTransactions
            // 
            this.dataGridViewTransactions.AllowUserToAddRows = false;
            this.dataGridViewTransactions.AllowUserToDeleteRows = false;
            this.dataGridViewTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTransactions.Location = new System.Drawing.Point(0, 156);
            this.dataGridViewTransactions.MultiSelect = false;
            this.dataGridViewTransactions.Name = "dataGridViewTransactions";
            this.dataGridViewTransactions.ReadOnly = true;
            this.dataGridViewTransactions.RowHeadersWidth = 82;
            this.dataGridViewTransactions.RowTemplate.Height = 36;
            this.dataGridViewTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTransactions.Size = new System.Drawing.Size(1646, 716);
            this.dataGridViewTransactions.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSummary});
            this.statusStrip1.Location = new System.Drawing.Point(0, 872);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1646, 41);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelSummary
            // 
            this.toolStripStatusLabelSummary.Name = "toolStripStatusLabelSummary";
            this.toolStripStatusLabelSummary.Size = new System.Drawing.Size(275, 31);
            this.toolStripStatusLabelSummary.Text = "共0 条，收支合计：0.00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1646, 913);
            this.Controls.Add(this.dataGridViewTransactions);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.tableLayoutPanelTop);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "记账本";
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.Label labelDateFrom;
        private System.Windows.Forms.ComboBox comboBoxTypeFilter;
        private System.Windows.Forms.Label labelTypeFilter;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelAmountDash;
        private System.Windows.Forms.NumericUpDown numAmountMax;
        private System.Windows.Forms.NumericUpDown numAmountMin;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.CheckBox chkAmountFilter;
        private System.Windows.Forms.CheckBox chkDateFilter;
        private System.Windows.Forms.DataGridView dataGridViewTransactions;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSummary;
    }
}

