using System;

namespace EntityToDto
{
    /// <summary>
    /// Facilitates mapping of DTO properties for complex type.
    /// </summary>
    /// <typeparam name="TDto">DTO type.</typeparam>
    /// <typeparam name="TEntity">Entity type.</typeparam>
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

        /// <summary>
        /// Enables the <see cref="DtoMapVisitor{TDto, TEntity}"/> to map DTO complex properties.
        /// </summary>
        /// <param name="visitor">The visitor object that contains DTO mapping logic.</param>
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
