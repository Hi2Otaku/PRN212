﻿using BusinessObjects;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CourseManagement.SemeterManagement
{
    /// <summary>
    /// Interaction logic for SemesterManagement.xaml
    /// </summary>
    public partial class SemesterManagement : Window
    {
        private readonly ISemesterSevice _isemester;

        public SemesterManagement()
        {
            InitializeComponent();
            _isemester = new SemesterSevice();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int year = -1;
            DateOnly? startDate = _isemester.GetMixDate(year);
            DateOnly? endDate = _isemester.GetMaxDate(year);
            StartDate.SelectedDate = startDate.Value.ToDateTime(TimeOnly.MinValue);
            EndDate.SelectedDate = endDate.Value.ToDateTime(TimeOnly.MinValue);
            Load_Year();
            Load_Semester(year, startDate, endDate);
        }
        private void Load_Year()
        {
            try
            {
                var year = _isemester.Load_Year();
                YearComboBox.ItemsSource = year;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Load_Semester(int year, DateOnly? startDate, DateOnly? endDate)
        {
            try
            {
                var semesters = _isemester.Load_Semester(year, startDate, endDate);
                semesterData.ItemsSource = semesters;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            int year = -1;
            DateOnly? startDate = _isemester.GetMixDate(year);
            DateOnly? endDate = _isemester.GetMaxDate(year);
            StartDate.SelectedDate = startDate.Value.ToDateTime(TimeOnly.MinValue);
            EndDate.SelectedDate = endDate.Value.ToDateTime(TimeOnly.MinValue);
            Load_Year();
            Load_Semester(year, startDate, endDate);
            YearComboBox.Text = "";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddSemester();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    _isemester.Add_Semester(dialog._newSemester);
                    int year = -1;
                    DateOnly? startDate = _isemester.GetMixDate(year);
                    DateOnly? endDate = _isemester.GetMaxDate(year);
                    StartDate.SelectedDate = startDate.Value.ToDateTime(TimeOnly.MinValue);
                    EndDate.SelectedDate = endDate.Value.ToDateTime(TimeOnly.MinValue);
                    Load_Year();
                    Load_Semester(year, startDate, endDate);
                    MessageBox.Show("Add new Semester Sucess", "Sucess", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (semesterData.SelectedItem is Semester semester)
                {
                    var dialog = new EditSemester(semester);
                    if (dialog.ShowDialog() == true)
                    {
                        _isemester.Update_Semester(dialog._newSemester);
                        int year = -1;
                        DateOnly? startDate = _isemester.GetMixDate(year);
                        DateOnly? endDate = _isemester.GetMaxDate(year);
                        StartDate.SelectedDate = startDate.Value.ToDateTime(TimeOnly.MinValue);
                        EndDate.SelectedDate = endDate.Value.ToDateTime(TimeOnly.MinValue);
                        Load_Year();
                        Load_Semester(year, startDate, endDate);
                        MessageBox.Show("Edit Semester Sucess", "Sucess", MessageBoxButton.OK);

                    }
                }
                else
                {
                    MessageBox.Show("Please select a Semester to edit", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void Filter(object sender, RoutedEventArgs e)
        {
            var selectYear = YearComboBox.SelectedItem;
            DateTime? selectStartDate = StartDate.SelectedDate;
            DateTime? selectEndDate = EndDate.SelectedDate;
            int year = -1;
            if (selectYear != null && int.TryParse(selectYear.ToString(), out year)) ;

            DateOnly? startDate = null;
            DateOnly? endDate = null;
            if (selectStartDate.HasValue)
            {
                startDate = DateOnly.FromDateTime(selectStartDate.Value);
            }
            if (selectEndDate.HasValue)
            {
                endDate = DateOnly.FromDateTime(selectEndDate.Value);
            }

            Load_Semester(year, startDate, endDate);
        }

        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectYear = YearComboBox.SelectedItem;
            int year = -1;
            if (selectYear != null && int.TryParse(selectYear.ToString(), out year)) ;
            StartDate.DisplayDateStart = _isemester.GetMixDate(year).Value.ToDateTime(TimeOnly.MinValue);
            if (EndDate.SelectedDate.HasValue)
            {
                StartDate.DisplayDateEnd = EndDate.SelectedDate.Value;
            }
            else
            {
                StartDate.DisplayDateEnd = _isemester.GetMaxDate(year).Value.ToDateTime(TimeOnly.MinValue);
            }
            Filter(sender, e);
        }

        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectYear = YearComboBox.SelectedItem;
            int year = -1;
            if (selectYear != null && int.TryParse(selectYear.ToString(), out year)) ;
            EndDate.DisplayDateStart = _isemester.GetMixDate(year).Value.ToDateTime(TimeOnly.MinValue);
            if (StartDate.SelectedDate.HasValue)
            {
                EndDate.DisplayDateEnd = StartDate.SelectedDate.Value;
            }
            else
            {
                EndDate.DisplayDateEnd = _isemester.GetMaxDate(year).Value.ToDateTime(TimeOnly.MinValue);
            }

            Filter(sender, e);

        }

        private void YearComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectYear = YearComboBox.SelectedItem;
            int year = -1;
            if (selectYear != null && int.TryParse(selectYear.ToString(), out year)) ;
            DateOnly? startDate = _isemester.GetMixDate(year);
            DateOnly? endDate = _isemester.GetMaxDate(year);
            StartDate.SelectedDate = startDate.Value.ToDateTime(TimeOnly.MinValue);
            EndDate.SelectedDate = endDate.Value.ToDateTime(TimeOnly.MinValue);
            Filter(sender, e);

        }
    }
}