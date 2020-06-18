using EntityToDto;
using UnitTests.Dtos;
using UnitTests.Entities;

namespace UnitTests.DtoMapping
{
    public class MediaTypeMapVisitor : DtoMapVisitor<MediaTypeDto, MediaType>
    {
        public override void Visit(IdentityMap<MediaTypeDto, MediaType> map)
        {
            map.Dto.ID = map.Entity.ID;
        }

        public override void Visit(PrimitiveMap<MediaTypeDto, MediaType> map)
        {
            map.Dto.Name = map.Entity.Name;
        }

        public override void Visit(ComplexTypeMap<MediaTypeDto, MediaType> map)
        {
        }
    }
}
