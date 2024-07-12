// IAR vie 06JUN2024

using AutoMapper;

namespace projBaseDemo.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());

    }
}
