using FlexibleAccess.Exceptions;
using FlexibleAccess._Internals.ResolutionCriteriaProcessing;


namespace FlexibleAccess;

public readonly struct Resolution<THost, TResult, TCriteria>(Func<THost?, TResult>? resolution = default)
    where TCriteria : struct, IResolutionCriteria
{
    private readonly Func<THost?, TResult>? _resolution = resolution;

    public bool IsInstanced => CriteriaProcessor<TCriteria>.IndicatesInstancedResolution();

    public TResult Invoke(THost? host = default)
    {
        if (_resolution is null) throw new Exception("resolution action not set");
        if (IsInstanced && host is null) throw new MissingInstanceAtRuntimeException<THost, TCriteria>();

        return _resolution(host);
    }
}