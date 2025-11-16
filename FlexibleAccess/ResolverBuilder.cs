using System.Reflection;
using System.Linq.Expressions;
using FlexibleAccess.Exceptions;


namespace FlexibleAccess;

public static class ResolverBuilder<THost, TCriteria> where TCriteria : struct, IResolutionCriteria
{
    public static Resolver<THost, TResult> ValueOf<TResult>()
    {
        var propertyInfo = TryGetProperty<TResult>();

        var propertyAccess = Expression.MakeMemberAccess(null, propertyInfo);

        var lambda = Expression.Lambda<Resolver<THost, TResult>>(propertyAccess);
        return lambda.Compile();
    }

    public static Resolver<THost, string> NameOf<TResult>()
    {
        var propertyInfo = TryGetProperty<TResult>();

        var propertyName = Expression.Constant(propertyInfo.Name);

        var lambda = Expression.Lambda<Resolver<THost, string>>(propertyName);
        return lambda.Compile();
    }

    private static PropertyInfo TryGetProperty<T>()
    {
        var criteria = new TCriteria();

        return typeof(THost).GetProperty(criteria.Identifier, criteria.BindingFlags) 
        ?? throw new UnableToResolveException<THost, T>
        (
            criteria.Identifier,
            criteria.BindingFlags
        ); 
    }
}