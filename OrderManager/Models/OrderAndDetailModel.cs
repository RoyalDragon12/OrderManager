using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Models
{
    class OrderAndDetailModel
    {
        public string STT { get; set; }
        public int OrderDetailId { get; set; }
        [DisplayName("Mã Vận Đơn")]
        public string LadingNo { get; set; } 
        [DisplayName("Đơn Vị Vận Chuyển")]
        public string Shipper { get; set; }
        [DisplayName("Tên Shop")]
        public string ShopName { get; set; }
        [DisplayName("Ngày Đặt")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Đã Tạo Kiện Hàng")]
        public bool PackageCreated { get; set; } //Đã tạo kiện hàng để ship về VN
        [DisplayName("Tên Người Đặt")]
        public string UserName { get; set; }
        [DisplayName("Tên Sản Phẩm")]
        public string ProductName { get; set; }
        [DisplayName("Giá Tệ")]
        public double CostPerProduct { get; set; } 
        [DisplayName("Số Lượng")]
        public int Amount { get; set; }
        [DisplayName("Link")]
        public string ProductLink { get; set; }
        [DisplayName("Size / Loại")]
        public string Size { get; set; } //Size / Kg
        [DisplayName("Mẫu Mã")]
        public string Model { get; set; } //Mẫu Mã
        [DisplayName("Công (%)")]
        public float InterestRate { get; set; } //% Công
        [DisplayName("Tiền Sản Phẩm")]
        public double TotalCost { get; set; } //Tiền SP
        [DisplayName("Giá Báo")]
        public double FinalCost { get; set; } //Tiền SP + Lời
        [DisplayName("Chi Phí Phát Sinh")]
        public double AdditionalCost { get; set; }
        [DisplayName("Phí Dịch Vụ Credit Card (%)")]
        public float ServiceFee { get; set; }
        [DisplayName("Phí Dịch Vụ (VND)")]
        public double ServiceCost { get; set; }
        [DisplayName("Khối Lượng")]
        public float Weight { get; set; }
        [DisplayName("Tiền Cân")]
        public float WeightCost { get; set; }
        [DisplayName("Giá Báo + Cân")]
        public double FinalAndWeightCost { get; set; }
        [DisplayName("Ghi Chú")]
        public string Note { get; set; }
        [DisplayName("Đã Thanh Toán")]
        public bool IsCompleted { get; set; }
        [DisplayName("Tiền Lời")]
        public double IncomeMoney { get; set; }

    }
}
