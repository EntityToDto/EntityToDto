using System;

namespace EntityToDto
{
    public class IdentityMap<TDto, TEntity> : ValueMap<TDto, TEntity>, IDtoMap<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        public IdentityMap(MappingDepth mappingDepth, TDto dto, TEntity entity) : base(mappingDepth, dto, entity)
        {
        }

        public override void Accept(DtoMapVisitor<TDto, TEntity> visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            if ((MappingDepth & MappingDepth.Root) == MappingDepth.Root || (MappingDepth & MappingDepth.Keys) == MappingDepth.Keys)
            {
                visitor.Visit(this);
            }
        }
    }
}
