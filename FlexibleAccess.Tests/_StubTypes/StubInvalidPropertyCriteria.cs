using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes;

internal readonly struct StubInvalidPropertyCriteria : IResolutionCriteria
{
    public string Identifier => StubPrimitives.InvalidPropertyNameForStubHost;
    public MemberKind MemberKind => MemberKind.Property;

    public BindingFlags BindingFlags => StubPrimitives.StubBindingFlags;
}