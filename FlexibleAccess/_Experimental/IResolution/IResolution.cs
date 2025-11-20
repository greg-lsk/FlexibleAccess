namespace FlexibleAccess._Experimental.IResolution;

public interface IResolution<THost, TResult>
{
    public TResult Invoke(THost? host = default);
}