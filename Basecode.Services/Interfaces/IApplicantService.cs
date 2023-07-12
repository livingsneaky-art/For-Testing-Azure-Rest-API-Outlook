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

        /// <summary>
        /// Creates a new applicant.
        /// </summary>
        /// <param name="applicant">The ApplicantViewModel object containing the applicant data.</param>
        /// <returns>A tuple containing a LogContent object and the ID of the created applicant.</returns>
        LogContent Create(ApplicantViewModel applicant);
    }
}
