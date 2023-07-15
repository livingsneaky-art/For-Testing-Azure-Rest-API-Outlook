﻿using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using static Basecode.Services.Services.ErrorHandling;

namespace Basecode.Services.Interfaces
{
    /// <summary>
    /// Represents an interface for the Applicant service.
    /// </summary>
    public interface IApplicantService
    {
        /// <summary>
        /// Retrieves a list of all applicants.
        /// </summary>
        /// <returns>A list of Applicant objects.</returns>
        List<Applicant> GetApplicants();

        List<ApplicantViewModel> GetApplicant();

        /// <summary>
        /// Retrieves an applicant by its ID.
        /// </summary>
        /// <param name="id">The ID of the applicant.</param>
        /// <returns>The Applicant object.</returns>
        Applicant GetApplicantById(int id);

        /// <summary>
        /// Creates a new applicant based on the provided applicant data.
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns>Returns a tuple with the log content and the ID of the created applicant.</returns>
        (LogContent, int) Create(ApplicantViewModel applicant);
    }
}
