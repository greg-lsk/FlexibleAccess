using FlexibleAccess.Tests._StubTypes;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForValidResolution
{
    [Fact]
    internal void ValueOfProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubValidPropertyCriteria>.ValueOf<string>();

        Assert.Equal(StubHost.StubPropertyName, resolver());
    }

    [Fact]
    internal void NameOfProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubValidPropertyCriteria>.NameOf<string>();

        Assert.Equal(nameof(StubHost.StubPropertyName), resolver());
    }

    [Fact]
    internal void ValueOfField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubValidFieldCriteria>.ValueOf<string>();

        Assert.Equal(StubHost.stubPrivateString, resolver());
    }

    [Fact]
    internal void NameOfField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubValidFieldCriteria>.NameOf<string>();

        Assert.Equal(nameof(StubHost.stubPrivateString), resolver());
    }
}
