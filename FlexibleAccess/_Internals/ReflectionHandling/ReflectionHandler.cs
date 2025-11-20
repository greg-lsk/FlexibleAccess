using System.Reflection;
using FlexibleAccess.Exceptions;
using FlexibleAccess.Resolution;
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

    internal static Type GetResolutionType<THost, TResult, TCriteria>()
        where TCriteria : struct, IResolutionCriteria
    {
        return typeof(THost).IsValueType switch
        {
            true => typeof(ResolutionOnStruct<,,>).MakeGenericType(typeof(THost), typeof(TResult), typeof(TCriteria)),
            false => typeof(ResolutionOnClass<,,>).MakeGenericType(typeof(THost), typeof(TResult), typeof(TCriteria))
        };
    }

    internal static object GetResolutionInstance<THost, TResult>(Type resolutionType,
                                                                 Func<THost, TResult>? resolutionDelegate)
    {
        var resolutionCtor = resolutionType.GetConstructor
        (
            BindingFlags.Instance | BindingFlags.Public,
            [typeof(Func<THost, TResult>)]
        ) ?? throw new Exception("No suitable ctor found...");

        return resolutionCtor.Invoke([resolutionDelegate]);
    }
}