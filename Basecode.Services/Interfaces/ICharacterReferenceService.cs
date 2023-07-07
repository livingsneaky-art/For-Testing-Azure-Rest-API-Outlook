using Basecode.Data.ViewModels;
using static Basecode.Services.Services.ErrorHandling;

namespace Basecode.Services.Interfaces
{
    /// <summary>
    /// Represents an interface for the Character Reference service.
    /// </summary>
    public interface ICharacterReferenceService
    {
        /// <summary>
        /// Creates a new character reference for the specified applicant.
        /// </summary>
        /// <param name="characterReference">The CharacterReferenceViewModel object containing the character reference data.</param>
        /// <param name="applicantId">The ID of the associated applicant.</param>
        /// <returns>A LogContent object representing the result of the operation.</returns>
        LogContent Create(CharacterReferenceViewModel characterReference, int applicantId);
    }
}
