using Basecode.Data.Models;
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

        /// <summary>
        /// Retrieves an applicant by its ID.
        /// </summary>
        /// <param name="id">The ID of the applicant.</param>
        /// <returns>The Applicant object.</returns>
        Applicant GetApplicantById(int id);

        (LogContent, int) Create(ApplicantViewModel applicant);
    }
}
