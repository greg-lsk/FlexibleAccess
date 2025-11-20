using System.Reflection;


namespace FlexibleAccess._Internals.ResolutionCriteriaProcessing;

internal static class CriteriaProcessor<TCriteria> where TCriteria : struct, IResolutionCriteria
{
    internal static bool IndicatesStaticResolution() 
    {
        return (new TCriteria().BindingFlags & BindingFlags.Static) == BindingFlags.Static;
    }

    internal static bool IndicatesInstancedResolution()
    {
        return (new TCriteria().BindingFlags & BindingFlags.Instance) == BindingFlags.Instance;
    }
}