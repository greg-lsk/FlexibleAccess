using System.Reflection;
using FlexibleAccess.Exceptions;
using FlexibleAccess._Internals.InvalidInstanceHandling;


namespace FlexibleAccess._Internals.ReflectionHandling;

internal static class ReflectionHandler
{
    internal static MemberInfo TryGetMemberInfo<THost, TTarget, TCriteria>() 
        where TCriteria : struct, IResolutionCriteria
    {
        var criteria = new TCriteria();
        var getMemberInfo = GetMemberInfoLogic.For<THost>(criteria.MemberKind);

        return getMemberInfo(criteria.Identifier, criteria.BindingFlags)
        ?? throw new UnableToResolveException<THost, TTarget>(criteria.Identifier, criteria.BindingFlags);
    }

    internal static MethodInfo InvalidInstanceHandler<THost, TCriteria>() 
        where TCriteria : struct, IResolutionCriteria
    {
        var methodName = typeof(THost).IsValueType ? nameof(InvalidInstanceHandler<TCriteria>.ValueType)
                                                   : nameof(InvalidInstanceHandler<TCriteria>.ReferenceType);

        return typeof(InvalidInstanceHandler<TCriteria>).GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic)!
                                                        .MakeGenericMethod(typeof(THost));
    }
}