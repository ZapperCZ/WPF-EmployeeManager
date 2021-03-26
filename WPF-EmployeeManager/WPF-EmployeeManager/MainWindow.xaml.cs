using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        List<Employee> Employees = new List<Employee>();
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
            Employee RandomEmployee = new Employee("Petr","Vomáčka",1986,"Tertiary","Manager",80000);
            Employees.Add(RandomEmployee);
            UpdateOutput();
        }
        public void AddNewEmployee(object sender, RoutedEventArgs eventArgs)
        {
            Employee NewEmployee = new Employee(Name.Text, Surname.Text, Convert.ToInt32(BirthYear.Text), Education.Text, WorkPosition.Text, Convert.ToInt32(Salary.Text));
            Employees.Add(NewEmployee);
            UpdateOutput();

            if (Employees.Count() == 5)
            {
                ((Button)sender).IsEnabled = false;
            }
        }
        public void RemoveEmployee(object sender, RoutedEventArgs eventArgs)
        {
            int index = int.Parse(((Control)sender).Name[((Control)sender).Name.Length-1].ToString());
            index--;
            Employees.Remove(Employees[index]);
            UpdateOutput();
        }
        public void LostFocus(object sender, RoutedEventArgs eventArgs)
        {
            TextBox SenderTB = new TextBox();
            SenderTB = (TextBox)sender;
            Label ErrorLabel = (Label)RootGrid.FindName(SenderTB.Name + "Error");
            if (SenderTB.Text.Trim().Length<3)
            {
                ErrorLabel.Visibility = Visibility.Visible;
            }
            else if (SenderTB.Name.ToLower().Contains("birth") || SenderTB.Name.ToLower().Contains("salary"))
            {
                try
                {
                    Convert.ToInt32(SenderTB.Text);
                    ErrorLabel.Visibility = Visibility.Visible;
                    if (SenderTB.Name.ToLower().Contains("birth"))
                    {
                        if (SenderTB.Text.Trim().Length == 4)
                        {
                            ErrorLabel.Visibility = Visibility.Hidden;
                        }
                    }
                    else
                    {
                        if (SenderTB.Text.Trim().Length >= 4)
                        {
                            ErrorLabel.Visibility = Visibility.Hidden;
                        }
                    }
                }
                catch
                {
                    ErrorLabel.Visibility = Visibility.Visible;
                }
            }
            else if (ErrorLabel.IsVisible)
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
                string controlName = ErrorLabel.Name.Remove(ErrorLabel.Name.IndexOf("Error"));
                if (!ErrorLabel.Name.ToLower().Contains("education"))
                {
                    TextBox TBToCheck = (TextBox) RootGrid.FindName(controlName);
                    if (TBToCheck.Name.ToLower().Contains("birth") || TBToCheck.Name.ToLower().Contains("salary"))
                    {
                        try
                        {
                            Convert.ToInt32(TBToCheck.Text);
                            if (TBToCheck.Name.ToLower().Contains("birth"))
                            {
                                if (TBToCheck.Text.Trim().Length != 4)
                                {
                                    result = false;
                                }
                            }
                            else
                            {
                                if (TBToCheck.Text.Trim().Length < 4)
                                {
                                    result = false;
                                }
                            }
                        }
                        catch
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        if (TBToCheck.Text.Trim().Length < 3)
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    ComboBox CBToCheck = (ComboBox)RootGrid.FindName(controlName);
                    if (CBToCheck.Text == "")
                    {
                        result = false;
                    }
                }

                if (ErrorLabel.IsVisible)
                {
                    result = false;
                }
            }
            return result;
        }
        void UpdateOutput()
        {
            for(int i = 0; i < 5; i++)
            {
                int index = i + 1;
                TextBox outputName = (TextBox)RootGrid.FindName("Name" + index);
                TextBox outputSurname = (TextBox)RootGrid.FindName("Surname" + index);
                TextBox outputBirthYear = (TextBox)RootGrid.FindName("BirthYear" + index);
                TextBox outputEducation = (TextBox)RootGrid.FindName("Education" + index);
                TextBox outputWorkPosition = (TextBox)RootGrid.FindName("WorkPosition" + index);
                TextBox outputSalary = (TextBox)RootGrid.FindName("Salary" + index);
                Button deleteButton = (Button)RootGrid.FindName("Delete" + index);

                if (i<Employees.Count)
                {
                    outputName.Text = Employees[i].Name;
                    outputSurname.Text = Employees[i].Surname;
                    outputBirthYear.Text = Employees[i].BirthYear.ToString();
                    outputEducation.Text = Employees[i].Education;
                    outputWorkPosition.Text = Employees[i].WorkPosition;
                    outputSalary.Text = Employees[i].Salary.ToString();
                    deleteButton.Visibility = Visibility.Visible;
                }
                else
                {
                    outputName.Text = "";
                    outputSurname.Text = "";
                    outputBirthYear.Text = "";
                    outputEducation.Text = "";
                    outputWorkPosition.Text = "";
                    outputSalary.Text = "";
                    deleteButton.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
