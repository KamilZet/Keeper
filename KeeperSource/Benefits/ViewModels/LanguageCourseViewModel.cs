
﻿using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Interfaces;
using KeeperRichClient.Modules.Benefits.Models;
using KeeperRichClient.Modules.Benefits.Notifications;
using KeeperRichClient.Modules.Employees.Models;
using KeeperRichClient.Modules.Employees.Services;

using Microsoft.Practices.Prism.Commands; //for DelegateCommands
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm; // for BindableBase
using Microsoft.Practices.Prism.PubSubEvents; // for EventAggregation

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;




namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public class LanguageCourseViewModel : BindableBase, ILanguageCourseViewModel
    {
        public LanguageCourseViewModel()
        {
            ApplicationService.Instance.EventAggregator.GetEvent<EmployeeSelectedEvent>().Subscribe(this.employeeSelected, true);
            dataContext = new DbContext();

            this.InstructorSelectionRequest = new InteractionRequest<LanguageCourseInstructorSelect>();
            this.RaiseAttachInstructorCommand = new DelegateCommand(this.raiseNotification);
            this.RaiseRemoveInstructorCommand = new DelegateCommand(this.removeInstructorFromCourse);
            this.NewCourseCommand = new DelegateCommand(this.newCourseCommand, () => activeCourse.EndDate != null &&
                                                                                     activeCourse.EndDate < DateTime.Today);
        }

        public LanguageCoursesToEmployee ActiveCourse
        {
            get { return activeCourse; }
            set { SetProperty(ref this.activeCourse, value); }
        }

        public LanguageCourseInstructor SelectedInstructor
        {
            get { return selectedInstructor; }
            set { SetProperty(ref this.selectedInstructor, value); }
        }

        public ICommand RaiseAttachInstructorCommand
        {
            get;
            private set;
        }

        public ICommand RaiseRemoveInstructorCommand
        {
            get;
            private set;
        }

        public InteractionRequest<LanguageCourseInstructorSelect> InstructorSelectionRequest { get; private set; }


        public DateTime? CourseStartDate
        {
            get
            {
                if (this.activeCourse != null )
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
                                                                                                            .Where(o => o.courseInstructor.LanguageCourseToEmpId == activeCourse.Id &&
                                                                                                                        o.courseInstructor.InstructorTakingDate == null)
                                                                                                            .Select(o => o.instructor)).ToObservableCollection();
                else
                    return null;
            }            
        }

        public ICommand NewCourseCommand
        {
            get;
            private set;
        }

        private void newCourseCommand()
        {
            activeCourse = new LanguageCoursesToEmployee();
            OnPropertyChanged(string.Empty);
        }

        private void employeeSelected(GetEmployeesResult argEmployee)
        {
            ActiveCourse = dataContext.LanguageCoursesToEmployees.FirstOrDefault(course => course.EmployeeID == argEmployee.EmployeeID &&
                                                                                           course.TakingDate == null);
            OnPropertyChanged(string.Empty);
        }


        IEventAggregator eventAggr;
        DbContext dataContext;

        LanguageCoursesToEmployee activeCourse;
        LanguageCourseInstructor selectedInstructor;

        private void raiseNotification()
        {
            // 1st method to retrieve available instructors, error
            //var excludeInstructors = new HashSet<int>(this.LanguageCourseInstructors.Select(x => x.InstructorId));
            //var freeInstructors = dataContext.LanguageCourseInstructors.Where(x => !excludeInstructors.Contains(x.InstructorId)).ToObservableCollection();

            // 2nd method
            var allInstructors = dataContext.LanguageCourseInstructors.ToList();
            var freeInstructors = allInstructors.Except(this.LanguageCourseInstructors).ToList();


            LanguageCourseInstructorSelect notification = new LanguageCourseInstructorSelect(freeInstructors);
            notification.Title = "Available instructors";
            this.InstructorSelectionRequest.Raise(notification,
                                            returned =>
                                            {
                                                if (returned != null && returned.SelectedInstructor != null && returned.Confirmed)
                                                {
                                                    try
                                                    {
                                                        this.dataContext.spAddInstructorToCourse(this.ActiveCourse.Id,
                                                                                                 returned.SelectedInstructor.InstructorId
                                                                                                );
                                                        OnPropertyChanged(() => this.LanguageCourseInstructors);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        throw new NotImplementedException(e.ToString());
                                                    }
                                                }


                                                else
                                                {

                                                }
                                            });
        }

        private void removeInstructorFromCourse()
        {
            if (this.SelectedInstructor != null)
            {
                try
                {
                    dataContext.spRemoveInstructorFromCourse(this.ActiveCourse.Id,
                                                             this.SelectedInstructor.InstructorId);
                    OnPropertyChanged(() => this.LanguageCourseInstructors);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

    }

}


