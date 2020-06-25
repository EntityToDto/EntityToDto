#nullable enable

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;

namespace EntityToDto
{
    public class DtoMapVisitorFactory
    {
        static DtoMapVisitorFactory()
        {
            InitializeMapVisitorCache();
        }

        private static readonly ConcurrentDictionary<(Type, Type), object> _dtoMapVisitorCache = new ConcurrentDictionary<(Type, Type), object>();

        public static bool TryCreate<TDto, TEntity>(out DtoMapVisitor<TDto, TEntity>? visitor)
            where TDto : class, new()
            where TEntity : class
        {
            (Type dtoType, Type entityType) key = (typeof(TDto), typeof(TEntity));
            if (_dtoMapVisitorCache.TryGetValue(key, out var cachedVisitor))
            {
                visitor = (DtoMapVisitor<TDto, TEntity>)cachedVisitor;
                return true;
            }

            // No configured map visitor
            var visitorType = FindDtoMapVisitorType<TDto, TEntity>();
            if (visitorType == null)
            {
                visitor = null;
                return false;
            }

            // If it reaches to this point, meaning it has not been added to cache
            // Cache for fast future retrieval
            visitor = (DtoMapVisitor<TDto, TEntity>?)Activator.CreateInstance(visitorType);
            return _dtoMapVisitorCache.TryAdd(key, visitor);
        }

        private static Type? FindDtoMapVisitorType<TDto, TEntity>()
            where TDto : class, new()
            where TEntity : class
        {
            var dtoMapVisitorTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                .Where(t => !t.IsAbstract && IsSubclassOfRawGeneric(t, typeof(DtoMapVisitor<,>)));

            foreach (var visitorType in dtoMapVisitorTypes)
            {
                // [0] -> Dto type, [1] Entity type
                var genericArguments = visitorType.BaseType.GetGenericArguments();
                Debug.Assert(genericArguments.Length == 2, $"'{visitorType}' generic arguments does not match '{typeof(DtoMapVisitor<,>)}'");

                (Type dtoType, Type entityType) key = (genericArguments[0], genericArguments[1]);
                if (key.dtoType == typeof(TDto) && key.entityType == typeof(TEntity))
                {
                    return visitorType;
                }
            }

            return null;
        }

        private static bool IsSubclassOfRawGeneric(Type toCheck, Type generic)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var current = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == current)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }

            return false;
        }

        private static void InitializeMapVisitorCache()
        {
            var dtoMapVisitorTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                .Where(t => !t.IsAbstract && IsSubclassOfRawGeneric(t, typeof(DtoMapVisitor<,>)));

            foreach (var visitorType in dtoMapVisitorTypes)
            {
                // [0] -> Dto type, [1] Entity type
                var genericArguments = visitorType.BaseType.GetGenericArguments();
                Debug.Assert(genericArguments.Length == 2, $"'{visitorType}' generic arguments does not match '{typeof(DtoMapVisitor<,>)}'");

                (Type dtoType, Type entityType) key = (genericArguments[0], genericArguments[1]);
                var visitor = Activator.CreateInstance(visitorType);

                _dtoMapVisitorCache.TryAdd(key, visitor);
            }
        }
    }
}
