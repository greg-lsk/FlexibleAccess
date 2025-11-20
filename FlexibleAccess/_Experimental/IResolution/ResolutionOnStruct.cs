namespace FlexibleAccess._Experimental.IResolution;

internal class ResolutionOnStruct<THost, TResult> : IResolution<THost?, TResult>
    where THost : struct
{
    private readonly ResolveOnStruct<THost, TResult> _resolution;

    internal ResolutionOnStruct(ResolveOnStruct<THost, TResult> resolution) => _resolution = resolution;

    public TResult Invoke(THost? host = default) => _resolution(host);
}