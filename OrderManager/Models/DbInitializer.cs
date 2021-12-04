using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OrderManager.Models
{
    public class DbInitializer : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext db)
        {
            var CNY = new Exchange { ExchangeId = 1, ExchangeName = "CNY", ExchangeNum = 4000, ExchangeDate = DateTime.Today };
            db.Exchanges.Add(CNY); //Giá Tệ
            var retail_exchange = new Exchange {ExchangeId = 2, ExchangeName = "Retail Rate", ExchangeNum = 0.1, ExchangeDate = DateTime.Today };
            db.Exchanges.Add(retail_exchange); //Giá Lẻ
            var trade_exchange = new Exchange { ExchangeId = 3, ExchangeName = "Trade Rate", ExchangeNum = 0.05, ExchangeDate = DateTime.Today };
            db.Exchanges.Add(trade_exchange); // Giá Sỉ
            var trade_min_exchange = new Exchange { ExchangeId = 4, ExchangeName = "Trade Min", ExchangeNum = 100, ExchangeDate = DateTime.Today };
            db.Exchanges.Add(trade_min_exchange); //Giá Thấp Nhất Để Tính Giá Sỉ
            var weight_cost_exchange = new Exchange { ExchangeId = 5, ExchangeName = "Weight Cost", ExchangeNum = 41000, ExchangeDate = DateTime.Today };
            db.Exchanges.Add(weight_cost_exchange); //Tiền Cân
            var service_fee_exchange = new Exchange { ExchangeId = 6, ExchangeName = "Service Fee", ExchangeNum = 0.03, ExchangeDate = DateTime.Today };
            db.Exchanges.Add(service_fee_exchange); //Phí Dịch Vụ

            base.Seed(db);
        }
    }
}
