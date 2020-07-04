using System;

namespace EntityToDto
{
    /// <summary>
    /// Facilitates mapping of identity (key) property/ies for DTO.
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
        /// Enables the <see cref="DtoMapVisitor{TDto, TEntity}"/> to map identity (key) properties of DTO object.
        /// </summary>
        /// <param name="visitor">The visitor object that contains DTO mapping logic.</param>
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
