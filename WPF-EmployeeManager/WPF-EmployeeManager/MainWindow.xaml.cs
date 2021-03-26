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
        List<Label> ErrorLabels = new List<Label>();
        Employee[] Employees = new Employee[5];
        public MainWindow()
        {
            InitializeComponent();
            foreach(Control control in RootGrid.Children)
            {
                if (control.Name.ToLower().Contains("error"))
                {
                    ErrorLabels.Add((Label)control);
                }
            }
        }
        public void AddNewEmployee(object sender, RoutedEventArgs eventArgs)
        {
            //Employee NewEmployee = new Employee();
            UpdateOutput();
        }
        public void RemoveEmployee(object sender, RoutedEventArgs eventArgs)
        {
            UpdateOutput();
        }
        public void LostFocus(object sender, RoutedEventArgs eventArgs)
        {
            TextBox SenderTB = new TextBox();
            SenderTB = (TextBox)sender;
            Label ErrorLabel = (Label)RootGrid.FindName(SenderTB.Name + "Error");
            if (SenderTB.Text == "")
            {
                ErrorLabel.Visibility = Visibility.Visible;
            }
            else if (SenderTB.Text != "" && ErrorLabel.IsVisible)
            {
                ErrorLabel.Visibility = Visibility.Hidden;
            }
            ButtonAddEmployee.IsEnabled = IsEverythingFilledOut();
        }

        void OnDropDownClosed(object sender, EventArgs e)
        {
            ComboBox SenderCB = (ComboBox)sender;
            Label ErrorLabel = (Label)RootGrid.FindName(SenderCB.Name + "Error");
            if (SenderCB.Text == "")
            {
                ErrorLabel.Visibility = Visibility.Visible;
            }
            else if (SenderCB.Text != "" && ErrorLabel.IsVisible)
            {
                ErrorLabel.Visibility = Visibility.Hidden;
            }
            ButtonAddEmployee.IsEnabled = IsEverythingFilledOut();
        }
        bool IsEverythingFilledOut()
        {
            bool result = true;
            foreach(Label ErrorLabel in ErrorLabels)
            {
                if (ErrorLabel.IsVisible)
                {
                    result = false;
                }
            }
            return result;
        }
        void UpdateOutput()
        {

        }
    }
}
