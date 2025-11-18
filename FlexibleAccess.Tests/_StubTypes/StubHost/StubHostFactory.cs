namespace FlexibleAccess.Tests._StubTypes.StubHost;

internal static class StubHostFactory
{
    internal static IStubHostMarked Create<T>() where T : IStubHostMarked => typeof(T) switch
    {
        Type t when t == typeof(StubHost_Struct) => new StubHost_Struct(),
        Type t when t == typeof(StubHost_ConcreteClass) => new StubHost_ConcreteClass(),
        _ => throw new InvalidOperationException($"{nameof(StubHostFactory)} can't operate on {typeof(T)}")
    };
}