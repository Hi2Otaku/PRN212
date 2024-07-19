﻿using BusinessObjects;
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
            LoadCourses();
        }
        private void LoadComboBoxes()
        {
            var course = _courseDAO.GetCourses();
            var titles = course.Select(t => t.Title).Distinct().ToList();
            var credits = _courseDAO.GetCredits().OrderBy(c => c).ToList();

            cbFilterTitle.ItemsSource = titles;
            cboFilterCredits.ItemsSource = credits;
        }

        private void LoadCourses()
        {
            dgCourses.ItemsSource = _courseDAO.GetCourses();
            LoadComboBoxes();
        }
        private void btnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddCourse();
            if (dialog.ShowDialog() == true)
            {
                _courseDAO.CreateCourse(dialog.NewCourse);
                dgCourses.ItemsSource = _courseDAO.GetCourses();
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
                    _courseDAO.UpdateCourse(dialog.ExistingCourse);
                    dgCourses.ItemsSource = _courseDAO.GetCourses();
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
                    _courseDAO.DeleteCourse(selectedCourse);
                    dgCourses.ItemsSource = _courseDAO.GetCourses();
                    LoadComboBoxes();
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
            var filteredCourses = _courseDAO.GetCourses()
                .Where(c => (string.IsNullOrEmpty(titleFilter) || c.Title.ToLower().Contains(titleFilter)) &&
                            (!creditFilter.HasValue || c.Credits == creditFilter))
                .ToList();

            dgCourses.ItemsSource = filteredCourses;
        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            cbFilterTitle.SelectedItem = null;
            cboFilterCredits.SelectedItem = null;
            dgCourses.ItemsSource = _courseDAO.GetCourses();
        }
        private void btnCourses_Click(object sender, RoutedEventArgs e)
        {
            dgCourses.ItemsSource = _courseDAO.GetCourses();
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
