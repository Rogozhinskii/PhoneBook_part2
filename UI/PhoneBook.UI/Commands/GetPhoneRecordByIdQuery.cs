using MediatR;
using PhoneBook.DAL.Entities;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Commands
{
    public class GetPhoneRecordByIdQuery:IRequest<PhoneRecordViewModel>
    {
        public int Id { get; set; }
    }

    public class GetPhoneRecordByIdQueryHandler : IRequestHandler<GetPhoneRecordByIdQuery, PhoneRecordViewModel>
    {
        private readonly IMappedRepository<PhoneRecordViewModel, PhoneRecord> _repository;

        public GetPhoneRecordByIdQueryHandler(IMappedRepository<PhoneRecordViewModel, PhoneRecord> repository)
        {
            _repository = repository;
        }
        public async Task<PhoneRecordViewModel> Handle(GetPhoneRecordByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
