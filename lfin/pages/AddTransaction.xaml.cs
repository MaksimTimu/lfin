using System;
using System.Collections.Generic;
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
    public partial class AddTransaction : Page
    {
        public AddTransaction()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var date = DateBox.SelectedDate;
            if (date == null) {
                MessageBox.Show("дурачок или преподаватель, введи(те) дату");
            } else {
                core.create_tx(AccountBox.Text, Convert.ToDouble(AmountBox.Text), date.Value, DescriptionBox.Text, CategoriesBox.Text);
                MessageBox.Show("Добовлено");
            }
        }
    }
}
