// IAR jue 08AGO2024

using AutoMapper;
using MediatR;
using projBaseDemo.Application.Interfaces.Repositories;
using projBaseDemo.Shared;

namespace projBaseDemo.Application.Features.Articulo.Queries.GetArticulobyId
{
    public record GetArticuloByIdQuery : IRequest<Result<GetArticuloByIdDto>>
    {
        public int Id { get; set; }

        public GetArticuloByIdQuery()
        {

        }

        public GetArticuloByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetArticuloByIdQueryHandler : IRequestHandler<GetArticuloByIdQuery, Result<GetArticuloByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetArticuloByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetArticuloByIdDto>> Handle(GetArticuloByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Domain.Entities.Articulo>().GetByIdAsync(query.Id);
            var articulo = _mapper.Map<GetArticuloByIdDto>(entity);
            return await Result<GetArticuloByIdDto>.SuccessAsync(articulo);
        }
    }
}
