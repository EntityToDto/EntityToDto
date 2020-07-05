using System;

namespace EntityToDto
{
    /// <summary>
    /// Facilitates mapping for identity (key) property/ies of the DTO.
    /// </summary>
    /// <typeparam name="TDto">DTO type.</typeparam>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public class IdentityMap<TDto, TEntity> : ValueMap<TDto, TEntity>, IDtoMap<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        public IdentityMap(MappingDepth mappingDepth, TDto dto, TEntity entity) : base(mappingDepth, dto, entity)
        {
        }

        /// <summary>
        /// Allows the map visitor to execute mapping for identity (key) type properties of the DTO.
        /// </summary>
        /// <param name="visitor">The map visitor.</param>
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
