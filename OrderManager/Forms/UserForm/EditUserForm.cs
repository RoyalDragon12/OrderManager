using OrderManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManager.Forms.UserForm
{
    public partial class EditUserForm : Form
    {
        int userId = 0;
        DBContext db = new DBContext();
        User user;
        public EditUserForm(int id)
        {
            userId = id;
            user = db.Users.Where(x => x.UserId == userId).FirstOrDefault();
            InitializeComponent();
            txtBoxUserName.Text = user.UserName;
            numUpDownDeposit.Value = (decimal) user.Deposit;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            user.UserName = txtBoxUserName.Text;
            user.Deposit = (double) numUpDownDeposit.Value;
            db.SaveChanges();
            btnCancel.PerformClick();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.Show();
            Close();
        }
    }
}
