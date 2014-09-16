﻿using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Employees.Models;
using KeeperRichClient.Modules.Employees.Services;
using KeeperRichClient.Modules.Benefits.Models;
using KeeperRichClient.Modules.Benefits.Interfaces;

using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Windows.Input;


namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public class LanguageCourseViewModel : BindableBase, ILanguageCourseViewModel
    {   
        public LanguageCourseViewModel()
        {
            ApplicationService.Instance.EventAggregator.GetEvent<EmployeeSelectedEvent>().Subscribe(this.employeeSelected,true);
            dataContext = new DbContext();
            eventAggr = ApplicationService.Instance.EventAggregator;
            eventAggr.GetEvent<EmployeeSelectedEvent>().Subscribe(this.employeeSelected, true);
        }

        public void AddInstructorToCourse(LanguageCourseInstructor argInstructor)
        {

        }

        public DateTime? CourseStartDate
        {
            get
            {
                if (this.activeCourse != null)
                    return this.activeCourse.StartDate;
                else
                    return null;
            }
            set { this.activeCourse.StartDate = (DateTime)value; }
        }

        public DateTime? CourseEndDate
        // co najmniej jeden miesiąc nauki, licząc od zaplanowanej daty rozpoczęcia
        {
            get
            {
                if (this.activeCourse != null)
                    return this.activeCourse.EndDate;
                else
                    return null;
            }
            set { this.activeCourse.EndDate = (DateTime)value; }
        }

        public void RemoveInstructorFromCourse(LanguageCourseInstructor argInstructor)
        {

        }

        public void CloseCourse()
        {

        }

        public void SetNewCourse()
        {

        }

        public string LanguageCourseName
        {
            get 
            {
                if (activeCourse != null)
                    return activeCourse.LanguageCourse.LanguageCourseName;
                else
                    return string.Empty;
            }
        }

        public ObservableCollection<LanguageCourseInstructor> LanguageCourseInstructors
        {
            get
            {
                if (activeCourse != null)
                    return (dataContext.LanguageCourseInstructors.Join(dataContext.InstructorsToLanguageCourses,
                                                                        instructor => instructor.InstructorId,
                                                                        courseInstructor => courseInstructor.LanguageCourseInstructorId,
                                                                        (instructor, courseInstructor) => new { instructor, courseInstructor })
                                                                                                            .Where(o => o.courseInstructor.LanguageCourseToEmpId == activeCourse.Id)
                                                                                                            .Select(o => o.instructor)).ToObservableCollection();
                else
                    return null;

            }
        }

        public ICommand NewCourseCommand
        {
            get 
            {
                if (activeCourse != null)
                    return new RelayCommand(action => newCourseCommand(), predicate => activeCourse.EndDate != null && activeCourse.EndDate < DateTime.Today);
                else
                    return null;
            }
        }

        void newCourseCommand()
        {
            activeCourse = new LanguageCoursesToEmployee();
            OnPropertyChanged(string.Empty);
        }

        void employeeSelected(GetEmployeesResult argEmployee)
        {
            activeCourse = dataContext.LanguageCoursesToEmployees.FirstOrDefault(course => course.EmployeeID == argEmployee.EmployeeID &&
                                                                                           course.TakingDate == null);
            OnPropertyChanged(string.Empty);
        }


        IEventAggregator eventAggr;
        DbContext dataContext;
        LanguageCoursesToEmployee activeCourse;

    }

}
