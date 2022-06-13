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
    /// Interaction logic for AddDrivers.xaml
    /// </summary>
    public partial class AddDrivers : Page
    {
        CarDriverDBEntities1 context;

        public AddDrivers(CarDriverDBEntities1 cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;

        }
        bool flag;

        private void SaveDrivers(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Driver driv = new Driver()
                {
                    numDriverDocument = Convert.ToInt64(iddriverdocBox.Text),
                    name = nameBox.Text,
                    phone = Convert.ToDecimal(phonenumberBox.Text),
                    adres = adressBox.Text
                };
                context.Driver.Add(driv);
                context.SaveChanges();
                NavigationService.Navigate(new DriversPage());
            }
            else
            {
                context.Driver.Find(dri.numDriverDocument).numDriverDocument = Convert.ToInt64(iddriverdocBox.Text);
                context.Driver.Find(dri.numDriverDocument).name = nameBox.Text;
                context.Driver.Find(dri.numDriverDocument).phone = Convert.ToDecimal(phonenumberBox.Text);
                context.Driver.Find(dri.numDriverDocument).adres = adressBox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new DriversPage());
            }
        }
        Driver dri;

        public AddDrivers(CarDriverDBEntities1 cont, Driver driver)
        {
            InitializeComponent();
            context = cont;
            dri = driver;
            iddriverdocBox.Text = driver.numDriverDocument.ToString();
            nameBox.Text = driver.name;
            phonenumberBox.Text = driver.phone.ToString();
            adressBox.Text = driver.adres;
            flag = false;
        }
    }


}
