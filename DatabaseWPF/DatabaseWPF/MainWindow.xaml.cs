using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext context = new DataContext();
            dataGrid.ItemsSource = context.Cake.ToList();
        }





        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext context = new DataContext();

            Cake cake = new Cake()
            {
                Name = Name.Text,
                Quantity = Convert.ToInt32(Quantity.Text),
                Price = Convert.ToInt32(Price.Text),
            };

            context.Cake.Add(cake);
            context.SaveChanges();

            UpdateTable();
        }

        private void UpdateTable()
        {
            DataContext context = new DataContext();
            dataGrid.ItemsSource = context.Cake.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private int updatingDoctorId = 0;

        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if(dataGrid.SelectedIndex >= 0)
            {
                if(dataGrid.SelectedItems.Count > 0 )
                {
                    Cake d = (Cake)dataGrid.SelectedItems[0];
                    updatingDoctorId = d.Id;

                    Name.Text = d.Name;
                    Quantity.Text = Convert.ToString(d.Quantity);
                    Price.Text = Convert.ToString(d.Price);
                }
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            DataContext context = new DataContext();

            if (updatingDoctorId != 0)
            {
                context.Remove(context.Cake.Single(a => a.Id == updatingDoctorId));
                context.SaveChanges();

                UpdateTable();
            }
            Reset();
        }
        
        private void Reset()
        {
            Name.Text = "Name";
            Quantity.Text = "Quantity";
            Price.Text = "Price";

        }

        private void UpdateClick(object sender, RoutedEventArgs e) {
            DataContext context = new DataContext();

            if (updatingDoctorId != 0)
            {
                var result = context.Cake.SingleOrDefault(b => b.Id == updatingDoctorId);
                
                if (result != null)
                {
                    result.Name = Name.Text;
                    result.Quantity = Convert.ToInt32(Quantity.Text);
                    result.Price = Convert.ToInt32(Price.Text);
                    
                    context.SaveChanges();
                }
                Reset();

                UpdateTable();
            }
        }
    }
}