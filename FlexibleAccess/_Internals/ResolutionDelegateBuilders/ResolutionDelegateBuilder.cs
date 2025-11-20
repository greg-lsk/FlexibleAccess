using FlexibleAccess._Internals.ExpressionHandling;
using FlexibleAccess._Internals.ReflectionHandling;


namespace FlexibleAccess._Internals.ResolutionDelegateBuilders;

internal static class ResolutionDelegateBuilder<THost, TTarget, TCriteria>
    where TCriteria : struct, IResolutionCriteria
{
    internal static TResolution ValueOfResolution<TResolution>() 
        where TResolution : class, IResolution<THost, TTarget, TCriteria>
    {
        var memberInfo = ReflectionHandler.TryGetMemberInfo<THost, TTarget, TCriteria>();
        var delegateParameter = ExpressionHandler.ResolutionDelegateParameter<THost>();

        var memberAccess = ExpressionHandler.MemberAccess<THost, TCriteria>(delegateParameter, memberInfo);

        var resolutionType = ReflectionHandler.GetResolutionType<THost, TTarget, TCriteria>();
        var resolutionDelegate = ExpressionHandler.GetCompiledLambda<Func<THost, TTarget>>(memberAccess, delegateParameter);

        var resolution = ReflectionHandler.GetResolutionInstance(resolutionType, resolutionDelegate);
        return (TResolution) resolution;
    }

    internal static TResolution NameOfResolution<TResolution>() 
        where TResolution : class, IResolution<THost, string, TCriteria>
    {
        var memberInfo = ReflectionHandler.TryGetMemberInfo<THost, TTarget, TCriteria>();
        var delegateParameter = ExpressionHandler.ResolutionDelegateParameter<THost>();

        var memberName = ExpressionHandler.MemberName(memberInfo);

        var resolutionType = ReflectionHandler.GetResolutionType<THost, TTarget, TCriteria>();
        var resolutionDelegate = ExpressionHandler.GetCompiledLambda<Func<THost, string>>(memberName, delegateParameter);

        var resolution = ReflectionHandler.GetResolutionInstance(resolutionType, resolutionDelegate);
        return (TResolution)resolution;
    }
}