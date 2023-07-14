﻿using AutoMapper;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Services
{
    public class ApplicationService : ErrorHandling, IApplicationService
    {
        private readonly IApplicationRepository _repository;
        private readonly IJobOpeningService _jobOpeningService;
        private readonly IApplicantService _applicantService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="jobOpeningService">The job opening service.</param>
        /// <param name="applicantService">The applicant service.</param>
        /// <param name="emailService">The Email Service</param>
        public ApplicationService(IApplicationRepository repository, IMapper mapper, IJobOpeningService jobOpeningService, IApplicantService applicantService, IEmailService emailService)
        {
            _repository = repository;
            _jobOpeningService = jobOpeningService;
            _applicantService = applicantService;
            _mapper = mapper;
            _emailService = emailService;
        }

        /// <summary>
        /// Creates the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        public void Create(Application application)
        {
            _repository.CreateApplication(application);
        }

        /// <summary>
        /// Retrieves an application by its ID.
        /// </summary>
        /// <param name="id">The ID of the application to retrieve.</param>
        /// <returns>
        /// The application with the specified ID, or null if not found.
        /// </returns>
        public ApplicationViewModel? GetById(Guid id)
        {
            var application = _repository.GetById(id);

            if (application == null)
            {
                return null;
            }

            var job = _jobOpeningService.GetById(application.JobOpeningId);
            var applicant = _applicantService.GetApplicantById(application.ApplicantId);

            var applicationViewModel = _mapper.Map<ApplicationViewModel>(application);
            applicationViewModel.JobOpeningTitle = job.Title;
            applicationViewModel.ApplicantName = $"{applicant.Firstname} {applicant.Lastname}";

            return applicationViewModel;
        }

        /// <summary>
        /// Updates the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
        public LogContent Update(Application application)
        {
            var existingApplication = _repository.GetById(application.Id);

            LogContent logContent = new LogContent();
            logContent = CheckApplication(existingApplication);

            if (logContent.Result == false)
            {
                existingApplication.Status = application.Status;
                existingApplication.UpdateTime = DateTime.Now;

                _repository.UpdateApplication(existingApplication);
            }

            return logContent;
        }

        /// <summary>
        /// Updates the application status of an applicant in the database and notifies the HR and the applicant via email.
        /// </summary>
        /// <param name="applicantId">The ID of the applicant.</param>
        /// <param name="newStatus">The new status to update.</param>
        /// <param name="msgBody">The body message for email</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateApplicationStatus(int applicantId, string newStatus, string msgBody)
        {
            // Update applicant status in the database
            // ongoing!!!

            // Get applicant details from the database
            Applicant applicant = _applicantService.GetApplicantById(applicantId);

            // Notify HR
            await _emailService.SendEmail("hrautomatesystem@outlook.com", "Applicant Status Update for HR",
            $"Applicant {applicant.Firstname} (ID: {applicant.Id}) has changeds status to {newStatus}.");

            // Notify the applicant
            switch (newStatus)
            {
                case "Success":
                    {
                        var templatePath = Path.Combine("wwwroot", "template", "mailtemplate.html");
                        var templateContent = System.IO.File.ReadAllText(templatePath);
                        var body = templateContent
                            .Replace("{{HEADER_LINK}}", "https://zimmergren.net")
                            .Replace("{{HEADER_LINK_TEXT}}", "HR Automation System")
                            .Replace("{{HEADLINE}}", "Applicant Status")
                            .Replace("{{BODY}}", $"Dear {applicant.Firstname},<br> Application [{applicant.Id}] has changed its status. <br> Current Status: {newStatus}");

                        await _emailService.SendEmail(applicant.Email, "Alliance Software Inc. Applicant Status Update", body);
                    }
                    break;
                case "Rejected":
                    {
                        var redirectLink = "https://localhost:50991/Home";
                        await _emailService.SendEmail(applicant.Email, "Applicant Status Update for Applicant",
                        $"<b>Dear {applicant.Firstname},</b> <br><br> {msgBody} <br><br> <b>Status:</b> {newStatus}. " +
                        $"<br><br> <em>This is an automated messsage. Do not reply</em> <br><br> <a href=\"{redirectLink}\" " +
                        $"style=\"background-color: #FF0000; border: none; color: white; padding: 10px 24px; text-align: center; text-decoration: underline; " +
                        $"display: inline-block; font-size: 14px; margin: 4px 2px; cursor: pointer;\">Visit Alliance</a>");
                    }
                    break;
                default:
                    break;
            }

        }

    }
}