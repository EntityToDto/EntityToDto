namespace EntityToDto
{
    /// <summary>
    /// Mapper class which contains logic to map DTO properties depending on mapping depth configuration.
    /// </summary>
    /// <typeparam name="TDto">DTO type.</typeparam>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public abstract class DtoMapVisitor<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        /// <summary>
        /// Performs mapping for identity properties.
        /// </summary>
        /// <param name="map">The identity map.</param>
        public abstract void Visit(IdentityMap<TDto, TEntity> map);

        /// <summary>
        /// Performs mapping for primitive properties.
        /// </summary>
        /// <param name="map">The primitive map.</param>
        public abstract void Visit(PrimitiveMap<TDto, TEntity> map);

        /// <summary>
        /// Performs mapping for complex type properties.
        /// </summary>
        /// <param name="map">The complex type map.</param>
        public abstract void Visit(ComplexTypeMap<TDto, TEntity> map);

        /// <summary>
        /// Strips the <see cref="MappingDepth.Root"/> and <see cref="MappingDepth.Complex"/> as preparation for complex property mapping.
        /// </summary>
        public MappingDepth GetComplexTypePropertyMappingDepth(ComplexTypeMap<TDto, TEntity> map)
        {
            var mappingDepth = map.MappingDepth;
            if ((mappingDepth & MappingDepth.Root) == MappingDepth.Root)
            {
                if ((map.MappingDepth & MappingDepth.Complex) == MappingDepth.Complex)
                {
                    mappingDepth = map.MappingDepth & ~MappingDepth.Root;
                }
                else
                {
                    mappingDepth = map.MappingDepth & ~(MappingDepth.Root | MappingDepth.Complex);
                }
            }

            return mappingDepth;
        }
    }
}
