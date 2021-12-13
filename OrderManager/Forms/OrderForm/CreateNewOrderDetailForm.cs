using OrderManager.Functions;
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

namespace OrderManager
{
    public partial class CreateNewOrderDetailForm : Form
    {
        bool customizableInterestRate;
        bool hasServiceFee;
        double CNY;
        double retail_rate;
        double trade_rate;
        double trade_min;
        double weight_cost;
        double service_fee;
        DBContext db = new DBContext();
        public CreateNewOrderDetailForm()
        {
            FormClosed += CreateNewOrderForm_FormClosed;
            InitializeComponent();

            CNY = db.Exchanges.Where(x => x.ExchangeName == "CNY").FirstOrDefault().ExchangeNum;
            retail_rate = db.Exchanges.Where(x => x.ExchangeName == "Retail Rate").FirstOrDefault().ExchangeNum;
            trade_rate = db.Exchanges.Where(x => x.ExchangeName == "Trade Rate").FirstOrDefault().ExchangeNum;
            trade_min = db.Exchanges.Where(x => x.ExchangeName == "Trade Min").FirstOrDefault().ExchangeNum;
            weight_cost = db.Exchanges.Where(x => x.ExchangeName == "Weight Cost").FirstOrDefault().ExchangeNum;
            service_fee = db.Exchanges.Where(x => x.ExchangeName == "Service Fee").FirstOrDefault().ExchangeNum;
            numUpDownCNY.Value = (decimal) CNY;
            numUpDownInterestRate.Value = (decimal)(retail_rate * 100);
            numUpDownWeightCost.Value = (decimal)weight_cost;
            numUpDownServiceFee.Value = (decimal) service_fee * 100;

            customizableInterestRate = checkBoxInterestRate.Checked;
            hasServiceFee = cBoxServiceFee.Checked;
            numUpDownServiceFee.Enabled = hasServiceFee;
            numUpDownInterestRate.Enabled = customizableInterestRate;

            numUpDownServiceFee.ValueChanged += new EventHandler(MoneyCount);
            numUpDownAmount.ValueChanged += new EventHandler(MoneyCount);
            numUpDownCNY.ValueChanged += new EventHandler(MoneyCount);
            numUpDownCostPerProduct.ValueChanged += new EventHandler(MoneyCount);
            numUpDownInterestRate.ValueChanged += new EventHandler(MoneyCount);
            numUpDownWeight.ValueChanged += new EventHandler(MoneyCount);
            numUpDownWeightCost.ValueChanged += new EventHandler(MoneyCount);
        }

        private void CreateNewOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OrderForm form = new OrderForm();
            form.Show();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var order = db.Orders.Where(x => x.LadingNo == txtBoxLadingNo.Text.ToString()).FirstOrDefault();
            var answer = true;
            if(order == null)
            {
                if(MessageBox.Show("Không tìm thấy Mã Đơn Hàng. Bạn có muốn tạo Mã mới ?","Cảnh Báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    order = new Order
                    {
                        LadingNo = txtBoxLadingNo.Text,
                        OrderDate = DateTime.Today
                    };
                }
                else
                {
                    answer = false;
                }
            }
            if (answer == true)
            {
                var orderQuery = db.Orders.Where(x => x.LadingNo == order.LadingNo).FirstOrDefault();
                if (orderQuery != null)
                {
                    order.OrderId = orderQuery.OrderId;
                }
                else
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }

                var userId = 0;
                var userName = txtBoxUserName.Text;
                var userNameQuery = db.Users.Where(x => x.UserName == userName).FirstOrDefault();
                if (userNameQuery != null)
                {
                    userId = userNameQuery.UserId;
                }
                else
                {
                    var user = new User { UserName = userName };
                    db.Users.Add(user);
                    db.SaveChanges();
                    userId = user.UserId;
                }

                var costPerProduct = (double)numUpDownCostPerProduct.Value;
                var amount = (int)numUpDownAmount.Value;
                var interestRate = (float)numUpDownInterestRate.Value / 100;
                var weight = (float)numUpDownWeight.Value;
                var CNY = (double)numUpDownCNY.Value;
                var weightCost = (double)numUpDownWeightCost.Value; //Giá cân
                var totalCost = Functions.ExtensionMethods.RoundUpDown(costPerProduct * amount * CNY);
                var finalCost = Functions.ExtensionMethods.RoundUpDown(totalCost * (1 + interestRate));
                var incomeMoney = finalCost - totalCost;
                var totalWeightCost = Functions.ExtensionMethods.RoundUpDown(weight * weightCost); //Tiền cân phải trả
                var finalCostAndWeight = finalCost + totalWeightCost;
                float serviceFee = 0;
                if (hasServiceFee)
                {
                    double serviceCost = 0;
                    serviceFee = (float)numUpDownServiceFee.Value / 100;
                    serviceCost = Functions.ExtensionMethods.RoundUpDown(totalCost * serviceFee);
                    totalCost += serviceCost;
                    finalCost += serviceCost;
                    finalCostAndWeight += serviceCost;
                }
                else
                {
                    serviceFee = 0;
                }

                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    UserId = userId,
                    ProductName = txtBoxProductName.Text,
                    ProductLink = txtBoxLink.Text,
                    Size = txtBoxSize.Text,
                    Model = txtBoxModel.Text,
                    Note = txtBoxNote.Text,
                    CostPerProduct = costPerProduct,
                    Amount = amount,
                    CNY = CNY,
                    InterestRate = interestRate,
                    TotalCost = totalCost,
                    FinalCost = finalCost,
                    ServiceFee = serviceFee,
                    Weight = weight,
                    WeightCost = weightCost,
                    TotalWeightCost = (float)totalWeightCost,
                    IsCompleted = false,
                };
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                Close();
            }
            
        }

        public void MoneyCount(object sender, EventArgs e)
        {
            var costPerProduct = (double)numUpDownCostPerProduct.Value;
            var amount = (int)numUpDownAmount.Value;
            float interestRate;
            if (customizableInterestRate)
            {
                interestRate = (float)numUpDownInterestRate.Value / 100;
            }
            else
            {
                var totalCNYCost = costPerProduct * amount;
                if(totalCNYCost >= trade_min) //Tổng tiền sp lớn hơn hoặc bằng giá để tính giá sỉ
                {
                    interestRate = (float)trade_rate;
                }
                else
                {
                    interestRate = (float) retail_rate;
                }
                numUpDownInterestRate.Value = (decimal) interestRate * 100;
            }
            var weight = (float)numUpDownWeight.Value;
            var CNY = (double)numUpDownCNY.Value;
            var weightCost = (double)numUpDownWeightCost.Value; //Giá cân
            var totalCost = Functions.ExtensionMethods.RoundUpDown(costPerProduct * amount * CNY);
            var finalCost = Functions.ExtensionMethods.RoundUpDown(totalCost * (1 + interestRate));
            var incomeMoney = finalCost - totalCost;
            var totalWeightCost = Functions.ExtensionMethods.RoundUpDown(weight * weightCost); //Tiền cân phải trả
            var finalCostAndWeight = finalCost + totalWeightCost;
            double serviceCost = 0;
            if (hasServiceFee)
            {
                var serviceFee = (double)numUpDownServiceFee.Value / 100;
                serviceCost = Functions.ExtensionMethods.RoundUpDown(totalCost * serviceFee);
                totalCost += serviceCost;
                finalCost += serviceCost;
                finalCostAndWeight += serviceCost;
            }

            lblServiceCost.Text = serviceCost.ToString();
            lblTotalCost.Text = totalCost.ToString();
            lblWeightCost.Text = totalWeightCost.ToString();
            lblFinalCost.Text = finalCost.ToString();
            lblIncomeMoney.Text = incomeMoney.ToString();
            lblFinalCostAndWeight.Text = finalCostAndWeight.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckBoxInterestRate_CheckedChanged(object sender, EventArgs e)
        {
            customizableInterestRate = checkBoxInterestRate.Checked;
            numUpDownInterestRate.Enabled = customizableInterestRate;
             MoneyCount(sender, new EventArgs());
        }

        private void cBoxServiceFee_CheckedChanged(object sender, EventArgs e)
        {
            hasServiceFee = cBoxServiceFee.Checked;
            numUpDownServiceFee.Enabled = hasServiceFee;
             MoneyCount(sender, new EventArgs());
        }
    }
}
