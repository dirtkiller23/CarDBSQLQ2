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
    /// Interaction logic for CarPage.xaml
    /// </summary>
    public partial class CarPage : Page
    {
        CarDriverDBEntities1 context;
        public CarPage()
        {
            InitializeComponent();
            context = new CarDriverDBEntities1();
            cartable.ItemsSource = context.Car.ToList();

            var markList = context.Car.ToList();
            markList.Insert(0, new Car() { mark = "Все" });
            MarkBox.ItemsSource = markList;
            
        }
        public void RefreshData()
        {
            var list = context.Car.ToList();
            if (MarkBox.SelectedIndex > 0)
            {
                Car caw = MarkBox.SelectedItem as Car;
                list = list.Where(x => x.mark == caw.ToString()).ToList();
            }
            if (!string.IsNullOrWhiteSpace(numDriverBox.Text))
            {
                list = list.Where(x => x.StateNumber.ToLower().Contains(numDriverBox.Text.ToLower())).ToList();
            }
            cartable.ItemsSource = list;
        }
        private void ChangeMark(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }
        private void ChangeStateNumber(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }
        private void AddCarPage(object sender, RoutedEventArgs e)
        {
            NewFrame3Edit.Navigate(new AddCarPage(context));
        }
        private void EditCarPage(object sender, RoutedEventArgs e)
        {
            Car caw = cartable.SelectedItem as Car;
            NewFrame3Edit.Navigate(new AddCarPage(context, caw));
        }
        private void DeleteCarPage(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить машину?", "Подтвердить", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Car car = cartable.SelectedItem as Car;
                    context.Car.Remove(car);
                    context.SaveChanges();
                    NewFrame3Edit.Navigate(new CarPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка, невозможно удалить данные машины!");
                }
            }
        }
    }
}