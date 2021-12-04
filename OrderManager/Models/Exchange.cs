using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Models
{
    public class Exchange
    {
        public int ExchangeId { get; set; }
        public string ExchangeName { get; set; }
        [DisplayName("Tên Quy Đổi")]
        public string DisplayName { get; set; }
        [DisplayName("Giá Trị")]
        public double ExchangeNum { get; set; }
        [DisplayName("Ngày Tạo")]
        public DateTime ExchangeDate { get; set; }
    }
}
