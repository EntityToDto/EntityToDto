namespace EntityToDto
{
    /// <summary>
    /// Map to be resolved based on <see cref="MappingDepth"/>.
    /// </summary>
    /// <typeparam name="TDto">DTO type.</typeparam>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public interface IDtoMap<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        MappingDepth MappingDepth { get; }
        TEntity Entity { get; }
        TDto Dto { get; }

        void Accept(DtoMapVisitor<TDto, TEntity> visitor);
    }
}
