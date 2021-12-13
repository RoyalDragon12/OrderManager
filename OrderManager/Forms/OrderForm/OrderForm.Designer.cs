using OrderManager.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OrderManager
{
    partial class OrderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreateNewOrder = new System.Windows.Forms.Button();
            this.btnExchange = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnDeleteOrderDetail = new System.Windows.Forms.Button();
            this.btnEditOrderDetail = new System.Windows.Forms.Button();
            this.btnCreateNewOrderDetail = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.listBoxSearch = new System.Windows.Forms.ListBox();
            this.btnTempSort = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAllWeightCost = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAllIncomeMoney = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAllFinalCost = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAllTotalCost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDataState = new System.Windows.Forms.Button();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEditOrder);
            this.groupBox2.Controls.Add(this.btnCreateNewOrder);
            this.groupBox2.Controls.Add(this.btnExchange);
            this.groupBox2.Controls.Add(this.btnUser);
            this.groupBox2.Controls.Add(this.btnDeleteOrderDetail);
            this.groupBox2.Controls.Add(this.btnEditOrderDetail);
            this.groupBox2.Controls.Add(this.btnCreateNewOrderDetail);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1172, 74);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnCreateNewOrder
            // 
            this.btnCreateNewOrder.Location = new System.Drawing.Point(11, 16);
            this.btnCreateNewOrder.Name = "btnCreateNewOrder";
            this.btnCreateNewOrder.Size = new System.Drawing.Size(81, 47);
            this.btnCreateNewOrder.TabIndex = 6;
            this.btnCreateNewOrder.Text = "Tạo Mã Vận Đơn Mới";
            this.btnCreateNewOrder.UseVisualStyleBackColor = true;
            this.btnCreateNewOrder.Click += new System.EventHandler(this.BtnCreateNewOrder_Click);
            // 
            // btnExchange
            // 
            this.btnExchange.Location = new System.Drawing.Point(998, 16);
            this.btnExchange.Name = "btnExchange";
            this.btnExchange.Size = new System.Drawing.Size(81, 47);
            this.btnExchange.TabIndex = 5;
            this.btnExchange.Text = "Quản Lý Giá Trị Quy Đổi";
            this.btnExchange.UseVisualStyleBackColor = true;
            this.btnExchange.Click += new System.EventHandler(this.BtnExchange_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(911, 16);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(81, 47);
            this.btnUser.TabIndex = 4;
            this.btnUser.Text = "Quản Lý Khách Hàng";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.BtnUser_Click);
            // 
            // btnDeleteOrderDetail
            // 
            this.btnDeleteOrderDetail.Location = new System.Drawing.Point(359, 16);
            this.btnDeleteOrderDetail.Name = "btnDeleteOrderDetail";
            this.btnDeleteOrderDetail.Size = new System.Drawing.Size(81, 47);
            this.btnDeleteOrderDetail.TabIndex = 3;
            this.btnDeleteOrderDetail.Text = "Xóa Đơn Hàng";
            this.btnDeleteOrderDetail.UseVisualStyleBackColor = true;
            this.btnDeleteOrderDetail.Click += new System.EventHandler(this.BtnDeleteOrderDetail_Click);
            // 
            // btnEditOrderDetail
            // 
            this.btnEditOrderDetail.Location = new System.Drawing.Point(272, 16);
            this.btnEditOrderDetail.Name = "btnEditOrderDetail";
            this.btnEditOrderDetail.Size = new System.Drawing.Size(81, 47);
            this.btnEditOrderDetail.TabIndex = 2;
            this.btnEditOrderDetail.Text = "Sửa Đơn Hàng";
            this.btnEditOrderDetail.UseVisualStyleBackColor = true;
            this.btnEditOrderDetail.Click += new System.EventHandler(this.BtnEditOrderDetail_Click);
            // 
            // btnCreateNewOrderDetail
            // 
            this.btnCreateNewOrderDetail.Location = new System.Drawing.Point(185, 16);
            this.btnCreateNewOrderDetail.Name = "btnCreateNewOrderDetail";
            this.btnCreateNewOrderDetail.Size = new System.Drawing.Size(81, 47);
            this.btnCreateNewOrderDetail.TabIndex = 1;
            this.btnCreateNewOrderDetail.Text = "Tạo Đơn Hàng Mới";
            this.btnCreateNewOrderDetail.UseVisualStyleBackColor = true;
            this.btnCreateNewOrderDetail.Click += new System.EventHandler(this.BtnCreateNewOrderDetail_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(1085, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 47);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 130);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Size = new System.Drawing.Size(1172, 518);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(12, 92);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(405, 32);
            this.txtBoxSearch.TabIndex = 3;
            // 
            // listBoxSearch
            // 
            this.listBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSearch.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSearch.FormattingEnabled = true;
            this.listBoxSearch.ItemHeight = 31;
            this.listBoxSearch.Location = new System.Drawing.Point(423, 92);
            this.listBoxSearch.Name = "listBoxSearch";
            this.listBoxSearch.Size = new System.Drawing.Size(131, 31);
            this.listBoxSearch.TabIndex = 4;
            // 
            // btnTempSort
            // 
            this.btnTempSort.Location = new System.Drawing.Point(560, 93);
            this.btnTempSort.Name = "btnTempSort";
            this.btnTempSort.Size = new System.Drawing.Size(156, 31);
            this.btnTempSort.TabIndex = 4;
            this.btnTempSort.UseVisualStyleBackColor = true;
            this.btnTempSort.Click += new System.EventHandler(this.BtnTempSort_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAllWeightCost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblAllIncomeMoney);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblAllFinalCost);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblAllTotalCost);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 654);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1172, 92);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lblAllWeightCost
            // 
            this.lblAllWeightCost.AutoSize = true;
            this.lblAllWeightCost.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllWeightCost.Location = new System.Drawing.Point(1040, 16);
            this.lblAllWeightCost.Name = "lblAllWeightCost";
            this.lblAllWeightCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAllWeightCost.Size = new System.Drawing.Size(120, 26);
            this.lblAllWeightCost.TabIndex = 7;
            this.lblAllWeightCost.Text = "000000000";
            this.lblAllWeightCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(856, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tổng Tiền Cân :";
            // 
            // lblAllIncomeMoney
            // 
            this.lblAllIncomeMoney.AutoSize = true;
            this.lblAllIncomeMoney.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllIncomeMoney.Location = new System.Drawing.Point(1040, 54);
            this.lblAllIncomeMoney.Name = "lblAllIncomeMoney";
            this.lblAllIncomeMoney.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAllIncomeMoney.Size = new System.Drawing.Size(120, 26);
            this.lblAllIncomeMoney.TabIndex = 5;
            this.lblAllIncomeMoney.Text = "000000000";
            this.lblAllIncomeMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(862, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tổng Tiền Lời :";
            // 
            // lblAllFinalCost
            // 
            this.lblAllFinalCost.AutoSize = true;
            this.lblAllFinalCost.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllFinalCost.Location = new System.Drawing.Point(251, 54);
            this.lblAllFinalCost.Name = "lblAllFinalCost";
            this.lblAllFinalCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAllFinalCost.Size = new System.Drawing.Size(120, 26);
            this.lblAllFinalCost.TabIndex = 3;
            this.lblAllFinalCost.Text = "000000000";
            this.lblAllFinalCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng Giá Báo :";
            // 
            // lblAllTotalCost
            // 
            this.lblAllTotalCost.AutoSize = true;
            this.lblAllTotalCost.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllTotalCost.Location = new System.Drawing.Point(251, 16);
            this.lblAllTotalCost.Name = "lblAllTotalCost";
            this.lblAllTotalCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAllTotalCost.Size = new System.Drawing.Size(120, 26);
            this.lblAllTotalCost.TabIndex = 1;
            this.lblAllTotalCost.Text = "000000000";
            this.lblAllTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng Tiền Sản Phẩm :";
            // 
            // btnDataState
            // 
            this.btnDataState.Location = new System.Drawing.Point(722, 93);
            this.btnDataState.Name = "btnDataState";
            this.btnDataState.Size = new System.Drawing.Size(193, 31);
            this.btnDataState.TabIndex = 6;
            this.btnDataState.UseVisualStyleBackColor = true;
            this.btnDataState.Click += new System.EventHandler(this.BtnDataState_Click);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Location = new System.Drawing.Point(98, 16);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(81, 47);
            this.btnEditOrder.TabIndex = 7;
            this.btnEditOrder.Text = "Sửa Mã Vận Đơn";
            this.btnEditOrder.UseVisualStyleBackColor = true;
            this.btnEditOrder.Click += new System.EventHandler(this.BtnEditOrder_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1196, 758);
            this.Controls.Add(this.btnDataState);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTempSort);
            this.Controls.Add(this.listBoxSearch);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Đơn Hàng";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var model = (OrderAndDetailModel)dataGridView.Rows[e.RowIndex].DataBoundItem;
            var packageCreated = model.PackageCreated;
            var isCompleted = model.IsCompleted;
            if (isCompleted)
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
            else if (packageCreated)
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.ListBox listBoxSearch;
        private System.Windows.Forms.Button btnCreateNewOrderDetail;
        private System.Windows.Forms.Button btnDeleteOrderDetail;
        private System.Windows.Forms.Button btnEditOrderDetail;
        private System.Windows.Forms.Button btnTempSort;
        private GroupBox groupBox1;
        private Label lblAllTotalCost;
        private Label label1;
        private Label lblAllIncomeMoney;
        private Label label5;
        private Label lblAllFinalCost;
        private Label label3;
        private Label lblAllWeightCost;
        private Label label4;
        private Button btnUser;
        private Button btnDataState;
        private Button btnExchange;
        private Button btnCreateNewOrder;
        private Button btnEditOrder;
    }
}