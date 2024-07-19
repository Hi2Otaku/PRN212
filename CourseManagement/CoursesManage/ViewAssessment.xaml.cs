using BusinessObjects;
using DataAccessLayer;
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
    /// Interaction logic for ViewAssessment.xaml
    /// </summary>
    public partial class ViewAssessment : Window
    {
        private int courseId;
        public ViewAssessment(int courseId)
        {
            InitializeComponent();
            this.courseId = courseId;
            LoadAssessments();
         
        }
        private void LoadAssessments()
        {
            using (var context = new CourseManagementDbContext())
            {
                var assessments = context.Assessments.Where(a => a.CourseId == courseId).ToList();
                dgAssessments.ItemsSource = assessments;
            }
        }

        private void btnAddAssessment_Click(object sender, RoutedEventArgs e)
        {
         
                var addAssessmentWindow = new AddAssessment(courseId);
                addAssessmentWindow.ShowDialog();
                LoadAssessments();
  
        }
        }

}
