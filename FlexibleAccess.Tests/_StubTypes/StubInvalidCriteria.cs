using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes;

internal readonly struct StubInvalidCriteria : IResolutionCriteria
{
    public string Identifier => StubPrimitives.InvalidPropertyNameForStubHost;
    public BindingFlags BindingFlags => StubPrimitives.StubBindingFlags;
}