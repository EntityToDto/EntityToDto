using System;

namespace EntityToDto
{
    public class PrimitiveMap<TDto, TEntity> : ValueMap<TDto, TEntity>, IDtoMap<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        public PrimitiveMap(MappingDepth mappingDepth, TDto dto, TEntity entity) : base(mappingDepth, dto, entity)
        {
        }

        public override void Accept(DtoMapVisitor<TDto, TEntity> visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            if ((MappingDepth & MappingDepth.Root) == MappingDepth.Root || (MappingDepth & MappingDepth.Primitives) == MappingDepth.Primitives)
            {
                visitor.Visit(this);
            }
        }
    }
}
