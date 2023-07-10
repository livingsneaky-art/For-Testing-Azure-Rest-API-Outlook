using AutoMapper;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Services;
using Moq;
using static Basecode.Services.Services.ErrorHandling;

namespace Basecode.Tests.Services
{
    public class CharacterReferenceServiceTests
    {
        private readonly CharacterReferenceService _service;
        private readonly Mock<ICharacterReferenceRepository> _fakeCharacterReferenceRepository;
        private readonly Mock<IMapper> _fakeMapper;

        public CharacterReferenceServiceTests()
        {
            _fakeCharacterReferenceRepository = new Mock<ICharacterReferenceRepository>();
            _fakeMapper = new Mock<IMapper>();
            _service = new CharacterReferenceService(_fakeCharacterReferenceRepository.Object, _fakeMapper.Object);
        }

        [Fact]
        public void Create_ValidCharacterReference_ReturnsLogContent()
        {
            // Arrange
            var characterReference = new CharacterReferenceViewModel();
            var applicantId = 1;

            _fakeCharacterReferenceRepository.Setup(repo => repo.CreateReference(It.IsAny<CharacterReference>()));

            // Act
            var result = _service.Create(characterReference, applicantId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<LogContent>(result);
        }

        [Fact]
        public void Create_InvalidCharacterReference_DoesNotCallRepository()
        {
            // Arrange
            var characterReference = new CharacterReferenceViewModel();
            var applicantId = 1;

            // Act
            var result = _service.Create(characterReference, applicantId);

            // Assert
            _fakeCharacterReferenceRepository.Verify(repo => repo.CreateReference(It.IsAny<CharacterReference>()), Times.Never);
        }
    }
}
