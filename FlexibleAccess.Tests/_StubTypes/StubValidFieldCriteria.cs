using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes;

internal readonly struct StubValidFieldCriteria : IResolutionCriteria
{
    public string Identifier => nameof(StubHost.stubPrivateString);
    public MemberKind MemberKind => MemberKind.Field;

    public BindingFlags BindingFlags => StubPrimitives.StubBindingFlags;
}
