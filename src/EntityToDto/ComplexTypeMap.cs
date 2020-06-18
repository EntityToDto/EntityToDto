using System;

namespace EntityToDto
{
    public class ComplexTypeMap<TDto, TEntity> : IDtoMap<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        public ComplexTypeMap(MappingDepth mappingDepth, TDto dto, TEntity entity)
        {
            MappingDepth = mappingDepth;
            Entity = entity;
            Dto = dto;
        }

        public MappingDepth MappingDepth { get; private set; }
        public TEntity Entity { get; private set; }
        public TDto Dto { get; private set; }

        public void Accept(DtoMapVisitor<TDto, TEntity> visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            if ((MappingDepth & MappingDepth.Root) == MappingDepth.Root || (MappingDepth & MappingDepth.Complex) == MappingDepth.Complex)
            {
                visitor.Visit(this);
            }
        }
    }
}
