// IAR jue 08AGO2024

// This file contains GetPlayersWithPaginationQuery and GetPlayersWithPaginationQueryHandler.
// We are passing GetPlayersWithPaginationQuery as TRequest and PaginatedResult<GetPlayersWithPaginationDto>
// object as TResponse. The PaginatedResult class is our custom class and it is defined in a
// CleanArchitectureDemo.Shared library.

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using projBaseDemo.Application.Extensions;
using projBaseDemo.Application.Interfaces.Repositories;
using projBaseDemo.Shared;

namespace projBaseDemo.Application.Features.Articulo.Queries.GetArticulosWithPagination
{
    public record GetArticulosWithPaginationQuery : IRequest<PaginatedResult<GetArticulosWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetArticulosWithPaginationQuery() { }
        public GetArticulosWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    internal class GetArticulosWithPaginationQueryHandler : IRequestHandler<GetArticulosWithPaginationQuery, PaginatedResult<GetArticulosWithPaginationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetArticulosWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /*
         Inside the Handle method, we are using the ProjectTo<T> extension method available in 
         AutoMapper.QueryableExtensions namespace. This method maps IQueryable<Player> to 
         IQueryable< GetPlayersWithPaginationDto> using the AutoMapper mapping engine. 
         The ToPaginatedListAsync is our custom extension method that creates a paginated result 
        */
        public async Task<PaginatedResult<GetArticulosWithPaginationDto>> Handle(GetArticulosWithPaginationQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Domain.Entities.Articulo>().Entities
                   .OrderBy(x => x.Descripcion)
                   .ProjectTo<GetArticulosWithPaginationDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
