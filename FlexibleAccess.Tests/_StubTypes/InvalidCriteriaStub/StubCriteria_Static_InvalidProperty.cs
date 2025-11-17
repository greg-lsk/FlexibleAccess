using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes.InvalidCriteriaStub;

internal readonly struct StubCriteria_Static_InvalidProperty : IResolutionCriteria
{
    public string Identifier => StubPrimitives.IdentifierFor_InternalStatic_StubProperty_Invalid;
    public MemberKind MemberKind => MemberKind.Property;

    public BindingFlags BindingFlags => StubPrimitives.Flag_NonPublic_Static;
}