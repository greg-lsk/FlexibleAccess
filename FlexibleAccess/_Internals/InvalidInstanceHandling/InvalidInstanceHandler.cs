using FlexibleAccess.Exceptions;


namespace FlexibleAccess._Internals.InvalidInstanceHandling;

internal static class InvalidInstanceHandler<TCriteria> where TCriteria : struct, IResolutionCriteria
{
    internal static void ValueType<TInstance>(TInstance? instance = default) where TInstance : struct
    {
        if (!instance.HasValue) throw new MissingInstanceAtRuntimeException<TInstance, TCriteria>();
    }

    internal static void ReferenceType<TInstance>(TInstance? instance = default) where TInstance : class
    {
        if (instance is null) throw new MissingInstanceAtRuntimeException<TInstance, TCriteria>();
    }
}