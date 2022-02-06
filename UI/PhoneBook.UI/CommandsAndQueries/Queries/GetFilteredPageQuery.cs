using MediatR;
using PhoneBook.DAL.Entities;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.CommandsAndQueries.Queries
{
    public class GetFilteredPageQuery:IRequest<IPage<PhoneRecordViewModel>>
    {
        public Func<dynamic, bool> FilterExpression { get; set; }
    }

    public class GetFilteredPageQueryHandler : IRequestHandler<GetFilteredPageQuery, IPage<PhoneRecordViewModel>>
    {
        private readonly IMappedRepository<PhoneRecordViewModel, PhoneRecord> _repository;
        public GetFilteredPageQueryHandler(IMappedRepository<PhoneRecordViewModel, PhoneRecord> repository)
        {
            _repository = repository;
        }        
        public async Task<IPage<PhoneRecordViewModel>> Handle(GetFilteredPageQuery request, CancellationToken cancellationToken)
        {            
            return await _repository.GetPage(request.FilterExpression, cancellationToken);  
        }
    }
}
