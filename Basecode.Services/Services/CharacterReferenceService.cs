using AutoMapper;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using static Basecode.Services.Services.ErrorHandling;

namespace Basecode.Services.Services
{
    public class CharacterReferenceService : ICharacterReferenceService
    {
        private readonly ICharacterReferenceRepository _repository;
        private readonly IMapper _mapper;

        public CharacterReferenceService(ICharacterReferenceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public LogContent Create(CharacterReferenceViewModel characterReference, int applicantId)
        {
            LogContent logContent = new LogContent();

            logContent = CheckCharacterReference(characterReference);
            if (logContent.Result == false)
            {
                var characterModel = _mapper.Map<CharacterReference>(characterReference);
                characterModel.ApplicantId = applicantId;
                _repository.CreateReference(characterModel);
            }

            return logContent;
        }
    }
}
