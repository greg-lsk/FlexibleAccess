using FlexibleAccess._Internals.ResolutionDelegateBuilders;


namespace FlexibleAccess;

public struct ActionSelector<THost, TCriteria> where TCriteria : struct, IResolutionCriteria
{
    public readonly Resolution<THost, TTarget, TCriteria> GetValueOf<TTarget>() => new
    (
        ResolutionDelegateBuilder<THost, TTarget, TCriteria>.ValueOfResolution<Func<THost?, TTarget>>()
    );

    public readonly Resolution<THost, string, TCriteria> GetNameOf<TTarget>() => new
    (
        ResolutionDelegateBuilder<THost, TTarget, TCriteria>.NameOfResolution<Func<THost?, string>>()
    );
}