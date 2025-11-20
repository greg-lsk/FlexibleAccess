namespace FlexibleAccess._Experimental.IResolution;

internal class ResolutionOnClass<THost, TResult> : IResolution<THost?, TResult>
    where THost : class
{
    private readonly ResolveOnClass<THost, TResult> _resolution;

    internal ResolutionOnClass(ResolveOnClass<THost, TResult> resolution) => _resolution = resolution;

    public TResult Invoke(THost? host = default) => _resolution(host);
}