using BusinessObjects;
using DataAccessLayer;
using Services;
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
        private readonly ICourseService courseService; 
        public CoursesManage()
        {
            InitializeComponent();
            _context = new CourseManagementDbContext();
            courseService = new CourseService();
            LoadComboBoxes();
        }
        private void LoadComboBoxes()
        {
            var course = courseService.GetCourses();
            var codes = course.Select(c => c.Code).Distinct().ToList();
            var titles = course.Select(t => t.Title).Distinct().ToList();
            var credits = courseService.GetCredits().OrderBy(c => c).ToList();

            cbFilterCode.ItemsSource = codes;
            cbFilterTitle.ItemsSource = titles;
            cboFilterCredits.ItemsSource = credits;
        }

        private void btnLoadCourses_Click(object sender, RoutedEventArgs e)
        {
            dgCourses.ItemsSource = courseService.GetCourses();
            LoadComboBoxes ();
        }
        private void btnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddCourse();
            if (dialog.ShowDialog() == true)
            {
                courseService.CreateCourse(dialog.NewCourse);
                dgCourses.ItemsSource = courseService.GetCourses();
                LoadComboBoxes();    
            }
        }

        private void btnUpdateCourse_Click(object sender, RoutedEventArgs e)
        {
            if(dgCourses.SelectedItem is Course selectedCourse)
            {
                var dialog = new EditCourse(selectedCourse);
                if(dialog.ShowDialog() == true)
                {
                    courseService.UpdateCourse(dialog.ExistingCourse);
                    dgCourses.ItemsSource = courseService.GetCourses();
                    LoadComboBoxes();
                }
            }
            else
            {
                MessageBox.Show("Please select a course to update.","Information",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void btnDeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            if (dgCourses.SelectedItem is Course selectedCourse)
            {
                var result = MessageBox.Show($"Are you sure want to delete the course '{selectedCourse.Title}'?", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    courseService.DeleteCourse(selectedCourse);
                    dgCourses.ItemsSource = courseService.GetCourses();
                    LoadComboBoxes() ;
                }
            }
            else
            {
                MessageBox.Show("Please select a course to update.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void FilterCourses(object sender, SelectionChangedEventArgs e)
        {
            string codeFilter = cbFilterCode.SelectedItem?.ToString().ToLower();
            string titleFilter = cbFilterTitle.SelectedItem?.ToString().ToLower();
            int? creditFilter = cboFilterCredits.SelectedItem as int?;
            var filteredCourses = courseService.GetCourses()
                .Where(c => (string.IsNullOrEmpty(codeFilter) || c.Code.ToLower().Contains(codeFilter)) &&
                            (string.IsNullOrEmpty(titleFilter) || c.Title.ToLower().Contains(titleFilter)) &&
                            (!creditFilter.HasValue || c.Credits == creditFilter))
                .ToList();

            dgCourses.ItemsSource = filteredCourses;
        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            cbFilterCode.SelectedItem = null;
            cbFilterTitle.SelectedItem = null;
            cboFilterCredits.SelectedItem = null;
            dgCourses.ItemsSource = courseService.GetCourses();
        }
        private void btnCourses_Click(object sender, RoutedEventArgs e)
        {
            dgCourses.ItemsSource = courseService.GetCourses();
            LoadComboBoxes();
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

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
