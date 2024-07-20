using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddCourse.xaml
    /// </summary>
    public partial class AddCourse : Window
    {
        private readonly CourseManagementDbContext _context;

        public Course NewCourse { get; private set; }

        public AddCourse()
        {
            InitializeComponent();
            _context = new CourseManagementDbContext();
            NewCourse = new Course();
            loadAssessment();
        }

        public void loadAssessment()
        {
            try
            {
                List<string> listType = new List<string>()
                {
                        "lab",
                        "quiz",
                        "assignment",
                        "Practice Exam",
                        "Final Exam",
                        "Class Participation"
                };
                dgData.ItemsSource = listType;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can not load Data!");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            string code = txtCourseCode.Text;
            string title = txtCourseTitle.Text;
            string creditsText = txtCredits.Text;

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(creditsText))
=======
            /*NewCourse.Code = txtCourseCode.Text;
            NewCourse.Title = txtCourseTitle.Text;
            if (byte.TryParse(txtCredits.Text, out byte credits))
>>>>>>> 94a452ed81e8dbbf10229157910f8fc618083d75
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check for whitespace-only entries
            if (code.Trim().Length == 0 || title.Trim().Length == 0)
            {
                MessageBox.Show("Fields cannot be empty or contain only white spaces.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check for special characters in Code and Title
            if (!IsValidCodeOrTitle(code) || !IsValidCodeOrTitle(title))
            {
                MessageBox.Show("Code and Title cannot contain special characters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check for valid number in Credits
            if (!byte.TryParse(creditsText, out byte credits))
            {
                MessageBox.Show("Credits must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check for duplicate Code in the database
            if (_context.Courses.Any(c => c.Code == code))
            {
                MessageBox.Show("The course code already exists in the database.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewCourse.Code = code;
            NewCourse.Title = title;
            NewCourse.Credits = credits;


            MessageBox.Show("Course added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
            Close();*/
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

<<<<<<< HEAD
        private bool IsValidCodeOrTitle(string input)
        {
            // Check for special characters
            Regex regex = new Regex(@"^[a-zA-Z0-9 ]+$");
            return regex.IsMatch(input);
=======
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<string> listType = new List<string>()
                {
                        "lab",
                        "quiz",
                        "assignment",
                        "Practice Exam",
                        "Final Exam",
                        "Class Participation"
                };
                dgData.ItemsSource = listType;
           
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Can not load Data!");
            }
        }
        private void Button_AddAssess(object sender, RoutedEventArgs e)
        {

>>>>>>> 94a452ed81e8dbbf10229157910f8fc618083d75
        }
    }
}
