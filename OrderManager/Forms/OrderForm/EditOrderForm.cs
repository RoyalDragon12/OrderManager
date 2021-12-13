using OrderManager.Functions;
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

namespace OrderManager.Forms.OrderForm
{
    public partial class EditOrderForm : Form
    {
        DBContext db = new DBContext();
        int id;
        public EditOrderForm(int orderId)
        {
            InitializeComponent();
            var order = db.Orders.Where(x => x.OrderId == orderId).FirstOrDefault();
            if(order != null)
            {
                id = order.OrderId;
                txtBoxLadingNo.Text = order.LadingNo;
                txtBoxShopName.Text = order.ShopName;
                txtBoxShipper.Text = order.Shipper;
                dateTimePicker1.Value = order.OrderDate;
                cboxPackageCreated.Checked = order.packageCreated;
            }
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var order = db.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            var result = false;
            try
            {
                var tempOrder = db.Orders.Where(x => x.LadingNo == txtBoxLadingNo.Text).FirstOrDefault();
                if(tempOrder != null)
                {
                    MessageBox.Show("Mã Vận Đơn đã tồn tại!", "Cảnh Báo");
                }
                else
                {
                    order.LadingNo = txtBoxLadingNo.Text;
                    order.OrderDate = dateTimePicker1.Value;
                    order.ShopName = txtBoxShopName.Text;
                    order.Shipper = txtBoxShipper.Text;
                    order.packageCreated = cboxPackageCreated.Checked;
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                ExtensionMethods.ErrorOutput(ex.ToString());
                MessageBox.Show("Đã Xảy Ra Lỗi");
            }
            if (result)
            {
                btnCancel.PerformClick();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var form = new OrderManager.OrderForm();
            form.Show();
            Close();
        }
    }
}
