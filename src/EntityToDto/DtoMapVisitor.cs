namespace EntityToDto
{
    public abstract class DtoMapVisitor<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class
    {
        public abstract void Visit(IdentityMap<TDto, TEntity> map);
        public abstract void Visit(PrimitiveMap<TDto, TEntity> map);
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
