using System.Reflection;
using System.Linq.Expressions;
using FlexibleAccess.Exceptions;


namespace FlexibleAccess;

public static class ResolverBuilder<THost, TCriteria> where TCriteria : struct, IResolutionCriteria
{
    public static Resolver<THost, TResult> ValueOf<TResult>()
    {
        var memberInfo = TryGetMemberInfo<TResult>();

        var memberAccess = Expression.MakeMemberAccess(null, memberInfo);

        var lambda = Expression.Lambda<Resolver<THost, TResult>>(memberAccess);
        return lambda.Compile();
    }

    public static Resolver<THost, string> NameOf<TResult>()
    {
        var memberInfo = TryGetMemberInfo<TResult>();

        var memberName = Expression.Constant(memberInfo.Name);

        var lambda = Expression.Lambda<Resolver<THost, string>>(memberName);
        return lambda.Compile();
    }


    private static MemberInfo TryGetMemberInfo<T>()
    {
        var criteria = new TCriteria();
        var createInfo = CreateFor(criteria.MemberKind);

        return createInfo(criteria.Identifier, criteria.BindingFlags)
        ?? throw new UnableToResolveException<THost, T>
        (
            criteria.Identifier,
            criteria.BindingFlags
        );
    }

    private static Func<string, BindingFlags, MemberInfo?>  CreateFor(MemberKind memberKind) => memberKind switch
    {
        MemberKind.Property => typeof(THost).GetProperty,
        MemberKind.Field => typeof(THost).GetField
    };    
}