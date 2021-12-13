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
    public partial class EditOrderDetailForm : Form
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
        int id;
        public EditOrderDetailForm(int orderDetailId)
        {
            FormClosed += EditOrderForm_FormClosed;
            InitializeComponent();

            InputData(orderDetailId);

            numUpDownServiceFee.ValueChanged += new EventHandler(MoneyCount);
            numUpDownAmount.ValueChanged += new EventHandler(MoneyCount);
            numUpDownCNY.ValueChanged += new EventHandler(MoneyCount);
            numUpDownCostPerProduct.ValueChanged += new EventHandler(MoneyCount);
            numUpDownInterestRate.ValueChanged += new EventHandler(MoneyCount);
            numUpDownWeight.ValueChanged += new EventHandler(MoneyCount);
            numUpDownWeightCost.ValueChanged += new EventHandler(MoneyCount);
        }

        public void InputData(int orderDetailId)
        {
            CNY = db.Exchanges.Where(x => x.ExchangeName == "CNY").FirstOrDefault().ExchangeNum;
            retail_rate = db.Exchanges.Where(x => x.ExchangeName == "Retail Rate").FirstOrDefault().ExchangeNum;
            trade_rate = db.Exchanges.Where(x => x.ExchangeName == "Trade Rate").FirstOrDefault().ExchangeNum;
            trade_min = db.Exchanges.Where(x => x.ExchangeName == "Trade Min").FirstOrDefault().ExchangeNum;
            weight_cost = db.Exchanges.Where(x => x.ExchangeName == "Weight Cost").FirstOrDefault().ExchangeNum;
            service_fee = db.Exchanges.Where(x => x.ExchangeName == "Service Fee").FirstOrDefault().ExchangeNum;

            var orderDetail = db.OrderDetails.Where(x => x.OrderDetailId == orderDetailId).FirstOrDefault();
            var order = db.Orders.Where(x => x.OrderId == orderDetail.OrderId).FirstOrDefault();
            id = orderDetailId;

            txtBoxLadingNo.Text = order.LadingNo;
            txtBoxShopName.Text = order.ShopName;
            txtBoxShipper.Text = order.Shipper;
            dateTimePicker1.Value = order.OrderDate;
            cboxPackageCreated.Checked = order.packageCreated;

            txtBoxLink.Text = orderDetail.ProductLink;
            txtBoxModel.Text = orderDetail.Model;
            txtBoxNote.Text = orderDetail.Note;
            txtBoxProductName.Text = orderDetail.ProductName;
            txtBoxSize.Text = orderDetail.Size;
            txtBoxUserName.Text = orderDetail.Users.UserName;

            numUpDownAmount.Value = orderDetail.Amount;
            numUpDownCostPerProduct.Value = (decimal) orderDetail.CostPerProduct;
            numUpDownWeight.Value = (decimal)orderDetail.Weight;
            numUpDownCNY.Value = (decimal)orderDetail.CNY;
            numUpDownInterestRate.Value = (decimal)orderDetail.InterestRate *100;
            numUpDownWeightCost.Value = (decimal)orderDetail.WeightCost;

            if (orderDetail.InterestRate != (float)retail_rate && orderDetail.InterestRate != (float)trade_rate)
            {
                checkBoxInterestRate.Checked = true;
            }

            if (orderDetail.ServiceFee > 0)
            {
                cBoxServiceFee.Checked = true; 
                numUpDownServiceFee.Value = (decimal)orderDetail.ServiceFee * 100;
            }
            else
            {
                numUpDownServiceFee.Value = (decimal) service_fee;
            }


            cboxIsCompleted.Checked = orderDetail.IsCompleted;
            customizableInterestRate = checkBoxInterestRate.Checked;
            hasServiceFee = cBoxServiceFee.Checked;
            numUpDownServiceFee.Enabled = hasServiceFee;
            numUpDownInterestRate.Enabled = customizableInterestRate;
            MoneyCount(numUpDownWeight, new EventArgs());
        }

        private void EditOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OrderForm form = new OrderForm();
            form.Show();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var orderDetail = db.OrderDetails.Where(x => x.OrderDetailId == id).FirstOrDefault();
            var orderId = orderDetail.OrderId;
            var userId = 0;
            var userName = txtBoxUserName.Text;
            var userNameQuery = db.Users.Where(x => x.UserName == userName).FirstOrDefault();
            if(userNameQuery != null)
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
            var CNY = (double) numUpDownCNY.Value;
            var weightCost = (double)numUpDownWeightCost.Value; //Giá cân
            var totalCost = Functions.ExtensionMethods.RoundUpDown(costPerProduct * amount * CNY);
            var finalCost = Functions.ExtensionMethods.RoundUpDown(totalCost * (1+ interestRate));
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
            orderDetail.OrderId = orderId;
            orderDetail.UserId = userId;
            orderDetail.ProductName = txtBoxProductName.Text;
            orderDetail.ProductLink = txtBoxLink.Text;
            orderDetail.Size = txtBoxSize.Text;
            orderDetail.Model = txtBoxModel.Text;
            orderDetail.Note = txtBoxNote.Text;
            orderDetail.CostPerProduct = costPerProduct;
            orderDetail.Amount = amount;
            orderDetail.InterestRate = interestRate;
            orderDetail.TotalCost = totalCost;
            orderDetail.FinalCost = finalCost;
            orderDetail.ServiceFee = serviceFee;
            orderDetail.Weight = weight;
            orderDetail.TotalWeightCost = (float)totalWeightCost;
            orderDetail.IsCompleted = cboxIsCompleted.Checked;

            //In case order was changed
            var order = db.Orders.Where(x => x.OrderId == orderId).FirstOrDefault();
            if(order.LadingNo != txtBoxLadingNo.Text)
            {
                var newOrder = new Order {LadingNo = txtBoxLadingNo.Text, Shipper = txtBoxShipper.Text,
                    ShopName = txtBoxShopName.Text, packageCreated = cboxPackageCreated.Checked,  isDeleted = false, OrderDate = dateTimePicker1.Value };
                db.Orders.Add(newOrder);
                db.SaveChanges();
                orderDetail.OrderId = newOrder.OrderId;
            }
            else
            {
                order.ShopName = txtBoxShopName.Text;
                order.Shipper = txtBoxShipper.Text;
                order.OrderDate = dateTimePicker1.Value;
                order.packageCreated = cboxPackageCreated.Checked;
            }

            db.SaveChanges();
            Close();
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
