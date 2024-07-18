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
using BusinessObjects;
using DataAccessLayer;
namespace CourseManagement
{
    /// <summary>
    /// Interaction logic for SemesterManagement.xaml
    /// </summary>
    public partial class SemesterManagement : Window
    {
        public SemesterManagement()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           

        }

        private void CodeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void YearComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void Load_Semester()
        {
            SemestersDAO _semesterDao = new SemestersDAO();
            List<Semester> semesters = _semesterDao.Load_Semester(null,-1,null,null);
        }
    }
}
