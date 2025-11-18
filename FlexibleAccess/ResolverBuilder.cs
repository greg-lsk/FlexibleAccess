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

        var instance = Expression.Parameter(typeof(THost), "host");

        Expression lambdaBody = CriteriaProcessor<TCriteria>.IndicatesOnTypeResolution() switch
        {
            true  => Expression.MakeMemberAccess(null, memberInfo),
            false => GetBlockExpression(Expression.MakeMemberAccess(instance, memberInfo), instance)
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
    
    private static BlockExpression GetBlockExpression(MemberExpression memberExpression,
                                                      ParameterExpression parameterExpression)
    {
        var methodName = typeof(THost).IsValueType ? nameof(InvalidInstanceHandler<TCriteria>.ValueType) 
                                                   : nameof(InvalidInstanceHandler<TCriteria>.ReferenceType);

        var methodInfo = typeof(InvalidInstanceHandler<TCriteria>).GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic)!
                                                                  .MakeGenericMethod(typeof(THost));

        var methodcall = Expression.Call(methodInfo, parameterExpression);

        return Expression.Block(methodcall, memberExpression);
    }
}