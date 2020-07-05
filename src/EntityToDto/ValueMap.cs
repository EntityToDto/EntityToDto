namespace EntityToDto
{
    /// <summary>
    /// Facilitates mapping for primitive or identity properties of the DTO.
    /// </summary>
    /// <typeparam name="TDto">DTO type.</typeparam>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public abstract class ValueMap<TDto, TEntity> : IDtoMap<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        protected ValueMap(MappingDepth mappingDepth, TDto dto, TEntity entity)
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
        /// Allows the map visitor to execute mapping for primitive or identity properties of the DTO.
        /// </summary>
        /// <param name="visitor">The map visitor.</param>
        public abstract void Accept(DtoMapVisitor<TDto, TEntity> visitor);
    }
}
