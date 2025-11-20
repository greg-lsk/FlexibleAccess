namespace FlexibleAccess;

public struct ResolutionOn<THost>
{
    public static ActionSelector<THost, TCriteria> Using<TCriteria>()
        where TCriteria : struct, IResolutionCriteria
    {
        return new();
    }
}