// IAR mie 07AGO2024

using AutoMapper;
using MediatR;
using projBaseDemo.Application.Interfaces.Repositories;
using projBaseDemo.Shared;


namespace projBaseDemo.Application.Features.Articulo.Commands.UpdateArticulo
{
    public record UpdateArticuloCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public string Itemno { get; set; }

        public string Descripcion { get; set; }

        public string IdCategoria { get; set; }

        public string Almacen { get; set; }

        public bool Status { get; set; }

    }
    internal class UpdateArticuloCommandHandler : IRequestHandler<UpdateArticuloCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateArticuloCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateArticuloCommand command, CancellationToken cancellationToken)
        {
            var articulo = await _unitOfWork.Repository<Domain.Entities.Articulo>().GetByIdAsync(command.Id);
            if (articulo != null)
            {
                articulo.Itemno = command.Itemno;
                articulo.Descripcion = command.Descripcion;
                articulo.IdCategoria = command.IdCategoria;
                articulo.Almacen = command.Almacen;
                articulo.Status = command.Status;

                await _unitOfWork.Repository<Domain.Entities.Articulo>().UpdateAsync(articulo);
                articulo.AddDomainEvent(new ArticuloUpdatedEvent(articulo));

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(articulo.Id, "Artículo actualizado.");
            }
            else
            {
                return await Result<int>.FailureAsync("Artículo no encontrado.");
            }
        }
    }
}
