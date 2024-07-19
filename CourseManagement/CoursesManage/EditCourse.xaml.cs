using BusinessObjects;
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

namespace CourseManagement.CoursesManage
{
    /// <summary>
    /// Interaction logic for EditCourse.xaml
    /// </summary>
    public partial class EditCourse : Window
    {

        public Course ExistingCourse { get; private set; }
        public EditCourse(Course course)
        {
            InitializeComponent();
            
            ExistingCourse = course;
            txtCourseId.Text = course.Id.ToString();
            txtCourseCode.Text = course.Code;
            txtCourseTitle.Text = course.Title;
            txtCredits.Text = course.Credits?.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           ExistingCourse.Code = txtCourseCode.Text;
           ExistingCourse.Title = txtCourseTitle.Text;
           if (byte.TryParse(txtCredits.Text, out byte credits))
            {
                ExistingCourse.Credits = credits;
            }
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
