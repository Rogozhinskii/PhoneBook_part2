using MediatR;
using PhoneBook.DAL.Entities;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.CommandsAndQueries.Commands
{
    public class UpdateRecordCommand:IRequest<PhoneRecordViewModel>
    {
        public PhoneRecordViewModel UpdatableRecord { get; set; }
    }

    public class UpdateRecordCommandHandler : IRequestHandler<UpdateRecordCommand, PhoneRecordViewModel>
    {
        private readonly IMappedRepository<PhoneRecordViewModel, PhoneRecord> _repository;

        public UpdateRecordCommandHandler(IMappedRepository<PhoneRecordViewModel, PhoneRecord> repository)
        {
            _repository = repository;
        }
        public async Task<PhoneRecordViewModel> Handle(UpdateRecordCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.UpdatableRecord, cancellationToken);
        }
    }
}
