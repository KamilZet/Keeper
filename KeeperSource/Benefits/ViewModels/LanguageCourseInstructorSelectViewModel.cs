
using KeeperRichClient.Modules.Benefits.Notifications;
using KeeperRichClient.Modules.Benefits.Models;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Windows.Input;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public class LanguageCourseInstructorSelectViewModel : BindableBase, IInteractionRequestAware
    {

        public LanguageCourseInstructorSelectViewModel()
        {
            this.SelectInstructorCommand = new DelegateCommand(this.AcceptSelectedItem);
            this.CancelCommand = new DelegateCommand(this.CancelInteraction);
        }

        public Action FinishInteraction { get; set; }

        public INotification Notification 
        {
            get
            {
                return this.notification;
            }
            set
            {
                if (value is LanguageCourseInstructorSelect)
                {
                    this.notification = value as LanguageCourseInstructorSelect;
                    this.OnPropertyChanged(() => this.Notification);
                }
            }
        }

        public LanguageCourseInstructor SelectedInstructor { get; set; }

        public ICommand SelectInstructorCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public void AcceptSelectedItem()
        {
            if (this.notification != null)
            {
                this.notification.SelectedInstructor = this.SelectedInstructor;
                this.notification.Confirmed = true;
            }

            this.FinishInteraction();
        }

        public void CancelInteraction()
        {
            if (this.notification != null) this.notification.Confirmed = false;

            this.FinishInteraction();
        }

        private LanguageCourseInstructorSelect notification;
    }
}
