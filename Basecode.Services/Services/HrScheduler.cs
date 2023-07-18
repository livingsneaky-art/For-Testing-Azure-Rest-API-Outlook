using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Services.Interfaces;
using Hangfire;

namespace Basecode.Services.Services
{
    public class HRScheduler : IHrScheduler
    {
        private readonly IEmailService _emailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService" /> class.
        /// </summary>
        /// <param name="emailService">The Email Service</param>
        public HRScheduler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public void ScheduleInterview(string interviewerName, string interviewerEmail, string applicantName,
                                      string applicantEmail, DateTime interviewDate, string interviewLocation)
        {
            // Schedule the email notification using Hangfire
            BackgroundJob.Schedule(() => SendInterviewNotification(interviewerName, interviewerEmail, applicantName,
                                                                   applicantEmail, interviewDate, interviewLocation),
                                                                   TimeSpan.FromSeconds(5)); // Delay of 5 seconds
        }

        public async Task SendInterviewNotification(string interviewerName, string interviewerEmail, string applicantName,
                                              string applicantEmail, DateTime interviewDate, string interviewLocation)
        {

            
            // Here, you can use your email sending logic to send notifications to both the interviewer and the applicant.
            // For simplicity, we will just print the messages to the console.

            string subject = $"Interview Schedule for {applicantName}";
            string message = $"Hello {interviewerName},\n\nYou have an interview scheduled with {applicantName} " +
                             $"on {interviewDate} at {interviewLocation}.\n\nBest Regards,\nYour HR Team";

            await _emailService.SendEmail(interviewerEmail, subject, message);

            // Simulate sending emails (replace with actual email sending logic)
            Console.WriteLine($"Sending email to {interviewerEmail}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");

            Console.WriteLine($"Sending email to {applicantEmail}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");

            

        }
    }
}
