using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public IEnumerable<Telephone_subscribers> _MyTelephone;

        public event PropertyChangedEventHandler PropertyChanged;


        public List<Street> StreetList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            MyTelephone = Core.DB.Telephone_subscribers.ToList();
            StreetList = Core.DB.Street.ToList();
            StreetList.Insert(0, new Street { Street1 = "Все улицы" });
        }

        public IEnumerable<Telephone_subscribers> MyTelephone
        {
            get
            {
                var res = _MyTelephone;

                // у объекта "Все улицы" Id=0, т.к. он взят не из базы, а создан в приложении
                // если выбрана улица, то выбираем только объекты с такой улицей
                if (_StreetFilterValue > 0)
                    res = res.Where(ai => ai.id_Street == _StreetFilterValue);
                if (SearchFilter != "")
                    res = res.Where(ai => ai.Street.Street1.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) >= 0);
                if (SortAsc) res = res.OrderBy(ai => ai.Kvartira);
                else res = res.OrderByDescending(ai => ai.Kvartira);

                return res;




            }
            set
            {
                _MyTelephone = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyTelephone"));
                }
            }
        }
            private bool _SortAsc = true;
        public bool SortAsc
        {
            get
            {
                return _SortAsc;
            }
            set
            {
                _SortAsc = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyTelephone"));
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SortAsc = (sender as RadioButton).Tag.ToString() == "1";
        }
  
            private string _SearchFilter = "";
    
        public string SearchFilter
        {
            get
            {
                return _SearchFilter;
            }
            set
            {
                _SearchFilter = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyTelephone"));
                }
            }
        }

        private void SearchFilter_KeyUp(object sender, KeyEventArgs e)
        {
            SearchFilter = SearchFilterTextBox.Text;

        


    }
            private int _StreetFilterValue = 0;
        public int StreetFilterValue
        {
            get
            {
                return _StreetFilterValue;
            }
            set
            {
                _StreetFilterValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyTelephone"));
                }
            }
        }

        private void StreetFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StreetFilterValue = (StreetFilter.SelectedItem as Street).id;
        }

    
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var NewMyTelephoneWindow = new AddWindow(new Telephone_subscribers());
            if (NewMyTelephoneWindow.ShowDialog() == true)
            {
                MyTelephone = Core.DB.Telephone_subscribers.ToList();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var EditMyTelephoneWindow = new AddWindow(PhoneDataGrid.SelectedItem as Telephone_subscribers);
            if (EditMyTelephoneWindow.ShowDialog() == true)
            {
                MyTelephone = Core.DB.Telephone_subscribers.ToList();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var _MyTelephone = PhoneDataGrid.SelectedItem as Telephone_subscribers;
            try
            {
                Core.DB.Telephone_subscribers.Remove(_MyTelephone);
                Core.DB.SaveChanges();
                MyTelephone = Core.DB.Telephone_subscribers.ToList();
                PropertyChanged(this, new PropertyChangedEventArgs("MyTelephone"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении объекта недвижимости: {ex.Message}");
            }

        }
    }
}
