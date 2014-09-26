
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
using System.Data;
using System.ComponentModel;



namespace KeeperRichClient.Modules.Benefits.ViewModels
{

    public class LanguageCourseViewModel : BindableBase, ILanguageCourseViewModel
    {

        #region Construction
        public LanguageCourseViewModel()
        {
            ApplicationService.Instance.EventAggregator.GetEvent<EmployeeSelectedEvent>().Subscribe(this.employeeSelected, true);
            this.dataContext = new DbContext();
            this.InstructorSelectionRequest = new InteractionRequest<LanguageCourseInstructorSelect>();

            this.AddInstructorCommand = new RelayCommand(action => this.raiseNotification(), predicate => IsInEdit);

            this.RemoveInstructorCommand = new RelayCommand(action => this.removeInstructorFromCourse(), predicate => IsInEdit && isAnyInstructor);

            this.NewCourseCommand = new RelayCommand(action => this.newCourseCommand(), predicate => ActiveEmployee.Employee != null &&
                                                                                                     this.IsInEdit == false &&
                                                                                                     (ActiveCourse == null ||
                                                                                                     CourseEndDate != null &&
                                                                                                     CourseEndDate <= DateTime.Today));


            this.CancelCommand = new RelayCommand(action => cancelCommand(), predicate => IsInEdit);

            this.ChangeToEditMode = new RelayCommand(action => changeToEditMode(), predicate => IsInEdit == false && ActiveCourse != null);

            this.SaveCommand = new RelayCommand(action => saveCommand(), predicate => IsInEdit == true && isValidToSave());
        }
        #endregion

        #region Commands
            public ICommand SaveCommand { get; private set; }
        
            public ICommand CancelCommand { get; private set; }

            public ICommand ChangeToEditMode { get; private set; }
        
            public ICommand AddInstructorCommand{ get;private set;}
        
            public ICommand RemoveInstructorCommand{ get;private set;}
        
            public ICommand NewCourseCommand{ get;private set;}
        #endregion
            
        #region Interface
            public bool IsNewCourse
            {
                get { return isNewCourse; }
                set
                {
                    if (isNewCourse != value) isNewCourse = value;
                    OnPropertyChanged(() => this.IsNewCourse);
                }
            }

            public bool IsInEdit
            {
                get { return isInEdit; }
                private set { isInEdit = value; OnPropertyChanged(() => this.IsInEdit); }
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

            public InteractionRequest<LanguageCourseInstructorSelect> InstructorSelectionRequest { get; private set; }

            public DateTime? CourseStartDate
            {
                get
                {
                    if (this.ActiveCourse != null && this.ActiveCourse.StartDate.Ticks != 0) // check for datetime default initialization value,
                        return this.ActiveCourse.StartDate;
                    else
                        return null;
                }
                set
                {
                    this.ActiveCourse.StartDate = (DateTime)value;



                    OnPropertyChanged("CourseStartDate");
                }
            }

            public DateTime? CourseEndDate
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
                    //if (System.Windows.MessageBox.Show("Do you really want to close language course?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        this.activeCourse.EndDate = (DateTime)value;
                        OnPropertyChanged(() => this.CourseEndDate);
                    }
                    //else
                    {
                        //
                    }

                }
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
        
            public ObservableCollection<LanguageCourseInstructor> Instructors
            {
                get
                {
                    if (activeCourse != null)
                    {
                        if (IsNewCourse)
                        {
                            return newCourseInstructors;
                        }
                        else
                        {
                            return (dataContext.LanguageCourseInstructors.Join(dataContext.InstructorsToLanguageCourses,
                                                                                instructor => instructor.InstructorId,
                                                                                courseInstructor => courseInstructor.LanguageCourseInstructorId,
                                                                                (instructor, courseInstructor) => new { instructor, courseInstructor })
                                                                                                                    .Where(o => o.courseInstructor.LanguageCourseToEmpId == activeCourse.Id &&
                                                                                                                                o.courseInstructor.InstructorTakingDate == null)
                                                                                                                    .Select(o => o.instructor)).ToObservableCollection();
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                set
                {

                }
            }

            public ObservableCollection<LanguageCourse> LanguageCourses
            {
                get { return (this.dataContext.LanguageCourses).ToObservableCollection(); }
            }
        #endregion

        #region Implementation

            private void newCourseCommand()
        {
            prevLangCourse = ActiveCourse;
            ActiveCourse = new LanguageCoursesToEmployee();
            newCourseInstructors = new ObservableCollection<LanguageCourseInstructor>();

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

            private DbContext dataContext;

            private LanguageCoursesToEmployee activeCourse;

            private LanguageCourseInstructor selectedInstructor;

            private void raiseNotification()
            {
                // 1st method to retrieve available instructors, error
                //var excludeInstructors = new HashSet<int>(this.LanguageCourseInstructors.Select(x => x.InstructorId));
                //var freeInstructors = dataContext.LanguageCourseInstructors.Where(x => !excludeInstructors.Contains(x.InstructorId)).ToObservableCollection();

                // 2nd method
                var allInstructors = dataContext.LanguageCourseInstructors.ToList();
                var freeInstructors = allInstructors.Except(this.Instructors).ToList();


                LanguageCourseInstructorSelect notification = new LanguageCourseInstructorSelect(freeInstructors);
                notification.Title = "Available instructors";

                this.InstructorSelectionRequest.Raise(notification,
                                                returned =>
                                                {
                                                    if (returned != null && returned.SelectedInstructor != null && returned.Confirmed)
                                                    {
                                                        try
                                                        {
                                                            if (IsNewCourse)
                                                            {
                                                                this.newCourseInstructors.Add(returned.SelectedInstructor);
                                                            }
                                                            else
                                                            {
                                                                this.dataContext.spAddInstructorToCourse(this.ActiveCourse.Id,
                                                                                                         returned.SelectedInstructor.InstructorId);
                                                            }
                                                            OnPropertyChanged(() => this.Instructors);
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
                        if (IsNewCourse)
                            newCourseInstructors.Remove(this.selectedInstructor);
                        else
                            dataContext.spRemoveInstructorFromCourse(this.ActiveCourse.Id,
                                                                     this.SelectedInstructor.InstructorId);


                    }
                    catch (Exception e)
                    {
                        System.Windows.MessageBox.Show(e.ToString());
                    }

                    OnPropertyChanged(() => this.Instructors);

                }
            }

            private bool isAnyInstructor
            {
                get
                {
                    if (IsNewCourse)
                        return (newCourseInstructors.Count > 0);
                    else
                        return (Instructors.Count > 0);
                }


            } //validate RemoveInstructorCommand

            private bool isValidToSave()
            {
                if (IsNewCourse)
                {
                    return ActiveCourse.LanguageCourse != null &&
                            ActiveCourse.StartDate != null &&
                            ActiveCourse.StartDate.Ticks != 0 &&
                            Instructors.Count > 0;
                }
                else
                {
                    return true;
                }
            }

            private void changeToEditMode()
            {
                prevLangCourse = ActiveCourse.Clone();
                this.IsInEdit = true;
            }

            private void saveCommand()
            {
                if (IsNewCourse)
                {
                    ActiveCourse.Id = dataContext.spAddNewLanguageCourse(ActiveCourse.LanguageCourseID,
                                                                    ActiveEmployee.Employee.EmployeeID,
                                                                    ActiveCourse.StartDate,
                                                                    ActiveCourse.EndDate);
                    foreach (LanguageCourseInstructor lci in newCourseInstructors)
                        dataContext.spAddInstructorToCourse(ActiveCourse.Id, lci.InstructorId);



                }

                else if (IsInEdit)
                {
                    
                    if (prevLangCourse.EndDate != ActiveCourse.EndDate)
                    {
                        dataContext.spModifyLangCourseEndDate(ActiveCourse.Id, ActiveCourse.EndDate);

                    }




                }

                goToReadMode();
                OnPropertyChanged(string.Empty);

            }

            private ObservableCollection<LanguageCourseInstructor> newCourseInstructors;

            private bool isNewCourse;

            private bool isInEdit;

            private void cancelCommand()
            {
                ActiveCourse = prevLangCourse;
                goToReadMode();
                OnPropertyChanged(string.Empty);
            }

            private LanguageCoursesToEmployee prevLangCourse { get; set; }

            private void goToReadMode()
            {
                IsInEdit = false;
                IsNewCourse = false;
            }

        #endregion
    }
}
 
 
 



    

