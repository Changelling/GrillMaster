using AutoMapper;

namespace GrillMaster.Application.Common.Mappings
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism to map an entity of type A to type B.
    /// </summary>
    public interface IMapFrom<T>
    {   
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
