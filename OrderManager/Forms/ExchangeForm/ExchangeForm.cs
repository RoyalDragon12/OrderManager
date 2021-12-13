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

namespace OrderManager.Forms.ExchangeForm
{
    public partial class ExchangeForm : Form
    {
        DBContext db = new DBContext();

        public ExchangeForm()
        {
            InitializeComponent();
            PopulateData();
        }

        private void PopulateData()
        {
            var exchangeCNY = db.Exchanges.Where(x => x.ExchangeName == "CNY").FirstOrDefault();
            var exchangeWeightCost = db.Exchanges.Where(x => x.ExchangeName == "Weight Cost").FirstOrDefault();
            var exchangeRetailRate = db.Exchanges.Where(x => x.ExchangeName == "Retail Rate").FirstOrDefault();
            var exchangeTradeRate = db.Exchanges.Where(x => x.ExchangeName == "Trade Rate").FirstOrDefault();
            var exchangeTradeMin = db.Exchanges.Where(x => x.ExchangeName == "Trade Min").FirstOrDefault();
            var exchangeServiceFee = db.Exchanges.Where(x => x.ExchangeName == "Service Fee").FirstOrDefault();

            numUpDownCNY.Value = (decimal)exchangeCNY.ExchangeNum;
            numericUpDownWeightCost.Value = (decimal)exchangeWeightCost.ExchangeNum;
            numericUpDownRetailRate.Value = (decimal) exchangeRetailRate.ExchangeNum * 100;
            numericUpDownTradeRate.Value = (decimal)exchangeTradeRate.ExchangeNum * 100;
            numericUpDownTradeMin.Value = (decimal)exchangeTradeMin.ExchangeNum;
            numericUpDownServiceFee.Value = (decimal)exchangeServiceFee.ExchangeNum * 100;
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

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var exchangeCNY = db.Exchanges.Where(x => x.ExchangeName == "CNY").FirstOrDefault();
            var exchangeWeightCost = db.Exchanges.Where(x => x.ExchangeName == "Weight Cost").FirstOrDefault();
            var exchangeRetailRate = db.Exchanges.Where(x => x.ExchangeName == "Retail Rate").FirstOrDefault();
            var exchangeTradeRate = db.Exchanges.Where(x => x.ExchangeName == "Trade Rate").FirstOrDefault();
            var exchangeTradeMin = db.Exchanges.Where(x => x.ExchangeName == "Trade Min").FirstOrDefault();
            var exchangeServiceFee = db.Exchanges.Where(x => x.ExchangeName == "Service Fee").FirstOrDefault();

            try
            {
                if (exchangeCNY.ExchangeNum != (double)numUpDownCNY.Value)
                {
                    exchangeCNY.ExchangeNum = (double)numUpDownCNY.Value;
                    exchangeCNY.ExchangeDate = DateTime.Today;
                }
                if (exchangeWeightCost.ExchangeNum != (double)numericUpDownWeightCost.Value)
                {
                    exchangeWeightCost.ExchangeNum = (double)numericUpDownWeightCost.Value;
                    exchangeWeightCost.ExchangeDate = DateTime.Today;
                }
                if (exchangeRetailRate.ExchangeNum != (double)numericUpDownRetailRate.Value / 100)
                {
                    exchangeRetailRate.ExchangeNum = (double)numericUpDownRetailRate.Value / 100;
                    exchangeRetailRate.ExchangeDate = DateTime.Today;
                }
                if (exchangeTradeRate.ExchangeNum != (double)numericUpDownTradeRate.Value / 100)
                {
                    exchangeTradeRate.ExchangeNum = (double)numericUpDownTradeRate.Value / 100;
                    exchangeTradeRate.ExchangeDate = DateTime.Today;
                }
                if (exchangeTradeMin.ExchangeNum != (double)numericUpDownTradeMin.Value)
                {
                    exchangeTradeMin.ExchangeNum = (double)numericUpDownTradeMin.Value;
                    exchangeTradeMin.ExchangeDate = DateTime.Today;
                }
                if (exchangeServiceFee.ExchangeNum != (double)numericUpDownServiceFee.Value / 100)
                {
                    exchangeServiceFee.ExchangeNum = (double)numericUpDownServiceFee.Value / 100;
                    exchangeServiceFee.ExchangeDate = DateTime.Today;
                }
                db.SaveChanges();
                if (MessageBox.Show("Cập Nhật Thành Công") == DialogResult.OK)
                {
                    btnCancel.PerformClick();
                }
            }
            catch(Exception ex)
            {
                ExtensionMethods.ErrorOutput(ex.ToString());
                MessageBox.Show("Đã Có Lỗi Xảy Ra");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            Close();
        }
    }
}
