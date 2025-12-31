using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ledger
{
    public partial class Form1 : Form
    {
        private BindingList<Transaction> _bindingList = new BindingList<Transaction>();
        private List<Transaction> _allTransactions = new List<Transaction>();

        public Form1()
        {
            InitializeComponent();
            InitializeCustomLogic();
        }

        private void InitializeCustomLogic()
        {
            // DataGridView setup
            dataGridViewTransactions.AutoGenerateColumns = false;

            // Add basic columns if none defined
            if (dataGridViewTransactions.Columns.Count == 0)
            {
                dataGridViewTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Date", HeaderText = "日期", Width = 120 });
                dataGridViewTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Type", HeaderText = "类型", Width = 80 });
                dataGridViewTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "金额", Width = 100 });
                dataGridViewTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Counterparty", HeaderText = "交易对象", Width = 120 });
                dataGridViewTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "分类", Width = 120 });
                dataGridViewTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Remark", HeaderText = "备注", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            }

            dataGridViewTransactions.DataSource = _bindingList;

            // Wire up button events
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnLoad.Click += BtnLoad_Click;

            dataGridViewTransactions.CellDoubleClick += DataGridViewTransactions_CellDoubleClick;

            // Filter events
            btnApplyFilter.Click += BtnApplyFilter_Click;
            btnClearFilter.Click += BtnClearFilter_Click;
            chkDateFilter.CheckedChanged += FilterOptionsChanged;
            chkAmountFilter.CheckedChanged += FilterOptionsChanged;
            comboBoxTypeFilter.SelectedIndexChanged += FilterOptionsChanged;
            dateTimePickerFrom.ValueChanged += FilterOptionsChanged;
            dateTimePickerTo.ValueChanged += FilterOptionsChanged;
            numAmountMin.ValueChanged += FilterOptionsChanged;
            numAmountMax.ValueChanged += FilterOptionsChanged;

            // init sample data or load
            LoadTransactionsSample();
            UpdateStatusSummary();
            UpdateFilterControlsState();
        }

        private void LoadTransactionsSample()
        {
            // keep empty initial list; you may replace with real load
            _allTransactions = new List<Transaction>();
            _bindingList = new BindingList<Transaction>(_allTransactions);
            dataGridViewTransactions.DataSource = _bindingList;
        }

        private void DataGridViewTransactions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditSelected();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var form = new TransactionForm(new Transaction());
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _allTransactions.Add(form.Transaction);
                _bindingList.Add(form.Transaction);
                UpdateStatusSummary();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void EditSelected()
        {
            if (dataGridViewTransactions.CurrentRow == null) return;
            var t = dataGridViewTransactions.CurrentRow.DataBoundItem as Transaction;
            if (t == null) return;

            // copy a temp
            var temp = new Transaction
            {
                Id = t.Id,
                Date = t.Date,
                Amount = t.Amount,
                Type = t.Type,
                Counterparty = t.Counterparty,
                Category = t.Category,
                Remark = t.Remark
            };

            var form = new TransactionForm(temp);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                // apply
                t.Date = form.Transaction.Date;
                t.Amount = form.Transaction.Amount;
                t.Type = form.Transaction.Type;
                t.Counterparty = form.Transaction.Counterparty;
                t.Category = form.Transaction.Category;
                t.Remark = form.Transaction.Remark;

                // update master list item
                var idx = _allTransactions.FindIndex(x => x.Id == t.Id);
                if (idx >= 0) _allTransactions[idx] = t;

                dataGridViewTransactions.Refresh();
                UpdateStatusSummary();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactions.CurrentRow == null) return;
            var t = dataGridViewTransactions.CurrentRow.DataBoundItem as Transaction;
            if (t == null) return;
            if (MessageBox.Show(this, "确认删除选中的记录？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _bindingList.Remove(t);
                _allTransactions.RemoveAll(x => x.Id == t.Id);
                UpdateStatusSummary();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "保存功能尚未实现。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "加载功能尚未实现。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BtnClearFilter_Click(object sender, EventArgs e)
        {
            // reset filter controls
            chkDateFilter.Checked = false;
            chkAmountFilter.Checked = false;
            comboBoxTypeFilter.SelectedIndex = 0;
            dateTimePickerFrom.Value = DateTime.Today.AddMonths(-1);
            dateTimePickerTo.Value = DateTime.Today;
            numAmountMin.Value = 0;
            numAmountMax.Value = 0;

            ApplyFilters();
        }

        private void FilterOptionsChanged(object sender, EventArgs e)
        {
            UpdateFilterControlsState();
        }

        private void UpdateFilterControlsState()
        {
            // enable/disable controls based on checkboxes
            dateTimePickerFrom.Enabled = chkDateFilter.Checked;
            dateTimePickerTo.Enabled = chkDateFilter.Checked;
            numAmountMin.Enabled = chkAmountFilter.Checked;
            numAmountMax.Enabled = chkAmountFilter.Checked;

            // Enable apply button only if any filter active or type not All
            btnApplyFilter.Enabled = chkDateFilter.Checked || chkAmountFilter.Checked || (comboBoxTypeFilter.SelectedIndex > 0);
        }

        private void ApplyFilters()
        {
            IEnumerable<Transaction> query = _allTransactions;

            if (chkDateFilter.Checked)
            {
                var from = dateTimePickerFrom.Value.Date;
                var to = dateTimePickerTo.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(x => x.Date >= from && x.Date <= to);
            }

            if (comboBoxTypeFilter.SelectedIndex == 1) // Income
            {
                query = query.Where(x => string.Equals(x.Type, "Income", StringComparison.OrdinalIgnoreCase));
            }
            else if (comboBoxTypeFilter.SelectedIndex == 2) // Expense
            {
                query = query.Where(x => string.Equals(x.Type, "Expense", StringComparison.OrdinalIgnoreCase));
            }

            if (chkAmountFilter.Checked)
            {
                var min = numAmountMin.Value;
                var max = numAmountMax.Value;
                if (min > 0 || max > 0)
                {
                    if (min > 0) query = query.Where(x => x.Amount >= min);
                    if (max > 0) query = query.Where(x => x.Amount <= max);
                }
            }

            var result = query.ToList();
            _bindingList = new BindingList<Transaction>(result);
            dataGridViewTransactions.DataSource = _bindingList;
            UpdateStatusSummary();
        }

        private void UpdateStatusSummary()
        {
            int count = _bindingList.Count;
            decimal sum = _bindingList.Sum(x => x.Amount);
            toolStripStatusLabelSummary.Text = $"共 {count} 条，收支合计：{sum:F2}";
        }

        private void labelDateFrom_Click(object sender, EventArgs e)
        {

        }
    }
}
