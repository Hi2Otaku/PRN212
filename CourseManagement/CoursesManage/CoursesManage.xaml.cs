using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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

namespace CourseManagement.CoursesManage
{
    /// <summary>
    /// Interaction logic for CoursesManage.xaml
    /// </summary>
    public partial class CoursesManage : Window
    {
        private readonly CourseManagementDbContext _context;
        private readonly CourseDAO _courseDAO;
        public CoursesManage()
        {
            InitializeComponent();
            _context = new CourseManagementDbContext();
            _courseDAO= new CourseDAO(_context);
            LoadComboBoxes();
        }
        private void LoadComboBoxes()
        {
            var course = _courseDAO.GetCourses();
            var codes = course.Select(c => c.Code).Distinct().ToList();
            var titles = course.Select(t => t.Title).Distinct().ToList();

            cbFilterCode.ItemsSource = codes;
            cbFilterTitle.ItemsSource = titles;
        }

        private void btnLoadCourses_Click(object sender, RoutedEventArgs e)
        {
            dgCourses.ItemsSource = _courseDAO.GetCourses();
            LoadComboBoxes ();
        }

        private void btnCourses_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStudents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDepartments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSemesters_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAssessments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEnrollment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddCourse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateCourse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteCourse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FilterCourses(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {

        }

    
    }
}
