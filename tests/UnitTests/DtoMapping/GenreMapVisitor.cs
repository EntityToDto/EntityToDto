using EntityToDto;
using UnitTests.Dtos;
using UnitTests.Entities;

namespace UnitTests.DtoMapping
{
    public class GenreMapVisitor : DtoMapVisitor<GenreDto, Genre>
    {
        public override void Visit(IdentityMap<GenreDto, Genre> map)
        {
            map.Dto.ID = map.Entity.ID;
        }

        public override void Visit(PrimitiveMap<GenreDto, Genre> map)
        {
            map.Dto.Name = map.Entity.Name;
        }

        public override void Visit(ComplexTypeMap<GenreDto, Genre> map)
        {
        }
    }
}
