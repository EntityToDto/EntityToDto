namespace EntityToDto
{
    public class Mapper
    {
        /// <summary>
        /// Finds the appropriate instance of <see cref="DtoMapVisitor{TDto, TEntity}"/> and performs mapping of DTO properties.
        /// </summary>
        /// <typeparam name="TDto">DTO type.</typeparam>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">The source object for mapping.</param>
        /// <param name="mappingDepth">Mapping depth configuration.</param>
        /// <returns></returns>
        public static TDto Map<TDto, TEntity>(TEntity entity, MappingDepth mappingDepth)
            where TDto : class, new()
            where TEntity : class
        {
            if (mappingDepth == MappingDepth.None || entity == null || !DtoMapVisitorFactory.TryCreate<TDto, TEntity>(out var visitor) || visitor == null)
            {
                return null;
            }

            TDto dto = new TDto();

            new IdentityMap<TDto, TEntity>(mappingDepth, dto, entity).Accept(visitor);
            new PrimitiveMap<TDto, TEntity>(mappingDepth, dto, entity).Accept(visitor);
            new ComplexTypeMap<TDto, TEntity>(mappingDepth, dto, entity).Accept(visitor);

            return dto;
        }
    }
}
