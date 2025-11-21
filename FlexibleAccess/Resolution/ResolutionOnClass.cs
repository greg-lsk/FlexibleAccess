using FlexibleAccess.Exceptions;
using FlexibleAccess._Internals.ResolutionCriteriaProcessing;


namespace FlexibleAccess.Resolution;

internal class ResolutionOnClass<THost, TResult, TCriteria>
    (Func<THost?, TResult>? resolution) : ResolutionBase<THost?, TResult>(resolution),
                                         IResolution<THost, TResult, TCriteria>
    where THost : class
    where TCriteria : struct, IResolutionCriteria
{
    public TResult Invoke(THost host) => Resolution(host);

    public TResult Invoke()
    {
        if (CriteriaProcessor<TCriteria>.IndicatesInstancedResolution())
            throw new MissingInstanceException<THost, TCriteria>();

        return Resolution(null);
    }
}