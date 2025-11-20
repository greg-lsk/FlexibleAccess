namespace FlexibleAccess;

public interface IResolution<THost, TResult, TCriteria>
    where TCriteria : struct, IResolutionCriteria
{
    public TResult Invoke(THost host);
    public TResult Invoke();
}