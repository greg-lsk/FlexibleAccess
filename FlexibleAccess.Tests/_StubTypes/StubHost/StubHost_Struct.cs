namespace FlexibleAccess.Tests._StubTypes.StubHost;

public readonly struct StubHost_Struct : IStubHostMarked
{
    internal readonly static string InternalStatic_StubField = StubPrimitives.InternalStatic_StubField_Value;
    internal static string InternalStatic_StubProperty => InternalStatic_StubField;


    internal readonly string InternalInstance_StubField = StubPrimitives.InternalInstance_StubField_Value;
    internal string InternalInstance_StubProperty => InternalInstance_StubField;

    public StubHost_Struct() { }
}