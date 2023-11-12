using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using testQlearning.Services;

namespace testQlearning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Trader _trader;
        decimal _price = 1000;
        Random _randomvalue;

        public MainWindow()
        {
            InitializeComponent();



            _randomvalue = new Random();

            _trader = new Trader(10, "xauusd", 1000, 10);




        }

        private void Button_Click_Buy(object sender, RoutedEventArgs e)
        {
            _trader.OrderBy(_price);

            _price = _price + _randomvalue.Next(-20, 20);

        }

        private void Button_Click_Sell(object sender, RoutedEventArgs e)
        {
            _trader.OrderSell(_price);

            _price = _price + _randomvalue.Next(-20, 20);

        }
    }
}
