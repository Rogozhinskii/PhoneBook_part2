using MediatR;
using PhoneBook.DAL.Entities;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.CommandsAndQueries.Commands
{
    public class DeleteByIdRecordCommand:IRequest<PhoneRecordViewModel>
    {
        public int Id { get; set; }
    }

    public class DeleteByIdCommandHandler : IRequestHandler<DeleteByIdRecordCommand, PhoneRecordViewModel>
    {
        private readonly IMappedRepository<PhoneRecordViewModel, PhoneRecord> _repository;

        public DeleteByIdCommandHandler(IMappedRepository<PhoneRecordViewModel, PhoneRecord> repository)
        {
            _repository = repository;
        }

        public async Task<PhoneRecordViewModel> Handle(DeleteByIdRecordCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteByIdAsync(request.Id, cancellationToken);
        }
    }
}
