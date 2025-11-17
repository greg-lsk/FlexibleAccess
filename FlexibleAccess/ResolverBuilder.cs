using System.Reflection;
using System.Linq.Expressions;
using FlexibleAccess.Exceptions;
using FlexibleAccess._Internals.MemberInfoRetrieval;


namespace FlexibleAccess;

public static class ResolverBuilder<THost, TCriteria> where TCriteria : struct, IResolutionCriteria
{
    public static Resolver<THost, TResult> ValueOf<TResult>()
    {
        var memberInfo = TryGetMemberInfo<TResult>();

        var instance = Expression.Parameter(typeof(THost), "host");

        var criteria = new TCriteria();
        var memberAccess = (criteria.BindingFlags & BindingFlags.Static) == BindingFlags.Static
                           ? Expression.MakeMemberAccess(null, memberInfo)
                           : Expression.MakeMemberAccess(instance, memberInfo);

        var lambda = Expression.Lambda<Resolver<THost, TResult>>(memberAccess, instance);
        return lambda.Compile();
    }

    public static Resolver<THost, string> NameOf<TResult>()
    {
        var memberInfo = TryGetMemberInfo<TResult>();

        var instance = Expression.Parameter(typeof(THost), "host");
        var memberName = Expression.Constant(memberInfo.Name);

        var lambda = Expression.Lambda<Resolver<THost, string>>(memberName, instance);
        return lambda.Compile();
    }


    private static MemberInfo TryGetMemberInfo<T>()
    {
        var criteria = new TCriteria();
        var memberInfoRetrieval = MemberInfoRetrievalLogic.For<THost>(criteria.MemberKind);

        return memberInfoRetrieval(criteria.Identifier, criteria.BindingFlags)
        ?? throw new UnableToResolveException<THost, T>(criteria.Identifier, criteria.BindingFlags);
    }    
}