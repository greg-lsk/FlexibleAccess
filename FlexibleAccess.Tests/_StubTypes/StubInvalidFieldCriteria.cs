using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes;

internal readonly struct StubInvalidFieldCriteria : IResolutionCriteria
{
    public string Identifier => StubPrimitives.InvalidPropertyNameForStubHost;
    public MemberKind MemberKind => MemberKind.Field;

    public BindingFlags BindingFlags => StubPrimitives.StubBindingFlags;
}