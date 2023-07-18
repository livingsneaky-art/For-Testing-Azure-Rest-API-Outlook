using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Interfaces
{
    public interface IHrScheduler
    {
        void ScheduleInterview(string interviewerName, string interviewerEmail, string applicantName,
                               string applicantEmail, DateTime interviewDate, string interviewLocation);
    }

}
