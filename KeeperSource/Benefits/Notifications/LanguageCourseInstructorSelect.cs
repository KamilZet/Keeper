
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KeeperRichClient.Modules.Benefits.Models;

namespace KeeperRichClient.Modules.Benefits.Notifications
{
    public class LanguageCourseInstructorSelect : Confirmation
    {
        public LanguageCourseInstructorSelect()
        {
            this.Instructors = new List<LanguageCourseInstructor>();
            this.SelectedInstructor = null;
        }

        public IEnumerable<LanguageCourseInstructor> Instructors { get; private set; }

        public string SelectedInstructor { get; private set; }
    }
}
