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

namespace WPF_EmployeeManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void AddNewEmployee(object sender, RoutedEventArgs eventArgs)
        {

        }
        public void LostFocus(object sender, RoutedEventArgs eventArgs)
        {
            TextBox SenderTB = (TextBox) sender;
            Label ErrorLabel = (Label)RootGrid.FindName(SenderTB.Name + "Error");
            if (SenderTB.Text == "")
            {
                ErrorLabel.Visibility = Visibility.Visible;
            }
            else if(SenderTB.Text!="" && SenderTB.IsVisible)
            {
                ErrorLabel.Visibility = Visibility.Hidden;
            }
        }
    }
}
