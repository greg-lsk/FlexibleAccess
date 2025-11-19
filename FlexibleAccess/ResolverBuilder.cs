using System.Reflection;
using System.Linq.Expressions;
using FlexibleAccess.Exceptions;
using FlexibleAccess._Internals.MemberInfoRetrieval;
using FlexibleAccess._Internals.InvalidInstanceHandling;
using FlexibleAccess._Internals.ResolutionCriteriaProcessing;


namespace FlexibleAccess;

public static class ResolverBuilder<THost, TCriteria> where TCriteria : struct, IResolutionCriteria
{
    public static Resolver<THost, TResult> ValueOf<TResult>()
    {
        var memberInfo = TryGetMemberInfo<TResult>();

        var instance = typeof(THost).IsValueType switch 
        {
            true  => Expression.Parameter(typeof(Nullable<>).MakeGenericType(typeof(THost)), "host"),
            false => Expression.Parameter(typeof(THost), "host")
        };

        var memberAccess = (CriteriaProcessor<TCriteria>.IndicatesOnTypeResolution(), typeof(THost).IsValueType) switch
        {   
            (true, _)      => Expression.MakeMemberAccess(null, memberInfo),
            (false, true)  => Expression.MakeMemberAccess(Expression.Property(instance, "Value"), memberInfo),
            (false, false) => Expression.MakeMemberAccess(instance, memberInfo)
        };

        Expression lambdaBody = CriteriaProcessor<TCriteria>.IndicatesOnTypeResolution() switch
        {
            true  => memberAccess,
            false => Expression.Block
            (
                Expression.Call(InstanceHandlingExpression(), instance),
                memberAccess
            )
        };

        var lambda = Expression.Lambda<Resolver<THost, TResult>>(lambdaBody, instance);
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
    
    private static MethodInfo InstanceHandlingExpression()
    {
        var methodName = typeof(THost).IsValueType ? nameof(InvalidInstanceHandler<TCriteria>.ValueType)
                                                   : nameof(InvalidInstanceHandler<TCriteria>.ReferenceType);

        return typeof(InvalidInstanceHandler<TCriteria>).GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic)!
                                                        .MakeGenericMethod(typeof(THost));
    }
}