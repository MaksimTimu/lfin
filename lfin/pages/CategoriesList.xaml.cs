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
    public partial class CategoriesList : Page
    {
        public CategoriesList()
        {
            InitializeComponent();
            CategoriesListt.ItemsSource = core.db.categories.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesListt.SelectedItem != null)
            {
                core.db.categories.Remove(CategoriesListt.SelectedItem as categories);
                core.db.SaveChanges();
                CategoriesListt.ItemsSource = core.db.categories.ToList();
            }
            else
            {
                MessageBox.Show("Выберите категорию");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CategoriesListt.SelectedItem != null)
            {
                var id_ = (CategoriesListt.SelectedItem as categories).id;
                core.db.categories.Where(x => x.id == id_).First().type = loh.Text;
                core.db.SaveChanges();
                CategoriesListt.ItemsSource = core.db.categories.ToList();
            }
            else
            {
                MessageBox.Show("Выберите категорию");
            }
        }

        private void CategoriesListt_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesListt.SelectedItem != null)
            {
                var id_ = (CategoriesListt.SelectedItem as categories).id;
                loh.Text = core.db.categories.Where(x => x.id == id_).First().type;
            }
        }
    }
}
