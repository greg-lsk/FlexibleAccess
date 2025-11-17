using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes.ValidCriteriaStubs;

internal readonly struct StubCriteria_ForValidField : IResolutionCriteria
{
    public string Identifier => StubPrimitives.IdentifierFor_InternalStatic_StubField_Valid;
    public MemberKind MemberKind => MemberKind.Field;

    public BindingFlags BindingFlags => StubPrimitives.Flag_NonPublic_Static;
}