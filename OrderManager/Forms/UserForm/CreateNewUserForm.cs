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
    public partial class CreateNewUserForm : Form
    {
        DBContext db = new DBContext();
        public CreateNewUserForm()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
            UserForm form = new UserForm();
            form.Show();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var userName = txtBoxUserName.Text;
            var deposit = numUpDownDeposit.Value;
            var user = db.Users.Where(x => x.UserName == userName).FirstOrDefault();
            if(user == null)
            {
                user = new User { UserName = userName, Deposit = (double)deposit };
                db.Users.Add(user);
                db.SaveChanges();
                btnCancel.PerformClick();
            }
            else
            {
                MessageBox.Show("Tên Khách Hàng Đã Tồn Tại");
            }
        }
    }
}
