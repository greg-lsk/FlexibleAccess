using System.Reflection;


namespace FlexibleAccess._Internals.ResolutionCriteriaProcessing;

internal static class CriteriaProcessor<TCriteria> where TCriteria : struct, IResolutionCriteria
{
    internal static bool IndicatesOnTypeResolution() 
    {
        return (new TCriteria().BindingFlags & BindingFlags.Static) == BindingFlags.Static;
    }

    internal static bool IndicatesOnInstanceResolution()
    {
        return (new TCriteria().BindingFlags & BindingFlags.Instance) == BindingFlags.Instance;
    }
}