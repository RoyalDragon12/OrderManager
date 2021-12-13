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

namespace OrderManager.Forms.CreateNewOrderForm
{
    public partial class CreateNewOrderForm : Form
    {
        DBContext db = new DBContext();
        public CreateNewOrderForm()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
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

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                LadingNo = txtBoxLadingNo.Text,
                OrderDate = dateTimePicker1.Value,
                ShopName = txtBoxShopName.Text,
                Shipper = txtBoxShipper.Text,
                packageCreated = cboxPackageCreated.Checked
            };
            try
            {

                db.Orders.Add(order);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                ExtensionMethods.ErrorOutput(ex.ToString());
                MessageBox.Show("Đã Xảy Ra Lỗi");
            }
            btnCancel.PerformClick();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var form = new OrderManager.OrderForm();
            form.Show();
            Close();
        }
    }
}
