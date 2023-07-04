using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using System.Collections.Generic;

namespace Basecode.Services.Interfaces
{
    /// <summary>
    /// Defines methods for managing job openings.
    /// </summary>
    public interface IJobOpeningService
    {
        /// <summary>
        /// Gets a list of all job openings.
        /// </summary>
        /// <returns>A list of job opening view models.</returns>
        List<JobOpeningViewModel> GetJobs();

        /// <summary>
        /// Creates a new job opening.
        /// </summary>
        /// <param name="jobOpening">The job opening to create.</param>
        /// <param name="createdBy">The user who created the job opening.</param>
        void Create(JobOpening jobOpening, string createdBy);

        /// <summary>
        /// Gets a job opening by its ID.
        /// </summary>
        /// <param name="id">The ID of the job opening to get.</param>
        /// <returns>A job opening view model, or null if no such job opening exists.</returns>
        JobOpeningViewModel GetById(int id);

        /// <summary>
        /// Updates an existing job opening.
        /// </summary>
        /// <param name="jobOpening">The job opening to update.</param>
        /// <param name="updatedBy">The user who updated the job opening.</param>
        void Update(JobOpeningViewModel jobOpening, string updatedBy);

        /// <summary>
        /// Deletes a job opening.
        /// </summary>
        /// <param name="jobOpening">The job opening to delete.</param>
        void Delete(JobOpeningViewModel jobOpening);
    }
}
