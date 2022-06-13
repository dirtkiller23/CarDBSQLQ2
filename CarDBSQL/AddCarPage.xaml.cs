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
    /// Interaction logic for AddCarPage.xaml
    /// </summary>
    public partial class AddCarPage : Page
    {
        CarDriverDBEntities1 context;
        public AddCarPage(CarDriverDBEntities1 cont)
        {
            InitializeComponent();
            context = cont;
            markaddComboBox.ItemsSource = context.Car.ToList();
            flag = true;
        }
        bool flag;
        private void SaveCar(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Car car = new Car()
                {
                    StateNumber = idstatenumBox.Text,
                    mark = (markaddComboBox.SelectedItem as Car).mark,
                    model = carmodelBox.Text,
                    color = coloraddBox.Text,
                    madeYear = Convert.ToInt64(yearaddBox.Text),
                    dateOfRegistration = Convert.ToDateTime(dateBox.SelectedDate)
                };
                context.Car.Add(car);
                context.SaveChanges();
                NewFrame3Edit.Navigate(new CarPage());
            }
            else
            {
                context.Car.Find(caw.StateNumber).StateNumber = idstatenumBox.Text;
                context.Car.Find(caw.StateNumber).mark = (markaddComboBox.SelectedItem as Car).mark ;
                context.Car.Find(caw.StateNumber).model = carmodelBox.Text;
                context.Car.Find(caw.StateNumber).color = coloraddBox.Text;
                context.Car.Find(caw.StateNumber).madeYear = Convert.ToInt64(yearaddBox.Text);
                context.Car.Find(caw.StateNumber).dateOfRegistration = Convert.ToDateTime(dateBox.SelectedDate);
                context.SaveChanges();
                NewFrame3Edit.Navigate(new CarPage());
            }
        }
        Car caw;

        public AddCarPage(CarDriverDBEntities1 cont, Car caww)
        {
            InitializeComponent();
            context = cont;
            caw = caww;
            markaddComboBox.ItemsSource = context.Car.ToList();
            idstatenumBox.Text = caw.StateNumber;
            markaddComboBox.SelectedItem = caw.mark;
            carmodelBox.Text = caw.model;
            coloraddBox.Text = caw.color;
            yearaddBox.Text = caw.madeYear.ToString();
            dateBox.SelectedDate = caw.dateOfRegistration;
            flag = false;
        }
    }
}
