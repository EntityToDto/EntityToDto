using System;

namespace EntityToDto
{
    /// <summary>
    /// Facilitates mapping for complex type properties of the DTO.
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

        /// <inheritdoc/>
        public MappingDepth MappingDepth { get; private set; }

        /// <inheritdoc/>
        public TEntity Entity { get; private set; }

        /// <inheritdoc/>
        public TDto Dto { get; private set; }

        /// <summary>
        /// Allows the map visitor to execute mapping for complex type properties of the DTO.
        /// </summary>
        /// <param name="visitor">The map visitor.</param>
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
