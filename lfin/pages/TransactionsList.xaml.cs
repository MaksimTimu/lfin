
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

namespace lfin.pages
{
    public class FunctionConverter : IValueConverter
    {
        public string FunctionName { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return core.db.accounts.Where(x => x.id == (int)value).First().name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
    public class FunctionConverter2 : IValueConverter
    {
        public string FunctionName { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return core.get_cats((int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
    public partial class TransactionsList : Page
    {
        public TransactionsList()
        {
            InitializeComponent();
            TxListt.ItemsSource = core.db.transactions.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new pages.AddTransaction());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<transactions> b = new List<transactions>();
            foreach (var a in core.db.transactions.ToList())
            {
                if (core.get_cats(a.id).Contains(loh.Text))
                    b.Add(a);
            }
            TxListt.ItemsSource = b;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TxListt.SelectedItem != null)
            {
                core.db.transactions.Remove(TxListt.SelectedItem as transactions);
                core.db.SaveChanges();
                TxListt.ItemsSource = core.db.transactions.ToList();
            }
            else
            {
                MessageBox.Show("Выберите транзу");
            }
        }
    }
}
