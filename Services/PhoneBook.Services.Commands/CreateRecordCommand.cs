using MediatR;
using PhoneBook.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Services.Commands
{
    public class CreateRecordCommand:IRequest<PhoneRecordViewModel>
    {
        public PhoneRecordViewModel PhoneRecord { get; set; }
    }

    public class CrateRecordCommandHandler : IRequestHandler<CreateRecordCommand, PhoneRecordViewModel>
    {
        private readonly IMappedRepository<PhoneRecordViewModel, PhoneRecord> _repository;

        public CrateRecordCommandHandler(IMappedRepository<PhoneRecordViewModel, PhoneRecord> repository)
        {
            _repository = repository;
        }

        public async Task<PhoneRecordViewModel> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(request.PhoneRecord,cancellationToken);
        }
    }
}
