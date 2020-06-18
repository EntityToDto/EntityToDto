namespace EntityToDto
{
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
