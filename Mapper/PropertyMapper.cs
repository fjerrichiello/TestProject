using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace Mapper;

public static class PropertyMapper
{
    // Cache for constructor-based mappers to improve performance
    private static readonly
        ConcurrentDictionary<(Type Source, Type Target), Delegate>
        _cachedMappers = new();

    public static TTarget Map<TSource, TTarget>(TSource source)
        where TSource : class
        where TTarget : class
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        // Try to get the cached mapper for the source/target pair
        if (!_cachedMappers.TryGetValue((typeof(TSource), typeof(TTarget)),
                out var cachedMapper))
        {
            // Create and cache the mapper if it doesn't exist
            cachedMapper = CreateMapper<TSource, TTarget>();
            _cachedMappers[(typeof(TSource), typeof(TTarget))] = cachedMapper;
        }

        // Invoke the cached mapper
        var mapperFunc = (Func<TSource, TTarget>)cachedMapper;
        return mapperFunc(source);
    }

    // Generates a constructor-based mapper function using expression trees
    private static Func<TSource, TTarget> CreateMapper<TSource, TTarget>()
        where TSource : class
        where TTarget : class
    {
        var sourceType = typeof(TSource);
        var targetType = typeof(TTarget);

        var sourceParam = Expression.Parameter(sourceType, "source");

        // Find the primary constructor of the target record type
        var constructor = targetType
            .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
            .MaxBy(c => c.GetParameters().Length);

        if (constructor == null)
        {
            throw new InvalidOperationException(
                $"No suitable constructor found for type {targetType.Name}");
        }

        var constructorParams = constructor.GetParameters();
        var arguments = new List<Expression>();

        foreach (var param in constructorParams)
        {
            var sourceProperty = sourceType.GetProperty(param.Name,
                BindingFlags.Public | BindingFlags.Instance);
            if (sourceProperty != null && sourceProperty.CanRead)
            {
                // Create property access expressions (source.Property)
                var sourceValue =
                    Expression.Property(sourceParam, sourceProperty);

                Expression checkedValue = sourceValue;
                // If the parameter is non-nullable, add a check for null values
                if (IsNonNullable(param.ParameterType))
                {
                    var nullCheck = Expression.Equal(sourceValue,
                        Expression.Constant(null));
                    var throwExpression = Expression.Throw(
                        Expression.New(
                            typeof(InvalidOperationException).GetConstructor(
                                [typeof(string)]) ??
                            throw new InvalidOperationException(
                                "Constructor Not Found"),
                            Expression.Constant(
                                $"Cannot assign null to non-nullable constructor parameter '{param.Name}'")));

                    checkedValue = Expression.Condition(nullCheck,
                        throwExpression, sourceValue);
                }

                // Add the source value expression to the argument list
                arguments.Add(checkedValue);
            }
            else
            {
                throw new InvalidOperationException(
                    $"No matching property found on source for constructor parameter '{param.Name}'");
            }
        }

        // Create the constructor call expression (new TTarget(args))
        var newExpression = Expression.New(constructor, arguments);

        // Compile the expression into a delegate Func<TSource, TTarget>
        var lambda =
            Expression.Lambda<Func<TSource, TTarget>>(newExpression,
                sourceParam);
        return lambda.Compile();
    }

    // Helper function to check if a type is non-nullable
    private static bool IsNonNullable(Type type)
    {
        if (type.IsValueType)
        {
            return Nullable.GetUnderlyingType(type) == null;
        }

        return !type.IsClass;
    }
}
