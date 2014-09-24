
﻿using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Interfaces;
using KeeperRichClient.Modules.Benefits.Models;
using KeeperRichClient.Modules.Benefits.Notifications;
using KeeperRichClient.Modules.Employees.Models;
using KeeperRichClient.Modules.Employees.Services;

using Microsoft.Practices.Prism.Commands; //for DelegateCommands; but not used as is unable to raise automatically CanExecuteChanged event
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm; // for BindableBase
using Microsoft.Practices.Prism.PubSubEvents; // for EventAggregation

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using System.Windows.Forms;




namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public class LanguageCourseViewModel : BindableBase, ILanguageCourseViewModel
    {
        public LanguageCourseViewModel()
        {
            ApplicationService.Instance.EventAggregator.GetEvent<EmployeeSelectedEvent>().Subscribe(this.employeeSelected, true);
            this.dataContext = new DbContext();
            this.InstructorSelectionRequest = new InteractionRequest<LanguageCourseInstructorSelect>();
            this.RaiseAttachInstructorCommand = new RelayCommand(action => this.raiseNotification(),
                                                                 predicate => IsInEdit);
            this.RaiseRemoveInstructorCommand = new RelayCommand(action => this.removeInstructorFromCourse(),
                                                                 predicate => IsInEdit);

            this.NewCourseCommand = new RelayCommand(action => this.newCourseCommand(), predicate => ActiveEmployee.Employee != null &&
                                                                                                     this.IsInEdit == false &&
                                                                                                     (ActiveCourse == null ||
                                                                                                     CourseEndDate != null && 
                                                                                                     CourseEndDate <= DateTime.Today)
                                                    );

            this.CancelCommand = new RelayCommand(action => cancelCommand(), predicate => IsInEdit);

            this.ChangeToEditMode = new RelayCommand(action => { IsInEdit = true;}, predicate => IsInEdit == false && ActiveCourse !=null);

            this.SaveCommand = new RelayCommand(action => { IsInEdit = false;},    predicate => IsInEdit == true);
        }

        private void cancelCommand()
        {
            ActiveCourse = prevLangCourse;
            goToReadMode();
            OnPropertyChanged(string.Empty);

        }

        public ICommand SaveCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public ICommand ChangeToEditMode
        {
            get;
            private set;
        }


        bool isNewCourse;
        public bool IsNewCourse 
        { 
            get {return isNewCourse;} 
            set 
            {
                if (isNewCourse != value) isNewCourse = value;
                OnPropertyChanged(()=>this.IsNewCourse);
            }
        }


        bool isInEdit;
        public bool IsInEdit
        {
            get {return isInEdit;}
            private set {isInEdit = value;OnPropertyChanged(()=>this.IsInEdit);}
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

        public ICommand NewCourseCommand
        {
            get;
            private set;
        }

        public InteractionRequest<LanguageCourseInstructorSelect> InstructorSelectionRequest { get; private set; }

        //DateTime? courseStartDate;
        public DateTime? CourseStartDate
        {
            get
            {
                if (this.ActiveCourse != null && this.ActiveCourse.StartDate.Ticks != 0) // check for datetime default initialization value,
                    return this.ActiveCourse.StartDate;
                else
                    return null;
            }
            set { this.ActiveCourse.StartDate = (DateTime)value;OnPropertyChanged("CourseStartDate"); }
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
            set 
            {
                if (System.Windows.MessageBox.Show("Do you really want to close language course?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.activeCourse.EndDate = (DateTime)value;
                    OnPropertyChanged(() => this.CourseEndDate); 
                }
                else
                {
                    //
                }
                    
            }
        }

        


        //EditExisting
        //EditNew


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
                if (ActiveCourse != null && ActiveCourse.LanguageCourse != null)
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

        public ObservableCollection<LanguageCourse> LanguageCourses
        {
            get { return (this.dataContext.LanguageCourses).ToObservableCollection(); }
        }

        private void newCourseCommand()
        {

            prevLangCourse = ActiveCourse;
            activeCourse = new LanguageCoursesToEmployee(); 
            this.IsInEdit = true; this.IsNewCourse = true;
            OnPropertyChanged(string.Empty);            
        }

        private void employeeSelected(GetEmployeesResult argEmployee)
        {

            goToReadMode();

            ActiveCourse = dataContext.LanguageCoursesToEmployees.FirstOrDefault(course => course.EmployeeID == argEmployee.EmployeeID &&
                                                                                               course.TakingDate == null);            
            OnPropertyChanged(string.Empty);
           

        }


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
                    System.Windows.MessageBox.Show(e.ToString());
                }
            }
        }

        private LanguageCoursesToEmployee prevLangCourse { get; set; }

        private void goToReadMode()
        {
            IsInEdit = false;
            IsNewCourse = false;
        }

        private class NewLanguageCourse : LanguageCoursesToEmployee
        {
            
        }

    }

}