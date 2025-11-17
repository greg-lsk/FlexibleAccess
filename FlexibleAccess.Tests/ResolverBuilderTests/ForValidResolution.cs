using FlexibleAccess.Tests._StubTypes;
using FlexibleAccess.Tests._StubTypes.ValidCriteriaStubs;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForValidResolution
{
    [Fact]
    internal void ValueOfProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_ValidProperty>.ValueOf<string>();

        Assert.Equal(StubHost.InternalStatic_StubProperty, resolver());
    }

    [Fact]
    internal void NameOfProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_ValidProperty>.NameOf<string>();

        Assert.Equal(nameof(StubHost.InternalStatic_StubProperty), resolver());
    }

    [Fact]
    internal void ValueOfField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_ForValidField>.ValueOf<string>();

        Assert.Equal(StubHost.InternalStatic_StubField, resolver());
    }

    [Fact]
    internal void NameOfField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_ForValidField>.NameOf<string>();

        Assert.Equal(nameof(StubHost.InternalStatic_StubField), resolver());
    }

    [Fact]
    internal void ValueOfInstancedField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_Instanced_ValidField>.ValueOf<string>();

        Assert.Equal(host.StubName, resolver(host));
    }

    [Fact]
    internal void NameOfInstancedField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_Instanced_ValidField>.NameOf<string>();

        Assert.Equal(nameof(StubHost.StubName), resolver(host));
    }
}