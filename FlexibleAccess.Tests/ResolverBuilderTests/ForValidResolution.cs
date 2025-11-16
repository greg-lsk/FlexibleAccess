using FlexibleAccess.Tests._StubTypes;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForValidResolution
{
    [Fact]
    internal void ValueOf_ResolverReturns_ExpectedPropertyValue_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubValidCriteria>.ValueOf<string>();

        Assert.Equal(StubHost.StubPropertyName, resolver());
    }

    [Fact]
    internal void NameOf_ResolverReturns_ExpectedNameOfProperty_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubValidCriteria>.NameOf<string>();

        Assert.Equal(nameof(StubHost.StubPropertyName), resolver());
    }
}
