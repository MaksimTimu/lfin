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
    public partial class AccountsList : Page
    {
        public AccountsList()
        {
            InitializeComponent();
            SVO.ItemsSource = core.db.accounts.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SVO.SelectedItem != null)
            {
                core.db.accounts.Remove(SVO.SelectedItem as accounts);
                core.db.SaveChanges();
                SVO.ItemsSource = core.db.accounts.ToList();
            }
            else
            {
                MessageBox.Show("Выберите счёт");
            }
        }
    }
}
