using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Models
{
    public class User
    {
        public int UserId { get; set; }
        [DisplayName("Tên Khách Hàng")]
        public string UserName { get; set; }
        [DisplayName("Tiền Đã Đặt Cọc")]
        public double Deposit { get; set; } //Cọc

        [DisplayName("Tổng Cân")]
        public float TotalWeight { get; set; }

        [DisplayName("Tổng Tiền Cân")]
        public double TotalWeightCost { get; set; }

        [DisplayName("Tiền Trả Sau")]
        public double LeftOver { get; set; } //Tiền Trả Sau
        [DisplayName("Tổng Tiền Sản Phẩm")]
        public double ProductCost { get; set; } //Deposit + LeftOver
        [DisplayName("Tổng Tiền + Cân")]
        public double TotalCost { get; set; } //Deposit + LeftOver + TotalWeightCost
    }
}
