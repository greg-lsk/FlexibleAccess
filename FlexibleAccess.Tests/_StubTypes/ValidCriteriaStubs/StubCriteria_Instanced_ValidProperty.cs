using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes.ValidCriteriaStubs;

internal readonly struct StubCriteria_Instanced_ValidProperty : IResolutionCriteria
{
    public string Identifier => StubPrimitives.IdentifierFor_InternalInstance_StubProperty_Valid;
    public MemberKind MemberKind => MemberKind.Property;

    public BindingFlags BindingFlags => StubPrimitives.Flag_NonPublic_Instance;
}