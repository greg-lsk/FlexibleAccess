using FlexibleAccess._Internals.ResolutionDelegateBuilders;


namespace FlexibleAccess;

public struct ActionSelector<THost, TCriteria> where TCriteria : struct, IResolutionCriteria
{
    public readonly IResolution<THost, TTarget, TCriteria> GetValueOf<TTarget>() => 
        ResolutionDelegateBuilder<THost, TTarget, TCriteria>.ValueOfResolution<IResolution<THost, TTarget, TCriteria>>();

    public readonly IResolution<THost, string, TCriteria> GetNameOf<TTarget>() => 
        ResolutionDelegateBuilder<THost, TTarget, TCriteria>.NameOfResolution<IResolution<THost, string, TCriteria>>();
}