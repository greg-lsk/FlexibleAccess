using FlexibleAccess._Internals.ResolutionDelegateBuilders;


namespace FlexibleAccess;

public struct ActionSelector<THost, TCriteria> where TCriteria : struct, IResolutionCriteria
{
    public readonly IResolution<THost, TTarget, TCriteria> GetValueOf<TTarget>() => 
        ResolutionBuilder<THost, TTarget, TCriteria>.ForValueResolution();

    public readonly IResolution<THost, string, TCriteria> GetNameOf<TTarget>() => 
        ResolutionBuilder<THost, TTarget, TCriteria>.ForNameResolution();
}