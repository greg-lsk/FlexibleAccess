using FlexibleAccess._Internals.ExpressionHandling;
using FlexibleAccess._Internals.ReflectionHandling;


namespace FlexibleAccess._Internals.ResolutionDelegateBuilders;

internal static class ResolutionDelegateBuilder<THost, TTarget, TCriteria>
    where TCriteria : struct, IResolutionCriteria
{
    internal static TDelegate ValueOfResolution<TDelegate>() 
        where TDelegate : Delegate
    {
        var memberInfo = ReflectionHandler.TryGetMemberInfo<THost, TTarget, TCriteria>();
        var delegateParameter = ExpressionHandler.ResolutionDelegateParameter<THost>();

        var memberAccess = ExpressionHandler.MemberAccess<THost, TCriteria>(delegateParameter, memberInfo);

        return ExpressionHandler.GetCompiledLambda<TDelegate>(memberAccess, delegateParameter);
    }

    internal static TDelegate NameOfResolution<TDelegate>() 
        where TDelegate : Delegate
    {
        var memberInfo = ReflectionHandler.TryGetMemberInfo<THost, TTarget, TCriteria>();
        var delegateParameter = ExpressionHandler.ResolutionDelegateParameter<THost>();

        var memberName = ExpressionHandler.MemberName(memberInfo);

        return ExpressionHandler.GetCompiledLambda<TDelegate>(memberName, delegateParameter);
    }
}