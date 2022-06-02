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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarDriverDBEntities context;
        static int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            context = new CarDriverDBEntities();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            counter++;
            int numDriverDocument = Convert.ToInt32(login.Text);
            string pass = password.Text;
            
            Driver driver = context.Driver.ToList().Find(x => x.numDriverDocument == numDriverDocument);
            if (counter >= 3)
            {
                login.IsEnabled = false;
                login.Text = "";
                password.IsEnabled = false;
                password.Text = "";
                LoginButton.IsEnabled = false;
                MessageBox.Show("Превышено количество попыток(3)", "Критическая Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            if (driver == null)
            {
                MessageBox.Show("Данного водителя не существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            
            }
            else
            {
                if (driver.password.Equals(pass))
                {
                    MessageBox.Show("Вход выполнен!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
                } 
            }
        }
