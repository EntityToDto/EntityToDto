namespace EntityToDto
{
    /// <summary>
    /// Base interface for map type.
    /// </summary>
    /// <typeparam name="TDto">DTO type.</typeparam>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public interface IDtoMap<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        /// <summary>
        /// Controls the type of properties to be included for mapping.
        /// </summary>
        MappingDepth MappingDepth { get; }

        /// <summary>
        /// The source object for mapping.
        /// </summary>
        TEntity Entity { get; }

        /// <summary>
        /// The target (destination) object for mapping.
        /// </summary>
        TDto Dto { get; }

        /// <summary>
        /// Allows the map visitor to perform mapping.
        /// </summary>
        /// <param name="visitor"></param>
        void Accept(DtoMapVisitor<TDto, TEntity> visitor);
    }
}
