// IAR jue 08AGO2024

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projBaseDemo.Application.Interfaces.Repositories;
using projBaseDemo.Shared;


namespace projBaseDemo.Application.Features.Articulo.Queries.GetAllArticulos
{
    public record GetAllArticulosQuery : IRequest<Result<List<GetAllArticulosDto>>>;

    internal class GetAllArticulosQueryHandler : IRequestHandler<GetAllArticulosQuery, Result<List<GetAllArticulosDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllArticulosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllArticulosDto>>> Handle(GetAllArticulosQuery query, CancellationToken cancellationToken)
        {
            var players = await _unitOfWork.Repository<Domain.Entities.Articulo>().Entities
                   .ProjectTo<GetAllArticulosDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetAllArticulosDto>>.SuccessAsync(players);
        }
    }
}
