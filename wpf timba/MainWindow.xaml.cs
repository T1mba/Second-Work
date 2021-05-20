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


    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string SelectedJanr = "";

        private IEnumerable<Book> _BookList = null;

        public event PropertyChangedEventHandler PropertyChanged;
        private string SearchFilter = "";

        
        public IEnumerable<Book> BookList 
        {

             
                get {
                   
                 var res = _BookList;
                 res = res.Where(c => SelectedJanr =="Все жанры" | c.Janr == SelectedJanr);

                if (SearchFilter != "")
                    res = res.Where(c => c.NameAvtor.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) >= 0);

                return res;
            }
                set
            {
                    _BookList = value;
                }
            }
            



        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Globals.dataProvider = new LocalDataProvider();
            BookList = Globals.dataProvider.GetBooks();
            BookJanrList = Globals.dataProvider.GetBookJanrs().ToList();
            BookJanrList.Insert(0, new BookJanr { Title = "Все жанры" });
            

        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public List<BookJanr> BookJanrList { get; set; }

        private void Invalidate()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("BookList"));
        }
        private void BreedFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedJanr = (BreedFilterComboBox.SelectedItem as BookJanr).Title;
            Invalidate();
        }

        private void SearchFilterTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SearchFilter = SearchFilterTextBox.Text;
            Invalidate();
        }
    }
}

