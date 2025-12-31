using System;
using System.Windows.Forms;

namespace ledger
{
 public partial class TransactionForm : Form
 {
 public Transaction Transaction { get; private set; }

 public TransactionForm()
 {
 InitializeComponent();
 }

 public TransactionForm(Transaction t) : this()
 {
 Transaction = t ?? new Transaction();
 dateTimePickerDate.Value = Transaction.Date;
 comboBoxType.SelectedItem = Transaction.Type ?? "Expense";
 textBoxCounterparty.Text = Transaction.Counterparty;
 textBoxCategory.Text = Transaction.Category;
 numericUpDownAmount.Value = Transaction.Amount;
 textBoxRemark.Text = Transaction.Remark;
 }

 private void btnOk_Click(object sender, EventArgs e)
 {
 // Validation
 if (string.IsNullOrWhiteSpace(comboBoxType.Text))
 {
 MessageBox.Show(this, "请选择 收入/支出 类型。", "验证", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
 }
 if (string.IsNullOrWhiteSpace(textBoxCounterparty.Text))
 {
 MessageBox.Show(this, "请输入交易对象。", "验证", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
 }
 if (string.IsNullOrWhiteSpace(textBoxCategory.Text))
 {
 MessageBox.Show(this, "请输入分类。", "验证", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
 }
 if (numericUpDownAmount.Value <=0)
 {
 MessageBox.Show(this, "请输入大于0 的金额。", "验证", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
 }

 // apply
 if (Transaction == null) Transaction = new Transaction();
 Transaction.Date = dateTimePickerDate.Value;
 Transaction.Type = comboBoxType.Text;
 Transaction.Counterparty = textBoxCounterparty.Text.Trim();
 Transaction.Category = textBoxCategory.Text.Trim();
 Transaction.Amount = numericUpDownAmount.Value;
 Transaction.Remark = textBoxRemark.Text.Trim();

 DialogResult = DialogResult.OK;
 Close();
 }

 private void btnCancel_Click(object sender, EventArgs e)
 {
 DialogResult = DialogResult.Cancel;
 Close();
 }

 private void InitializeComponent()
 {
 this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
 this.comboBoxType = new System.Windows.Forms.ComboBox();
 this.textBoxCounterparty = new System.Windows.Forms.TextBox();
 this.textBoxCategory = new System.Windows.Forms.TextBox();
 this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
 this.textBoxRemark = new System.Windows.Forms.TextBox();
 this.btnOk = new System.Windows.Forms.Button();
 this.btnCancel = new System.Windows.Forms.Button();
 this.labelDate = new System.Windows.Forms.Label();
 this.labelType = new System.Windows.Forms.Label();
 this.labelCounterparty = new System.Windows.Forms.Label();
 this.labelCategory = new System.Windows.Forms.Label();
 this.labelAmount = new System.Windows.Forms.Label();
 this.labelRemark = new System.Windows.Forms.Label();
 this.toolTip1 = new System.Windows.Forms.ToolTip();
 ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
 this.SuspendLayout();
 // 
 // dateTimePickerDate
 // 
 this.dateTimePickerDate.Location = new System.Drawing.Point(120,12);
 this.dateTimePickerDate.Name = "dateTimePickerDate";
 this.dateTimePickerDate.Size = new System.Drawing.Size(252,28);
 // 
 // comboBoxType
 // 
 this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
 this.comboBoxType.Items.AddRange(new object[] { "Income", "Expense" });
 this.comboBoxType.Location = new System.Drawing.Point(120,52);
 this.comboBoxType.Name = "comboBoxType";
 this.comboBoxType.Size = new System.Drawing.Size(120,28);
 this.comboBoxType.SelectedIndex =1; // default Expense
 // 
 // textBoxCounterparty
 // 
 this.textBoxCounterparty.Location = new System.Drawing.Point(120,92);
 this.textBoxCounterparty.Name = "textBoxCounterparty";
 this.textBoxCounterparty.Size = new System.Drawing.Size(252,28);
 // 
 // textBoxCategory
 // 
 this.textBoxCategory.Location = new System.Drawing.Point(120,132);
 this.textBoxCategory.Name = "textBoxCategory";
 this.textBoxCategory.Size = new System.Drawing.Size(180,28);
 // 
 // numericUpDownAmount
 // 
 this.numericUpDownAmount.DecimalPlaces =2;
 this.numericUpDownAmount.Maximum = new decimal(new int[] {9999999,0,0,0 });
 this.numericUpDownAmount.Location = new System.Drawing.Point(310,132);
 this.numericUpDownAmount.Name = "numericUpDownAmount";
 this.numericUpDownAmount.Size = new System.Drawing.Size(62,28);
 // 
 // textBoxRemark
 // 
 this.textBoxRemark.Location = new System.Drawing.Point(120,172);
 this.textBoxRemark.Name = "textBoxRemark";
 this.textBoxRemark.Size = new System.Drawing.Size(252,28);
 // 
 // btnOk
 // 
 this.btnOk.Location = new System.Drawing.Point(216,212);
 this.btnOk.Name = "btnOk";
 this.btnOk.Size = new System.Drawing.Size(75,30);
 this.btnOk.Text = "确定";
 this.btnOk.UseVisualStyleBackColor = true;
 this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
 // 
 // btnCancel
 // 
 this.btnCancel.Location = new System.Drawing.Point(297,212);
 this.btnCancel.Name = "btnCancel";
 this.btnCancel.Size = new System.Drawing.Size(75,30);
 this.btnCancel.Text = "取消";
 this.btnCancel.UseVisualStyleBackColor = true;
 this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
 // 
 // labelDate
 // 
 this.labelDate.AutoSize = true;
 this.labelDate.Location = new System.Drawing.Point(12,16);
 this.labelDate.Name = "labelDate";
 this.labelDate.Size = new System.Drawing.Size(88,18);
 this.labelDate.Text = "交易时间：";
 // 
 // labelType
 // 
 this.labelType.AutoSize = true;
 this.labelType.Location = new System.Drawing.Point(12,56);
 this.labelType.Name = "labelType";
 this.labelType.Size = new System.Drawing.Size(96,18);
 this.labelType.Text = "收支类型：";
 // 
 // labelCounterparty
 // 
 this.labelCounterparty.AutoSize = true;
 this.labelCounterparty.Location = new System.Drawing.Point(12,96);
 this.labelCounterparty.Name = "labelCounterparty";
 this.labelCounterparty.Size = new System.Drawing.Size(96,18);
 this.labelCounterparty.Text = "交易对象：";
 // 
 // labelCategory
 // 
 this.labelCategory.AutoSize = true;
 this.labelCategory.Location = new System.Drawing.Point(12,136);
 this.labelCategory.Name = "labelCategory";
 this.labelCategory.Size = new System.Drawing.Size(56,18);
 this.labelCategory.Text = "分类：";
 // 
 // labelAmount
 // 
 this.labelAmount.AutoSize = true;
 this.labelAmount.Location = new System.Drawing.Point(260,136);
 this.labelAmount.Name = "labelAmount";
 this.labelAmount.Size = new System.Drawing.Size(52,18);
 this.labelAmount.Text = "金额：";
 // 
 // labelRemark
 // 
 this.labelRemark.AutoSize = true;
 this.labelRemark.Location = new System.Drawing.Point(12,176);
 this.labelRemark.Name = "labelRemark";
 this.labelRemark.Size = new System.Drawing.Size(116,18);
 this.labelRemark.Text = "备注（可选）：";
 // 
 // toolTip1
 // 
 this.toolTip1.SetToolTip(this.dateTimePickerDate, "选择交易发生的日期和时间。");
 this.toolTip1.SetToolTip(this.comboBoxType, "选择是收入 (Income)还是支出 (Expense)。");
 this.toolTip1.SetToolTip(this.textBoxCounterparty, "填写交易的对方或交易对象，例如：超市、微信朋友、公司名称等。");
 this.toolTip1.SetToolTip(this.textBoxCategory, "填写本笔交易的分类，例如：餐饮、交通、工资、报销等。");
 this.toolTip1.SetToolTip(this.numericUpDownAmount, "输入正数金额（大于0），保留两位小数）。");
 this.toolTip1.SetToolTip(this.textBoxRemark, "可选：填写附加说明或备注。");
 // 
 // TransactionForm
 // 
 this.ClientSize = new System.Drawing.Size(384,254);
 this.Controls.Add(this.labelRemark);
 this.Controls.Add(this.labelAmount);
 this.Controls.Add(this.labelCategory);
 this.Controls.Add(this.labelCounterparty);
 this.Controls.Add(this.labelType);
 this.Controls.Add(this.labelDate);
 this.Controls.Add(this.btnCancel);
 this.Controls.Add(this.btnOk);
 this.Controls.Add(this.textBoxRemark);
 this.Controls.Add(this.numericUpDownAmount);
 this.Controls.Add(this.textBoxCategory);
 this.Controls.Add(this.textBoxCounterparty);
 this.Controls.Add(this.comboBoxType);
 this.Controls.Add(this.dateTimePickerDate);
 this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
 this.MaximizeBox = false;
 this.MinimizeBox = false;
 this.Name = "TransactionForm";
 this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
 this.Text = "交易记录";
 ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
 this.ResumeLayout(false);
 this.PerformLayout();
 }

 private System.Windows.Forms.DateTimePicker dateTimePickerDate;
 private System.Windows.Forms.ComboBox comboBoxType;
 private System.Windows.Forms.TextBox textBoxCounterparty;
 private System.Windows.Forms.TextBox textBoxCategory;
 private System.Windows.Forms.NumericUpDown numericUpDownAmount;
 private System.Windows.Forms.TextBox textBoxRemark;
 private System.Windows.Forms.Button btnOk;
 private System.Windows.Forms.Button btnCancel;
 private System.Windows.Forms.Label labelDate;
 private System.Windows.Forms.Label labelType;
 private System.Windows.Forms.Label labelCounterparty;
 private System.Windows.Forms.Label labelCategory;
 private System.Windows.Forms.Label labelAmount;
 private System.Windows.Forms.Label labelRemark;
 private System.Windows.Forms.ToolTip toolTip1;
 }
}