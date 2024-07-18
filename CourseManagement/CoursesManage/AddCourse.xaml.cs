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
    /// Interaction logic for AddCourse.xaml
    /// </summary>
    public partial class AddCourse : Window
    {
        public Course NewCourse { get; private set; }
        public AddCourse()
        {
            InitializeComponent();
            NewCourse = new Course();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewCourse.Code = txtCourseCode.Text;
            NewCourse.Title = txtCourseTitle.Text;
            if (byte.TryParse(txtCredits.Text, out byte credits))
            {
                NewCourse.Credits = credits;
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
