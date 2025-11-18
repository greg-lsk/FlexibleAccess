namespace FlexibleAccess.Tests._StubTypes;


public interface IStubHostMarked;

public class StubHost_ConcreteClass : IStubHostMarked
{
    internal readonly static string InternalStatic_StubField = StubPrimitives.InternalStatic_StubField_Value;
    internal static string InternalStatic_StubProperty => InternalStatic_StubField;


    internal readonly string InternalInstance_StubField = StubPrimitives.InternalInstance_StubField_Value;
    internal string InternalInstance_StubProperty => InternalInstance_StubField;
}

public readonly struct StubHost_Struct : IStubHostMarked
{
    internal readonly static string InternalStatic_StubField = StubPrimitives.InternalStatic_StubField_Value;
    internal static string InternalStatic_StubProperty => InternalStatic_StubField;


    internal readonly string InternalInstance_StubField = StubPrimitives.InternalInstance_StubField_Value;
    internal string InternalInstance_StubProperty => InternalInstance_StubField;

    public StubHost_Struct() { }
}

internal static class StubHostFactory
{
    internal static IStubHostMarked Create<T>() where T : IStubHostMarked => typeof(T) switch
    {
        Type t when t == typeof(StubHost_Struct) => new StubHost_Struct(),
        Type t when t == typeof(StubHost_ConcreteClass) => new StubHost_ConcreteClass(),
        _ => throw new InvalidOperationException($"{nameof(StubHostFactory)} can't operate on {typeof(T)}")
    };
}


public class AccessorWrapper<TStubHost>(TStubHost stubHost) where TStubHost : IStubHostMarked
{
    private readonly TStubHost _stubHost = stubHost;

    public string InternalStatic_StubField => _stubHost switch
    {
        StubHost_ConcreteClass => StubHost_ConcreteClass.InternalStatic_StubField,
        StubHost_Struct => StubHost_Struct.InternalStatic_StubField,
        _ => throw new InvalidOperationException($"UnsupportedType")
    };

    public string InternalStatic_StubProperty => _stubHost switch
    {
        StubHost_ConcreteClass => StubHost_ConcreteClass.InternalStatic_StubProperty,
        StubHost_Struct => StubHost_Struct.InternalStatic_StubProperty,
        _ => throw new InvalidOperationException($"UnsupportedType")
    };

    public string InternalInstance_StubField => _stubHost switch
    {
        StubHost_ConcreteClass concreteClass => concreteClass.InternalInstance_StubField,
        StubHost_Struct valueType => valueType.InternalInstance_StubField,
        _ => throw new InvalidOperationException($"UnsupportedType")
    };

    public string InternalInstance_StubProperty => _stubHost switch
    {
        StubHost_ConcreteClass concreteClass => concreteClass.InternalInstance_StubProperty,
        StubHost_Struct valueType => valueType.InternalInstance_StubProperty,
        _ => throw new InvalidOperationException($"UnsupportedType")
    };
}