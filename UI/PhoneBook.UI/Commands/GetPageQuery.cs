using MediatR;
using PhoneBook.Common;
using PhoneBook.DAL.Entities;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Commands
{
    public class GetPageQuery:IRequest<IPage<PhoneRecordViewModel>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }


    public class GetPageQueryHandler : IRequestHandler<GetPageQuery, IPage<PhoneRecordViewModel>>
    {
        private readonly IMappedRepository<PhoneRecordViewModel, PhoneRecord> _repository;
        public GetPageQueryHandler(IMappedRepository<PhoneRecordViewModel, PhoneRecord> repository)
        {
            _repository = repository;
        }
        public async Task<IPage<PhoneRecordViewModel>> Handle(GetPageQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPage(request.PageIndex, request.PageSize, cancellationToken);
        }
    }
}
