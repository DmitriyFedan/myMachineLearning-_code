using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace testQlearning.Services
{
    public class Trader
    {   
        private int _id;
        private string _symbol;
        private decimal _balance;
        private List<Order> _orders;
        private readonly int _maxOrderCounts;


        public Trader(int id, string symbol, decimal balance, int maxOrderCounts)
        {
            _id = id;
            _symbol = symbol;
            _balance = balance;
            _orders = new List<Order>();
            _maxOrderCounts = maxOrderCounts;
        }

        public void OrderBy(decimal price)
        {
            if (_orders.Count >= _maxOrderCounts) 
            {
                return;
            }

            Order newOrder = new Order(_symbol, price, OrderType.BUY);
            _orders.Add(newOrder);

            Debug.Print($"oreder {newOrder.Type} was opened {newOrder.Id}");
        }

        public void OrderSell(decimal price)
        {
            if (_orders.Count >= _maxOrderCounts)
            {
                return;
            }

            Order newOrder = new Order(_symbol, price, OrderType.SELL);
            _orders.Add(newOrder);

            Debug.Print($"oreder {newOrder.Type} was opened {newOrder.Id}");
        }

        public void CloseOrder (Guid id )
        {
            var removableOrder = _orders.FirstOrDefault(order => order.Id == id);
            _balance += removableOrder.CurentProfit;
            _orders.Remove(removableOrder);
        }


        public void  Strategy()
        {
            var randomInt = new Random();

            var randomOrderType = randomInt.Next(0, 2);

            switch ((OrderType)randomOrderType)
            {
                case OrderType.BUY:

                    break;

                case OrderType.SELL:

                    break;

                default: break;
            }
        }

    }

    public class Order
    {
        public Guid Id { get; set; }
        public OrderType Type { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal CurentProfit { get; set; }

        public Order(string symbol, decimal price, OrderType type)
        {
            Id = Guid.NewGuid();
            Symbol = symbol;
            Price = price;
            Type = type;
        }
    }

    public enum OrderType
    {
        BUY = 1,
        SELL = 2
    } 
}
