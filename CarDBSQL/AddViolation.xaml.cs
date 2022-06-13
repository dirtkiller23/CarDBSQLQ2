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
    /// Interaction logic for AddViolation.xaml
    /// </summary>
    public partial class AddViolation : Page
    {
        CarDriverDBEntities1 context;

        public AddViolation(CarDriverDBEntities1 cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;

        }
        bool flag;

        private void SaveViolation(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Violation violat = new Violation()
                {
                    id = Convert.ToInt64(idvioBox.Text),
                    title = violationBox.Text,
                    penaltyRange = penaltyRangeBox.Text,
                    deprivationLicense = yearBox.Text
                };
                context.Violation.Add(violat);
                context.SaveChanges();
                NavigationService.Navigate(new ViolationPage());
            }
            else
            {
                context.Violation.Find(viola.id).id = Convert.ToInt64(idvioBox.Text);
                context.Violation.Find(viola.id).title = violationBox.Text;
                context.Violation.Find(viola.id).penaltyRange = penaltyRangeBox.Text;
                context.Violation.Find(viola.id).deprivationLicense = yearBox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new ViolationPage());
            }
        }
        Violation viola;

        public AddViolation(CarDriverDBEntities1 cont,Violation violation)
        {
            InitializeComponent();
            context = cont;
            viola = violation;
            idvioBox.Text = violation.id.ToString();
            violationBox.Text = violation.title;
            penaltyRangeBox.Text = violation.penaltyRange;
            yearBox.Text = violation.deprivationLicense;
            flag = false;
        }
    }
   
   
}
