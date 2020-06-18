using EntityToDto;
using UnitTests.Dtos;
using UnitTests.Entities;

namespace UnitTests.DtoMapping
{
    public class TrackMapVisitor : DtoMapVisitor<TrackDto, Track>
    {
        public override void Visit(IdentityMap<TrackDto, Track> map)
        {
            map.Dto.ID = map.Entity.ID;
        }

        public override void Visit(PrimitiveMap<TrackDto, Track> map)
        {
            map.Dto.Name = map.Entity.Name;
            map.Dto.Composer = map.Entity.Composer;
            map.Dto.Milliseconds = map.Entity.Milliseconds;
            map.Dto.Bytes = map.Entity.Bytes;
            map.Dto.UnitPrice = map.Entity.UnitPrice;
        }

        public override void Visit(ComplexTypeMap<TrackDto, Track> map)
        {
            map.Dto.Genre = Mapper.Map<GenreDto, Genre>(map.Entity.Genre, GetComplexTypePropertyMappingDepth(map));
            map.Dto.MediaType = Mapper.Map<MediaTypeDto, MediaType>(map.Entity.MediaType, GetComplexTypePropertyMappingDepth(map));
        }
    }
}
