namespace FlexibleAccess.Resolution;

internal abstract class ResolutionBase<THost, TResult>(Func<THost, TResult>? resolution)
{
    protected Func<THost, TResult> Resolution { get; } = resolution ?? throw new Exception("Trying to assign null Resolution-Action");
}