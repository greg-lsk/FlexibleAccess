namespace FlexibleAccess.Tests._StubTypes.StubHost;

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