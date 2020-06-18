namespace EntityToDto
{
    public class Mapper
    {
        public static TDto Map<TDto, TArgType>(TArgType entity, MappingDepth mappingDepth)
            where TDto : class, new()
            where TArgType : class
        {
            if (mappingDepth == MappingDepth.None || entity == null || !DtoMapVisitorFactory.TryCreate<TDto, TArgType>(out var visitor) || visitor == null)
            {
                return null;
            }

            TDto dto = new TDto();

            new IdentityMap<TDto, TArgType>(mappingDepth, dto, entity).Accept(visitor);
            new PrimitiveMap<TDto, TArgType>(mappingDepth, dto, entity).Accept(visitor);
            new ComplexTypeMap<TDto, TArgType>(mappingDepth, dto, entity).Accept(visitor);

            return dto;
        }
    }
}
