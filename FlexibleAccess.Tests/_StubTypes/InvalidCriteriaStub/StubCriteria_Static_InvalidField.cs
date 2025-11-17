using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes.InvalidCriteriaStub;

internal readonly struct StubCriteria_Static_InvalidField : IResolutionCriteria
{
    public string Identifier => StubPrimitives.IdentifierFor_InternalStatic_StubField_Invalid;
    public MemberKind MemberKind => MemberKind.Field;

    public BindingFlags BindingFlags => StubPrimitives.Flag_NonPublic_Static;
}