using OrderManager.Forms.ExchangeForm;
using OrderManager.Forms.UserForm;
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

namespace OrderManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            OrderForm form = new OrderForm();
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

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.Show();
            Close();
        }

        private void BtnExchange_Click(object sender, EventArgs e)
        {
            ExchangeForm form = new ExchangeForm();
            form.Show();
            Close();
        }
    }
}
