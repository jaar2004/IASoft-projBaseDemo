// IAR lun 01JUL2024

using AutoMapper;
using MediatR;
using projBaseDemo.Application.Common.Mappings;
using projBaseDemo.Application.Interfaces.Repositories;
using projBaseDemo.Shared;
using projBaseDemo.Domain.Entities;

namespace projBaseDemo.Application.Features.Articulo.Commands.CreateArticulo
{
    public record CreateArticuloCommand : IRequest<Result<int>>, IMapFrom<Articulo>
    {

    }

    internal class CreateArticuloCommand
    {
    }
}
