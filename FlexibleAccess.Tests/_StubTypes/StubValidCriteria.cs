using System.Reflection;


namespace FlexibleAccess.Tests._StubTypes;

internal readonly struct StubValidCriteria : IResolutionCriteria
{
    public string Identifier => nameof(StubHost.StubPropertyName);
    public BindingFlags BindingFlags => StubPrimitives.StubBindingFlags;
}