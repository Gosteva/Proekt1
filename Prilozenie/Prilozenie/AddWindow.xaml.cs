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
using System.Windows.Shapes;

namespace Prilozenie
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {

        public Telephone_subscribers CurrentPhone { get; set; }
        public IEnumerable<City> CityList { get; set; }
        public IEnumerable<Street> StreetList { get; set; }

        public AddWindow(Telephone_subscribers CurrentTelphone)
        {
            InitializeComponent();
            DataContext = this;
            CurrentPhone = CurrentTelphone;
            CityList = Core.DB.City.ToArray();
            StreetList = Core.DB.Street.ToArray();
        }
     

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                if (CurrentPhone.City == null)
                    throw new Exception("Не выбран город");

                if (CurrentPhone.Street == null)
                    throw new Exception("Не выбрана улица");

                if (CurrentPhone.Id == 0)
                    Core.DB.Telephone_subscribers.Add(CurrentPhone);

                Core.DB.SaveChanges();
                DialogResult = true;

                MessageBox.Show($"Сохранено");

            
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка:{ex.Message}");
            }



        }
    }
}
