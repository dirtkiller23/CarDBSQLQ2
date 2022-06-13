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
    /// Interaction logic for ViolationPage.xaml
    /// </summary>
    public partial class ViolationPage : Page
    {
        CarDriverDBEntities1 context;
        public ViolationPage()
        {
            InitializeComponent();
            context = new CarDriverDBEntities1();
            violationstable.ItemsSource = context.Violation.ToList();
        }
        public void RefreshData()
        {
            var list = context.Violation.ToList();
            if (!string.IsNullOrWhiteSpace(numViolationBox.Text))
            {
                list = list.Where(x => x.title.ToString().Contains(numViolationBox.Text.ToString())).ToList();
            }
            violationstable.ItemsSource = list;
        } 
        private void ChangeTitle(object sender,TextChangedEventArgs e)
        {
            RefreshData();
        }
        private void AddViolPage(object sender, RoutedEventArgs e)
        {
            NewFrameEdit.Navigate(new AddViolation(context));
        }

        private void EditViolPage(object sender,RoutedEventArgs e)
        {
            Violation violation = violationstable.SelectedItem as Violation;
            NewFrameEdit.Navigate(new AddViolation(context, violation));
        }
        private void DeleteViolPage(object sender,RoutedEventArgs e)
        {
            
            MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить нарушение?", "Подтвердить", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                   
                    Violation violation = violationstable.SelectedItem as Violation;
                    context.Violation.Remove(violation);
                    context.SaveChanges();
                    NewFrameEdit.Navigate(new ViolationPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка,удалите все данные нарушения!");
                }
            }
        }
    }
  
}
