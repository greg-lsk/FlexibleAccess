using System.Reflection;
using System.Linq.Expressions;
using FlexibleAccess.Exceptions;


namespace FlexibleAccess;

public static class ResolverBuilder<THost>
{
    public static Resolver<THost, TResult> ValueOf<TResult>(string identifier)
    {
        var propertyInfo = TryGetProperty<TResult>(identifier);

        var propertyAccess = Expression.MakeMemberAccess(null, propertyInfo);

        var lambda = Expression.Lambda<Resolver<THost, TResult>>(propertyAccess);
        return lambda.Compile();
    }

    public static Resolver<THost, string> NameOf<TResult>(string identifier)
    {
        var propertyInfo = TryGetProperty<TResult>(identifier);

        var propertyName = Expression.Constant(propertyInfo.Name);

        var lambda = Expression.Lambda<Resolver<THost, string>>(propertyName);
        return lambda.Compile();
    }

    private static PropertyInfo TryGetProperty<T>(string identifier)
    {
        return typeof(THost).GetProperty(identifier, BindingFlags.Static | BindingFlags.NonPublic) 
        ?? throw new UnableToResolveException<THost, T>
        (
            identifier,
            BindingFlags.Static,
            BindingFlags.NonPublic
        ); 
    }
}