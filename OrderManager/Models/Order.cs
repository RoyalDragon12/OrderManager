using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [DisplayName("Mã Vận Đơn")]
        public string LadingNo { get; set; } //Mã vận Đơn
        [DisplayName("Tên Shop")]
        public string ShopName { get; set; }
        [DisplayName("Ngày Đặt")]
        public DateTime OrderDate { get; set; }
        public string Shipper { get; set; }
        public bool packageCreated { get; set; } //Đã tạo kiện hàng để ship về VN
        public bool isDeleted { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
