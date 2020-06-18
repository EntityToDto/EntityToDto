namespace EntityToDto
{
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

        public MappingDepth MappingDepth { get; private set; }
        public TEntity Entity { get; private set; }
        public TDto Dto { get; private set; }

        public abstract void Accept(DtoMapVisitor<TDto, TEntity> visitor);
    }
}
