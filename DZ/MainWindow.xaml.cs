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

namespace EFCore_HomeWork_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AcademyContext context = new();
        public MainWindow()
        {
            InitializeComponent();
            ComboBox.ItemsSource = new List<string> { "Schedules", "Teachers", "Subjects","Assistants","Curators", "Deans", "Departments", "Faculties", "Groups", "GroupsCurators", "GroupsLectures","Heads","Lectures","LectureRooms" };
            ComboBox.SelectedIndex = 0;
        }

        public void GetButtonClick(object sender, EventArgs e)
        {
            switch (ComboBox.SelectedItem)
            {
                case "Schedules":
                    DataGrid.ItemsSource = context.Schedules.Local.ToObservableCollection();
                    break;
                case "Teachers":
                    DataGrid.ItemsSource = context.Teachers.Local.ToObservableCollection();
                    break;
                case "Subjects":
                    DataGrid.ItemsSource = context.Subjects.Local.ToObservableCollection();
                    break;
                case "Assistants":
                    DataGrid.ItemsSource = context.Assistants.Local.ToObservableCollection();
                    break;
                case "Curators":
                    DataGrid.ItemsSource = context.Curators.Local.ToObservableCollection();
                    break;
                case "Deans":
                    DataGrid.ItemsSource = context.Deans.Local.ToObservableCollection();
                    break;
                case "Departments":
                    DataGrid.ItemsSource = context.Departments.Local.ToObservableCollection();
                    break;
                case "Faculties":
                    DataGrid.ItemsSource = context.Faculties.Local.ToObservableCollection();
                    break;
                case "Groups":
                    DataGrid.ItemsSource = context.Groups.Local.ToObservableCollection();
                    break;
                case "GroupsCurators":
                    DataGrid.ItemsSource = context.GroupsCurators.Local.ToObservableCollection();
                    break;
                case "GroupsLectures":
                    DataGrid.ItemsSource = context.GroupsLectures.Local.ToObservableCollection();
                    break;
                case "Heads":
                    DataGrid.ItemsSource = context.Heads.Local.ToObservableCollection();
                    break;
                case "Lectures":
                    DataGrid.ItemsSource = context.Lectures.Local.ToObservableCollection();
                    break;
                case "LectureRooms":
                    DataGrid.ItemsSource = context.LectureRooms.Local.ToObservableCollection();
                    break;
            }

        }

        public void UpdateButtonClick(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
    }
}
