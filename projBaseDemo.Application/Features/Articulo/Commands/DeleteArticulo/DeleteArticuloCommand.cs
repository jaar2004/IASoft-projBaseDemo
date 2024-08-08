// IAR mie 07AGO2024

using AutoMapper;
using MediatR;
using projBaseDemo.Application.Common.Mappings;
using projBaseDemo.Application.Interfaces.Repositories;
using projBaseDemo.Shared;

namespace projBaseDemo.Application.Features.Articulo.Commands.DeleteArticulo
{
    public record DeleteArticuloCommand : IRequest<Result<int>>, IMapFrom<Domain.Entities.Articulo>
    {
        public int Id { get; set; }

        public DeleteArticuloCommand()
        {

        }

        public DeleteArticuloCommand(int id)
        {
            Id = id;
        }
    }

    internal class DeleteArticuloCommandHandler : IRequestHandler<DeleteArticuloCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteArticuloCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeleteArticuloCommand command, CancellationToken cancellationToken)
        {
            var articulo = await _unitOfWork.Repository<Domain.Entities.Articulo>().GetByIdAsync(command.Id);
            if (articulo != null)
            {
                await _unitOfWork.Repository<Domain.Entities.Articulo>().DeleteAsync(articulo);
                articulo.AddDomainEvent(new ArticuloDeletedEvent(articulo));

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(articulo.Id, "Artículo borrado.");
            }
            else
            {
                return await Result<int>.FailureAsync("Artículo no encontrado.");
            }
        }
    }
}
