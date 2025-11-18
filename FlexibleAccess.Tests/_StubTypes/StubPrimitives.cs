using System.Reflection;
using FlexibleAccess.Tests._StubTypes.StubHost;

namespace FlexibleAccess.Tests._StubTypes;


internal enum StubEnum
{
    stubEnumValue01,
    stubEnumValue02,
    stubEnumValue03
}

internal static class StubPrimitives
{
    internal const string InternalStatic_StubField_Value = "InternalStatic_StubField_Value";
    internal const string InternalInstance_StubField_Value = "InternalInstance_StubField_Value";

    internal const string IdentifierFor_InternalStatic_StubField_Valid = nameof(StubHost_ConcreteClass.InternalStatic_StubField);
    internal const string IdentifierFor_InternalStatic_StubProperty_Valid = nameof(StubHost_ConcreteClass.InternalStatic_StubProperty);
    internal const string IdentifierFor_InternalInstance_StubField_Valid = nameof(StubHost_ConcreteClass.InternalInstance_StubField);
    internal const string IdentifierFor_InternalInstance_StubProperty_Valid = nameof(StubHost_ConcreteClass.InternalInstance_StubProperty);

    internal const string IdentifierFor_InternalStatic_StubField_Invalid = nameof(StubHost_ConcreteClass.InternalStatic_StubField) + "invalid";
    internal const string IdentifierFor_InternalStatic_StubProperty_Invalid = nameof(StubHost_ConcreteClass.InternalStatic_StubProperty) + "invalid";
    internal const string IdentifierFor_InternalInstance_StubField_Invalid = nameof(StubHost_ConcreteClass.InternalInstance_StubField) + "invalid";
    internal const string IdentifierFor_InternalInstance_StubProperty_Invalid = nameof(StubHost_ConcreteClass.InternalInstance_StubProperty) + "invalid";

    internal const BindingFlags Flag_NonPublic_Static = BindingFlags.NonPublic | BindingFlags.Static;
    internal const BindingFlags Flag_NonPublic_Instance = BindingFlags.NonPublic | BindingFlags.Instance;

    internal const int StubEnum_InvalidValue = 50;
    internal const int MemberKindEnum_InvalidValue = 9990;
}