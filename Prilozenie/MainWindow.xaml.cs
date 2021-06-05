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

namespace Prilozenie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Telephone_subscribers> _MyTelephone;

        public List<Telephone_subscribers> MyTelephone
        {
            get
            {
                return _MyTelephone;
                    }
            set
            {
                _MyTelephone = value;
                    }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            MyTelephone = Core.DB.Telephone_subscribers.ToList();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var _MyTelephone = PhoneDataGrid.SelectedItem as Telephone_subscribers;
            try
            {
                Core.DB.Telephone_subscribers.Remove(_MyTelephone);
                Core.DB.SaveChanges();
                MyTelephone = Core.DB.Telephone_subscribers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении объекиа недвижимости: {ex.Message}");
            }
        }
    }
}