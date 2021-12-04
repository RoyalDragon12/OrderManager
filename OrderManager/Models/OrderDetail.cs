using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public double CostPerProduct { get; set; } //Giá Theo Tệ
        public int Amount { get; set; }
        public double CNY { get; set; } //Giá Tệ
        public string ProductLink { get; set; }
        public float InterestRate { get; set; } //% Công
        public double TotalCost { get; set; } //Tiền SP
        public double FinalCost { get; set; } //Tiền SP + Lời
        public float ServiceFee { get; set; } //Phí Dịch Vụ Thẻ Tín Dụng
        public float Weight { get; set; }
        public double WeightCost { get; set; } //Giá Cân
        public float TotalWeightCost { get; set; } //Tiền Cân
        public string Size { get; set; } //Size / Kg
        public string Model { get; set; } //Mẫu Mã
        public string Note { get; set; }
        public bool IsCompleted { get; set; } //Đã thanh toán
        public bool IsDeleted { get; set; }
        public double AdditionalCost { get; set; }
        
        public virtual Order Orders { get; set; }
        public virtual User Users { get; set; }

    }
}
