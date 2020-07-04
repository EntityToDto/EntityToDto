using System;

namespace EntityToDto
{
    /// <summary>
    /// Facilitates mapping of primitive types for DTO.
    /// </summary>
    /// <typeparam name="TDto">DTO type.</typeparam>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public class PrimitiveMap<TDto, TEntity> : ValueMap<TDto, TEntity>, IDtoMap<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        public PrimitiveMap(MappingDepth mappingDepth, TDto dto, TEntity entity) : base(mappingDepth, dto, entity)
        {
        }

        /// <summary>
        /// Enables the <see cref="DtoMapVisitor{TDto, TEntity}"/> to map primitive types of DTO object.
        /// </summary>
        /// <param name="visitor">The visitor object that contains DTO mapping logic.</param>
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
