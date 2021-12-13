using OrderManager.Forms.CreateNewOrderForm;
using OrderManager.Forms.ExchangeForm;
using OrderManager.Forms.OrderForm;
using OrderManager.Forms.UserForm;
using OrderManager.Functions;
using OrderManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManager
{
    public partial class OrderForm : Form
    {
        string sort = "";
        const string STATE_ALL = "All";
        const string STATE_COMPLETED = "Completed";
        const string STATE_PACKAGECREATED = "PackageCreated";
        string dataState = STATE_ALL;
        ToolStripMenuItem toolStripItemSumCell = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItemCheckData = new ToolStripMenuItem();
        DBContext db = new DBContext();
        public OrderForm()
        {
            InitializeComponent();
            sort = "LadingNo";
            btnTempSort.Text = "Lọc Theo Mã";
            btnDataState.Text = "Hiển Thị: Tất Cả Đơn";
            dataGridView.DoubleBuffered(true);
            DataSource(sort, dataState);
            AddContextMenu();

        }
        #region DataGridView
        private void AddContextMenu()
        {
            toolStripItemSumCell.Text = "Tính Tổng";
            toolStripItemSumCell.Click += new EventHandler(toolStripItemSumCell_Click);
            toolStripItemCheckData.Text = "Chọn / Bỏ Chọn";
            toolStripItemCheckData.Click += new EventHandler(toolStripItemCheckData_Click);
            ContextMenuStrip strip = new ContextMenuStrip();
            ContextMenuStrip strip2 = new ContextMenuStrip();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.DataPropertyName == "IsCompleted" || column.DataPropertyName == "PackageCreated")
                {
                    column.ContextMenuStrip = strip;
                    column.ContextMenuStrip.Items.Add(toolStripItemCheckData);
                }
                else if(column.DataPropertyName == "CostPerProduct" || column.DataPropertyName == "Amount" || column.DataPropertyName == "TotalCost" ||
                    column.DataPropertyName == "FinalCost" || column.DataPropertyName == "ServiceCost" || column.DataPropertyName == "Weight" ||
                    column.DataPropertyName == "WeightCost" || column.DataPropertyName == "FinalAndWeightCost" || column.DataPropertyName == "IncomeMoney")
                {
                    column.ContextMenuStrip = strip2;
                    column.ContextMenuStrip.Items.Add(toolStripItemSumCell);
                }
            }
        }

        private void toolStripItemSumCell_Click(object sender, EventArgs args)
        {
            int selectedCellCount = dataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if(selectedCellCount > 0)
            {
                if (dataGridView.AreAllCellsSelected(true))
                {
                    MessageBox.Show("Lỗi Dữ Liệu");
                }
                else
                {
                    bool error = false;
                    double result = 0;
                    for(int i = 0; i < selectedCellCount; i++)
                    {
                        Type t = dataGridView.SelectedCells[i].Value.GetType();
                        if (t.Equals(typeof(Int32)) || t.Equals(typeof(double)) || t.Equals(typeof(decimal)) || t.Equals(typeof(float)))
                        {
                            double value = Convert.ToDouble(dataGridView.SelectedCells[i].Value);
                            result += value;
                        }
                        else
                        {
                            error = true;
                            break;
                        }
                    }
                    if (error)
                    {
                        MessageBox.Show("Lỗi Dữ Liệu");
                    }
                    else
                    {
                        //result = ExtensionMethods.RoundUpDown(result); Weight will always round to 0 due to rounding setting: Round 4 decimals.
                        MessageBox.Show("Tổng: " + result);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có ô nào được chọn để thực hiện lệnh");
            }
        }

        private void toolStripItemCheckData_Click(object sender, EventArgs args)
        {
            int selectedCellCount = dataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if(selectedCellCount > 0)
            {
                bool error = false;
                for (int i = 0; i < selectedCellCount; i++)
                {
                    var model = (OrderAndDetailModel)dataGridView.SelectedCells[i].OwningRow.DataBoundItem;
                    DataGridViewColumn column = dataGridView.SelectedCells[i].OwningColumn;
                    var orderDetail = db.OrderDetails.Where(x => x.OrderDetailId == model.OrderDetailId).FirstOrDefault();
                    if (column.DataPropertyName == "IsCompleted")
                    {
                        model.IsCompleted = !model.IsCompleted;
                        orderDetail.IsCompleted = model.IsCompleted;
                    }
                    else if (column.DataPropertyName == "PackageCreated")
                    {
                        model.PackageCreated = !model.PackageCreated;
                        var order = db.Orders.Where(x => x.OrderId == orderDetail.OrderId).FirstOrDefault();
                        order.packageCreated = model.PackageCreated;
                    }
                    else
                    {
                        error = true;
                        break;
                    }
                }
                if (error)
                {
                    MessageBox.Show("Lỗi Dữ Liệu");
                }
                else
                {
                    db.SaveChanges();
                    MessageBox.Show("Cập Nhật Thành Công");
                }
                DataSource(sort, dataState);
            }
            else
            {
                MessageBox.Show("Không có ô nào được chọn để thực hiện lệnh");
            }
        }
        public void DataSource(string sort, string dataState)
        {
            var order = db.Orders;
            var orderDetail = db.OrderDetails.Where(x => x.IsDeleted != true).Join(db.Orders.Where(y => y.isDeleted != true), x => x.OrderId, y => y.OrderId, (x, y) => new OrderAndDetailModel
            {
                OrderDetailId = x.OrderDetailId,
                LadingNo = y.LadingNo,
                Shipper = y.Shipper,
                ShopName = y.ShopName,
                OrderDate = y.OrderDate,
                PackageCreated = y.packageCreated,
                UserName = x.Users.UserName,
                ProductName = x.ProductName,
                ProductLink = x.ProductLink,
                Size = x.Size,
                Model = x.Model,
                CostPerProduct = x.CostPerProduct,
                Amount = x.Amount,
                TotalCost = x.TotalCost,
                InterestRate = x.InterestRate * 100,
                FinalCost = x.FinalCost,
                AdditionalCost = x.AdditionalCost,
                ServiceFee = x.ServiceFee * 100,
                ServiceCost = x.TotalCost /1.03 * x.ServiceFee,
                Weight = x.Weight,
                WeightCost = x.TotalWeightCost,
                FinalAndWeightCost = (x.FinalCost + x.TotalWeightCost + x.AdditionalCost),
                Note = x.Note,
                IsCompleted = x.IsCompleted,
                IncomeMoney = (x.FinalCost - x.TotalCost)
            });
            //var list = new SortableBindingList<OrderAndDetailModel>(orderDetail.ToList());
            var list = orderDetail.ToList();
            var allTotalCost = 0.0;
            var allFinalCost = 0.0;
            var allWeightCost = 0.0;
            var allIncomeMoney = 0.0;
            foreach(var detail in list)
            {
                detail.ServiceCost = (float)Functions.ExtensionMethods.RoundUpDown(detail.ServiceCost);
                if (!detail.IsCompleted)
                {
                    allTotalCost += detail.TotalCost;
                    allFinalCost += detail.FinalCost;
                    allWeightCost += detail.WeightCost;
                    allIncomeMoney += detail.IncomeMoney;
                }
            }
            lblAllFinalCost.Text = allFinalCost.ToString();
            lblAllIncomeMoney.Text = allIncomeMoney.ToString();
            lblAllTotalCost.Text = allTotalCost.ToString();
            lblAllWeightCost.Text = allWeightCost.ToString();

            switch (dataState)
            {
                case STATE_COMPLETED:
                    list = list.Where(x => x.IsCompleted == true).ToList();
                    break;
                case STATE_PACKAGECREATED:
                    list = list.Where(x => x.PackageCreated == true && x.IsCompleted == false).ToList();
                    break;
                default: //All
                    break;
            }
            switch (sort)
            {
                case "User":
                    dataGridView.DataSource = list.OrderBy(x=> x.IsCompleted).ThenBy(x => x.UserName).ThenBy(y => y.LadingNo).ToList();
                    
                    break;
                default:
                    dataGridView.DataSource = list.OrderBy(x => x.IsCompleted).ThenBy(x => x.LadingNo).ThenBy(y => y.UserName).ToList();
                    break;
            }
            dataGridView.Columns["OrderDetailId"].Visible = false;

            var dupLadingNo = "";
            var STT = 0;
            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                var model = (OrderAndDetailModel) row.DataBoundItem;
                var ladingNo = model.LadingNo;
                if(dupLadingNo != ladingNo)
                {
                    dupLadingNo = ladingNo;
                    STT++;
                    model.STT = STT.ToString();
                }
            }

            //Just in case you need to know, it doesn't work yet. Sortable but not sortable, nice joke.
            //for (int i = 0; i < dataGridView.ColumnCount; i++)
            //{
            //    dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            //}
        }
        #endregion
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))
            {
                //"Closed by calling Close()
            }
            else
            {
                //Closed by X or Alt+F4
                Application.Exit();
            }
        }


        #region Buttons
        private void BtnExit_Click(object sender, EventArgs e)
        {
            var form = new MainForm();
            form.Show();
            Close();
        }

        private void BtnCreateNewOrderDetail_Click(object sender, EventArgs e)
        {
            Close();
            CreateNewOrderDetailForm form = new CreateNewOrderDetailForm();
            form.Show();
        }

        private void BtnEditOrderDetail_Click(object sender, EventArgs e)
        {
            try
            {
                var cell = dataGridView.SelectedCells[0];
                //int index = dataGridView.SelectedRows[0].Index;
                var index = cell.RowIndex;
                var model = (OrderAndDetailModel)dataGridView.Rows[index].DataBoundItem;
                var orderDetailId = model.OrderDetailId;
                Close();
                EditOrderDetailForm form = new EditOrderDetailForm(orderDetailId);
                form.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã Xảy Ra Lỗi: " + ex.ToString());
            }
        }

        private void BtnDeleteOrderDetail_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView.SelectedRows[0].Index;
                var model = (OrderAndDetailModel)dataGridView.Rows[index].DataBoundItem;
                var orderDetailId = model.OrderDetailId;
                var orderDetail = db.OrderDetails.Where(x => x.OrderDetailId == orderDetailId).FirstOrDefault();
                orderDetail.IsDeleted = true;
                db.SaveChanges();
                DataSource(sort, dataState);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã Xảy Ra Lỗi: " + ex.ToString());
            }
        }

        private void BtnTempSort_Click(object sender, EventArgs e)
        {
            if(btnTempSort.Text == "Lọc Theo Mã")
            {
                btnTempSort.Text = "Lọc Theo Người Đặt";
                sort = "User";
                DataSource(sort, dataState);
            }
            else
            {
                btnTempSort.Text = "Lọc Theo Mã";
                sort = "LadingNo";
                DataSource(sort, dataState);
            }
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.Show();
            Close();
        }

        private void BtnDataState_Click(object sender, EventArgs e)
        {
            switch(dataState)
            {
                case STATE_COMPLETED:
                    dataState = STATE_PACKAGECREATED;
                    btnDataState.Text = "Hiển Thị: Đơn Đã Tạo Kiện Hàng";
                    break;
                case STATE_PACKAGECREATED:
                    dataState = STATE_ALL;
                    btnDataState.Text = "Hiển Thị: Tất Cả Đơn";
                    break;
                default:
                    dataState = STATE_COMPLETED;
                    btnDataState.Text = "Hiển Thị: Đơn Đã Thanh Toán";
                    break;
            }
            DataSource(sort, dataState);
        }
        #endregion

        private void BtnExchange_Click(object sender, EventArgs e)
        {
            ExchangeForm form = new ExchangeForm();
            form.Show();
            Close();
        }

        private void BtnCreateNewOrder_Click(object sender, EventArgs e)
        {
            var form = new CreateNewOrderForm();
            form.Show();
            Close();
        }

        private void BtnEditOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var cell = dataGridView.SelectedCells[0];
                //int index = dataGridView.SelectedRows[0].Index;
                var index = cell.RowIndex;
                var model = (OrderAndDetailModel)dataGridView.Rows[index].DataBoundItem;
                var orderDetailId = model.OrderDetailId;
                var orderId = db.OrderDetails.Where(x => x.OrderDetailId == orderDetailId).FirstOrDefault().OrderId;
                var form = new EditOrderForm(orderId);
                form.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã Xảy Ra Lỗi: " + ex.ToString());
            }
            
        }
    }
}
