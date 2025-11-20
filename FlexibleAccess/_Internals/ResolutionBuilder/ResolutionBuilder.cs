using FlexibleAccess._Internals.ExpressionHandling;
using FlexibleAccess._Internals.ReflectionHandling;


namespace FlexibleAccess._Internals.ResolutionDelegateBuilders;

internal static class ResolutionBuilder<THost, TTarget, TCriteria>
    where TCriteria : struct, IResolutionCriteria
{
    internal static IResolution<THost, TTarget, TCriteria> ForValueResolution()
    {
        var memberInfo = ReflectionHandler.TryGetMemberInfo<THost, TTarget, TCriteria>();
        var delegateParameter = ExpressionHandler.ResolutionDelegateParameter<THost>();

        var memberAccess = ExpressionHandler.MemberAccess<TCriteria>(delegateParameter, memberInfo);

        var resolutionType = ReflectionHandler.GetResolutionType<THost, TTarget, TCriteria>();
        var resolutionDelegate = ExpressionHandler.GetCompiledLambda<Func<THost, TTarget>>(memberAccess, delegateParameter);

        var resolution = ReflectionHandler.GetResolutionInstance(resolutionType, resolutionDelegate);
        return (IResolution<THost, TTarget, TCriteria>) resolution;
    }

    internal static IResolution<THost, string, TCriteria> ForNameResolution() 
    {
        var memberInfo = ReflectionHandler.TryGetMemberInfo<THost, TTarget, TCriteria>();
        var delegateParameter = ExpressionHandler.ResolutionDelegateParameter<THost>();

        var memberName = ExpressionHandler.MemberName(memberInfo);

        var resolutionType = ReflectionHandler.GetResolutionType<THost, string, TCriteria>();
        var resolutionDelegate = ExpressionHandler.GetCompiledLambda<Func<THost, string>>(memberName, delegateParameter);

        var resolution = ReflectionHandler.GetResolutionInstance(resolutionType, resolutionDelegate);
        return (IResolution<THost, string, TCriteria>) resolution;
    }
}