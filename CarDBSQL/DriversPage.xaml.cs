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

namespace CarDBSQL
{
    /// <summary>
    /// Interaction logic for DriversPage.xaml
    /// </summary>
    public partial class DriversPage : Page
    {
        CarDriverDBEntities1 context;
        public DriversPage()
        {
            InitializeComponent();
            context = new CarDriverDBEntities1();
            drivertable.ItemsSource = context.Driver.ToList();
            
        }
        public void RefreshData()
        {
            var list = context.Driver.ToList();
            if (!string.IsNullOrWhiteSpace(numDriverBox.Text))
            {
                list = list.Where(x => x.numDriverDocument.ToString().Contains(numDriverBox.Text.ToString())).ToList();
            }
            drivertable.ItemsSource = list;
        }
        private void ChangeNumber(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }
        private void AddDrivPage(object sender, RoutedEventArgs e)
        {
            NewFrame2Edit.Navigate(new AddDrivers(context));
        }

        private void EditDrivPage(object sender, RoutedEventArgs e)
        {
            Driver driver = drivertable.SelectedItem as Driver;
            NewFrame2Edit.Navigate(new AddDrivers(context, driver));
        }
        private void DeleteDrivPage(object sender, RoutedEventArgs e)
        {

            MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить водителя?", "Подтвердить", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {

                    Driver driver = drivertable.SelectedItem as Driver;
                    context.Driver.Remove(driver);
                    context.SaveChanges();
                    NewFrame2Edit.Navigate(new DriversPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка,удалите все данные водителя!");
                }
            }
        }
    }

}
