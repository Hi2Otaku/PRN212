using BusinessObjects;
using Microsoft.EntityFrameworkCore;
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

namespace CourseManagement
{
    /// <summary>
    /// Interaction logic for EditMark.xaml
    /// </summary>
    public partial class EditMark : Window
    {
        public int enrollmentID;
        public EditMark()
        {
            InitializeComponent();
        }

        public EditMark(int enrollID)
        {
            InitializeComponent();
            enrollmentID = enrollID;
            lblTitle.Content = $"Edit Mark on Enrollment {enrollmentID}";
            loadWindow();
        }

        public void loadWindow()
        {
            dgData.ItemsSource = null;
            CourseManagementDbContext db = new CourseManagementDbContext();
            var marks = db.Marks
                .Include(m => m.Assessment)
                .Include(m => m.Enrollment)
                .Where(m => m.EnrollmentId == enrollmentID)
                .ToList();
            dgData.ItemsSource = marks;
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid.ItemsSource != null)
            {
                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex) as DataGridRow;
                DataGridCell cell = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;

                string id = ((TextBlock)cell.Content).Text;
                if (!id.Equals(""))
                {
                    CourseManagementDbContext db = new CourseManagementDbContext();
                    var marks = db.Marks
                        .Include(m => m.Assessment)
                        .Include(m => m.Enrollment)
                        .Where(m => m.EnrollmentId == enrollmentID)
                        .ToList();                    
                    foreach (var mark in marks)
                    {
                        if (mark.Assessment.Name.Equals(id))
                        {
                            txtAssess.Text = mark.Assessment.Name;
                            txtMark.Text = mark.Mark1.ToString();
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!txtAssess.Text.Equals("") && !txtMark.Text.Equals(""))
            {
                try
                {
                    decimal assessMark = decimal.Parse(txtMark.Text);
                    if (0 > assessMark || 10 < assessMark)
                    {
                        MessageBox.Show("Invalid Input!");
                        return;
                    }
                    CourseManagementDbContext db = new CourseManagementDbContext();
                    var marks = db.Marks
                        .Include(m => m.Assessment)
                        .Include(m => m.Enrollment)
                        .Where(m => m.EnrollmentId == enrollmentID)
                        .ToList();
                    int assessmentId = 0;
                    foreach (var markz in marks)
                    {
                        if (markz.Assessment.Name.Equals(txtAssess.Text))
                        {
                            assessmentId = markz.AssessmentId;
                        }
                    }
                    Mark mark = new Mark();
                    mark.Mark1 = assessMark;
                    mark.EnrollmentId = enrollmentID;
                    mark.AssessmentId = assessmentId;
                    CourseManagementDbContext db2 = new CourseManagementDbContext();
                    db2.Marks.Update(mark);
                    db2.SaveChanges();                    
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                loadWindow();
            } else
            {
                MessageBox.Show("Invalid input!");
            }
        }
    }
}
