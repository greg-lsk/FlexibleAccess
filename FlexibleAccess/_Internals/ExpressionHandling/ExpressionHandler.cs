using System.Reflection;
using System.Linq.Expressions;
using FlexibleAccess._Internals.ResolutionCriteriaProcessing;


namespace FlexibleAccess._Internals.ExpressionHandling;

internal static class ExpressionHandler
{
    internal static ConstantExpression MemberName(MemberInfo memberInfo) => Expression.Constant(memberInfo.Name);

    internal static ParameterExpression ResolutionDelegateParameter<THost>() => Expression.Parameter(typeof(THost), "host");

    internal static MemberExpression MemberAccess<THost, TCriteria>(ParameterExpression member, MemberInfo memberInfo)
        where TCriteria : struct, IResolutionCriteria
    {
        return CriteriaProcessor<TCriteria>.IndicatesStaticResolution() switch
        {
            true  => Expression.MakeMemberAccess(null, memberInfo),
            false => Expression.MakeMemberAccess(member, memberInfo)
        };
    }

    internal static TLambda GetCompiledLambda<TLambda>(Expression lambdaBody, ParameterExpression parameter)
        where TLambda : Delegate
    {
        return Expression.Lambda<TLambda>(lambdaBody, parameter).Compile();
    }
}