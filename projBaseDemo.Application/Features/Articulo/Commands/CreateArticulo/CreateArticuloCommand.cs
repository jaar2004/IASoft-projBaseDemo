// IAR lun 01JUL2024

using AutoMapper;
using MediatR;
using projBaseDemo.Application.Common.Mappings;
using projBaseDemo.Application.Interfaces.Repositories;
using projBaseDemo.Shared;
using projBaseDemo.Domain.Entities;

/*
IAR mie 07AGO2024
Solución a problema de namespace.
Tenia error con el namespace "projBaseDemo.Domain.Entities" no lo estaba detectando.
Usé en su lugar "Domain.Entities.Articulo" directamente en la línea de código.

Texto búsqueda: is a namespace but is using like a type
It happens when the namespace and class name are the same. do one thing write the full name of the 
namespace when you want to use the namespace.

*/

namespace projBaseDemo.Application.Features.Articulo.Commands.CreateArticulo
{
    public record CreateArticuloCommand : IRequest<Result<int>>, IMapFrom<Domain.Entities.Articulo>
    {
        // IAR mie 07AGO2024
        public string Itemno { get; set; }
        public string Descripcion { get; set; }

        
        public string IdCategoria { get; set; }

        public string Almacen { get; set; }

        public bool Status { get; set; }

    }

    internal class CreateArticuloCommandHandler : IRequestHandler<CreateArticuloCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateArticuloCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateArticuloCommand command, CancellationToken cancellationtoken)
        {
            var articulo = new Domain.Entities.Articulo()
            {
                Itemno = command.Itemno,
                Descripcion = command.Descripcion,
                IdCategoria = command.IdCategoria,
                Almacen = command.Almacen,
                Status = command.Status
            };

            await _unitOfWork.Repository<Domain.Entities.Articulo>().AddAsync(articulo);
            articulo.AddDomainEvent(new ArticuloCreatedEvent(articulo));
            await _unitOfWork.Save(cancellationtoken);

            return await Result<int>.SuccessAsync(articulo.Id, "Artículo creado.");
        }
    }
}
