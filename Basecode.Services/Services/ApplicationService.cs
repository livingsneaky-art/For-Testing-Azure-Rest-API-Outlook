using AutoMapper;
using Basecode.Data.Interfaces;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repository;
        private readonly IMapper _mapper;
        public ApplicationService(IApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ApplicationViewModel GetById(Guid id)
        {
            var data = _repository.GetById(id);
            return _mapper.Map<ApplicationViewModel>(data);
        }
    }
}
