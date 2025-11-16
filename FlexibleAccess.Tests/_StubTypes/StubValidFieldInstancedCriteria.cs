using System.Reflection;

namespace FlexibleAccess.Tests._StubTypes;

internal readonly struct StubValidFieldInstancedCriteria : IResolutionCriteria
{
    public string Identifier => nameof(StubHost.StubName);
    public MemberKind MemberKind => MemberKind.Field;

    public BindingFlags BindingFlags => BindingFlags.NonPublic | BindingFlags.Instance;
}