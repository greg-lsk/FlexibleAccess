using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes.ValidCriteriaStubs;

internal readonly struct StubCriteria_ValidProperty : IResolutionCriteria
{
    public string Identifier => StubPrimitives.IdentifierFor_InternalStatic_StubProperty_Valid;
    public MemberKind MemberKind => MemberKind.Property;

    public BindingFlags BindingFlags => StubPrimitives.Flag_NonPublic_Static;
}