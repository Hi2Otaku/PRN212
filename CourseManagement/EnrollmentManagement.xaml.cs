﻿using BusinessObjects;
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
    /// Interaction logic for EnrollmentManagement.xaml
    /// </summary>
    public partial class EnrollmentManagement : Window
    {
        public EnrollmentManagement()
        {
            InitializeComponent();
            loadWindow();
        }

        public void loadWindow()
        {
            CourseManagementDbContext db = new CourseManagementDbContext();
            var enrollments = db.Enrollments
                .Include(enr => enr.Course)
                .Include(enr => enr.Student)
                .Include(enr => enr.Semester)
                .ToList();
            List<dynamic> dynamics = new List<dynamic>();
            foreach (var enrollment in enrollments)
            {
                dynamics.Add(new { EnrollmentId = enrollment.EnrollmentId, Name = enrollment.Student.Name, CourseCode = enrollment.Course.Code, SemesterCode = enrollment.Semester.Code });
            }
            dgData.ItemsSource = dynamics;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
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
                    var enrollments = db.Enrollments
                        .Include(enr => enr.Course)
                        .Include(enr => enr.Student)
                        .Include(enr => enr.Semester)
                        .ToList();
                    foreach (Enrollment enrollment in enrollments)
                    {
                        if (enrollment.EnrollmentId == Int32.Parse(id))
                        {
                            txtEnrollmentID.Text = enrollment.EnrollmentId.ToString();
                            txtCourseName.Text = enrollment.Course.Code;
                            txtStudentName.Text = enrollment.Student.Name;
                            txtSemester.Text = enrollment.Semester.Code;
                        }
                    }                    
                }
            }
        }
    }
}