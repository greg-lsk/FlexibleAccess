namespace FlexibleAccess.Tests._StubTypes;

internal class StubHost
{
    internal readonly static string InternalStatic_StubField = StubPrimitives.InternalStatic_StubField_Value;
    internal static string InternalStatic_StubProperty => InternalStatic_StubField;


    internal readonly string InternalInstance_StubField = StubPrimitives.InternalInstance_StubField_Value;
}