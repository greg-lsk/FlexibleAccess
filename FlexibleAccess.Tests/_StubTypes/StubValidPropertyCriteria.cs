using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes;

internal readonly struct StubValidPropertyCriteria : IResolutionCriteria
{
    public string Identifier => nameof(StubHost.StubPropertyName);
    public MemberKind MemberKind => MemberKind.Property;

    public BindingFlags BindingFlags => StubPrimitives.StubBindingFlags;
}