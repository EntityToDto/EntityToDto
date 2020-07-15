using System;

namespace EntityToDto
{
    /// <summary>
    /// Facilitates mapping for primitive type properties of the DTO.
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
        /// Allows the map visitor to execute mapping for primitive type properties of the DTO.
        /// </summary>
        /// <param name="visitor">The map visitor.</param>
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
