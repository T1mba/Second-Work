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
using wpf_timba.Model;

namespace wpf_timba
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged



    {

        public string SelectedNapravlenie = "";
        private IEnumerable<Abiturent> _AbitrentList = null;
        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<Abiturent> AbiturentList
        {
            get
            {
                var res = _AbitrentList;
                    res = res.Where(c => SelectedNapravlenie == "Все направления" | c.Napravlenie == SelectedNapravlenie);
                if (SearchFilter != "")
                    res = res.Where(c => c.Napravlenie.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) >= 0);
                else res = res.OrderByDescending(c => c.Napravlenie);
              
                if (SortAsc) res = res.OrderBy(c => c.Age);
                else res = res.OrderByDescending(c => c.Age);
                return res;
            }
            set
            {
                _AbitrentList = value;
            }
        }
       

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Globals.dataProvider = new LocalDataProvider();
            AbiturentList = Globals.dataProvider.GetAbiturents();
            AbiturentNapravleniesList = Globals.dataProvider.GetAbiturentNapravlenies().ToList();
            AbiturentNapravleniesList.Insert(0, new AbiturentNapravlenie { Title = "Все направления" });


        }
        public List<AbiturentNapravlenie> AbiturentNapravleniesList { get; set; }



        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        private void Invalidate()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("AbiturentList"));
        }
        private void AbiturentNapravleniesFilterCobmoBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedNapravlenie = (AbiturentNapravleniesFilterCobmoBox.SelectedItem as AbiturentNapravlenie).Title;
            Invalidate();
        }
        private string SearchFilter = "";
        private void SearchFilterTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SearchFilter = SearchFilterTextBox.Text;
            Invalidate();
        }
        private bool SortAsc = true;
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SortAsc = (sender as RadioButton).Tag.ToString() == "1";
            Invalidate();
        }
    }
}
