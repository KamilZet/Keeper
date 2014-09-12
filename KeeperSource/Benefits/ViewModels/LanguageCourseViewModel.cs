using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Employees.Models;
using KeeperRichClient.Modules.Employees.Services;
using KeeperRichClient.Modules.Benefits.Models;
using KeeperRichClient.Modules.Benefits.Interfaces;

using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Collections.ObjectModel;
using System.Linq;


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
            get { return activeCourse.LanguageCourse.LanguageCourseName; }
        }

        public ObservableCollection<LanguageCourseInstructor> LanguageCourseInstructors
        {
            get
            {
                 return (dataContext.LanguageCourseInstructors.Join(dataContext.InstructorsToLanguageCourses,
                                                                    instructor => instructor.InstructorId,
                                                                    courseInstructor => courseInstructor.LanguageCourseInstructorId,
                                                                    (instructor, courseInstructor) => instructor)).ToObservableCollection();
            }
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

