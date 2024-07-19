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
            LoadCourses();
        }
        private void LoadComboBoxes()
        {
<<<<<<< HEAD
            var course = _courseDAO.GetCourses();
=======
            var course = courseService.GetCourses();
            var codes = course.Select(c => c.Code).Distinct().ToList();
>>>>>>> d27ef21b766e89704dfec946bef1eb2ad0da1ff2
            var titles = course.Select(t => t.Title).Distinct().ToList();
            var credits = courseService.GetCredits().OrderBy(c => c).ToList();

            cbFilterTitle.ItemsSource = titles;
            cboFilterCredits.ItemsSource = credits;
        }

        private void LoadCourses()
        {
<<<<<<< HEAD
            dgCourses.ItemsSource = _courseDAO.GetCourses();
            LoadComboBoxes();
=======
            dgCourses.ItemsSource = courseService.GetCourses();
            LoadComboBoxes ();
>>>>>>> d27ef21b766e89704dfec946bef1eb2ad0da1ff2
        }
        private void btnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddCourse();
            if (dialog.ShowDialog() == true)
            {
<<<<<<< HEAD
                _courseDAO.CreateCourse(dialog.NewCourse);
                dgCourses.ItemsSource = _courseDAO.GetCourses();
                LoadComboBoxes();
=======
                courseService.CreateCourse(dialog.NewCourse);
                dgCourses.ItemsSource = courseService.GetCourses();
                LoadComboBoxes();    
>>>>>>> d27ef21b766e89704dfec946bef1eb2ad0da1ff2
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
                var result = MessageBox.Show($"Are you sure you want to delete the course '{selectedCourse.Title}'?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
<<<<<<< HEAD
                    _courseDAO.DeleteCourse(selectedCourse);
                    dgCourses.ItemsSource = _courseDAO.GetCourses();
                    LoadComboBoxes();
=======
                    courseService.DeleteCourse(selectedCourse);
                    dgCourses.ItemsSource = courseService.GetCourses();
                    LoadComboBoxes() ;
>>>>>>> d27ef21b766e89704dfec946bef1eb2ad0da1ff2
                }
            }
              else
            {
                MessageBox.Show("Please select a course to update.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void FilterCourses(object sender, SelectionChangedEventArgs e)
        {
 
            string titleFilter = cbFilterTitle.SelectedItem?.ToString().ToLower();
            int? creditFilter = cboFilterCredits.SelectedItem as int?;
<<<<<<< HEAD
            var filteredCourses = _courseDAO.GetCourses()
                .Where(c => (string.IsNullOrEmpty(titleFilter) || c.Title.ToLower().Contains(titleFilter)) &&
=======
            var filteredCourses = courseService.GetCourses()
                .Where(c => (string.IsNullOrEmpty(codeFilter) || c.Code.ToLower().Contains(codeFilter)) &&
                            (string.IsNullOrEmpty(titleFilter) || c.Title.ToLower().Contains(titleFilter)) &&
>>>>>>> d27ef21b766e89704dfec946bef1eb2ad0da1ff2
                            (!creditFilter.HasValue || c.Credits == creditFilter))
                .ToList();

            dgCourses.ItemsSource = filteredCourses;
        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            cbFilterTitle.SelectedItem = null;
            cboFilterCredits.SelectedItem = null;
            dgCourses.ItemsSource = courseService.GetCourses();
        }
        private void btnCourses_Click(object sender, RoutedEventArgs e)
        {
            dgCourses.ItemsSource = courseService.GetCourses();
            LoadComboBoxes();
        }

        private void btnViewAssessments_Click(object sender, RoutedEventArgs e)
        {

            if (dgCourses.SelectedItem is Course selectedCourse)
            {
                var assessmentsWindow = new ViewAssessment(selectedCourse.Id);
                assessmentsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a course to update.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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

        private void btnEnrollment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
