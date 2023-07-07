using Basecode.Data.ViewModels;
using static Basecode.Services.Services.ErrorHandling;

namespace Basecode.Services.Interfaces
{
    public interface ICharacterReferenceService
    {
        LogContent Create(CharacterReferenceViewModel characterReference, int applicantId);
    }
}
