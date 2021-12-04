using OrderManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManager.Forms.UserForm
{
    public partial class UserForm : Form
    {
        static string DELETED_ACCOUNT_CODE = "@***@";
        DBContext db = new DBContext();
        public UserForm()
        {
            InitializeComponent();
            DataSource("abc");
        }

        public void DataSource(string sort)
        {
            var users = db.Users.Where(x => x.UserName != DELETED_ACCOUNT_CODE && x.UserName != "").ToList();
            foreach (var user in users)
            {
                user.ProductCost = 0;
                user.TotalWeight = 0;
                user.TotalWeightCost = 0;
                var orderDetailsList = db.OrderDetails.Where(x => x.UserId == user.UserId && x.IsDeleted == false && x.IsCompleted == false).ToList();
                foreach (var orderDetail in orderDetailsList)
                {
                    user.ProductCost += orderDetail.FinalCost;
                    user.TotalWeight += orderDetail.Weight;
                    user.TotalWeightCost += orderDetail.TotalWeightCost;
                }
                user.LeftOver = user.ProductCost - user.Deposit;
                user.TotalCost = user.ProductCost + user.TotalWeightCost;
                db.SaveChanges();
            }
            var list = users.ToList();
            dataGridView.DataSource = list.OrderBy(x => x.UserName).ToList();
            dataGridView.Columns["UserId"].Visible = false;
            dataGridView.Columns["LeftOver"].DisplayIndex = 3;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            var form = new MainForm();
            form.Show();
            Close();
        }
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

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            OrderForm form = new OrderForm();
            form.Show();
            Close();
        }

        private void BtnCreateNewUser_Click(object sender, EventArgs e)
        {
            CreateNewUserForm form = new CreateNewUserForm();
            form.Show();
            Close();
        }

        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView.SelectedRows[0].Index;
                var model = (User)dataGridView.Rows[index].DataBoundItem;
                var userId = model.UserId;
                EditUserForm form = new EditUserForm(userId);
                form.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã Xảy Ra Lỗi: " + ex.ToString());
            }
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView.SelectedRows[0].Index;
                var model = (User)dataGridView.Rows[index].DataBoundItem;
                var userName = model.UserName;
                if(MessageBox.Show("Bạn sắp sửa xóa khách hàng: " + userName + "\nCác đơn hàng của khách hàng này cũng sẽ bị xóa.Bạn đã chắc chưa ?", "Cảnh Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    model.UserName = DELETED_ACCOUNT_CODE;
                    var orderDetailList = db.OrderDetails.Where(x => x.UserId == model.UserId);
                    foreach(var orderDetail in orderDetailList)
                    {
                        orderDetail.IsDeleted = true;
                    }
                    db.SaveChanges();
                    DataSource("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã Xảy Ra Lỗi: " + ex.ToString());
            }
        }

        private void BtnExchange_Click(object sender, EventArgs e)
        {
            var form = new ExchangeForm.ExchangeForm(); //?
            form.Show();
            Close();
        }
    }
}
