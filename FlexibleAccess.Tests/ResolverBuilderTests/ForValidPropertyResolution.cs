using FlexibleAccess.Tests._StubTypes;
using FlexibleAccess.Tests._StubTypes.ValidCriteriaStubs;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForValidPropertyResolution
{
    [Fact]
    internal void ValueOfStaticProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_Static_ValidProperty>.ValueOf<string>();

        Assert.Equal(StubHost.InternalStatic_StubProperty, resolver());
    }

    [Fact]
    internal void NameOfStaticProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_Static_ValidProperty>.NameOf<string>();

        Assert.Equal(nameof(StubHost.InternalStatic_StubProperty), resolver());
    }

    [Fact]
    internal void ValueOfInstancedProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_Instanced_ValidProperty>.ValueOf<string>();

        Assert.Equal(host.InternalInstance_StubProperty, resolver(host));
    }

    [Fact]
    internal void NameOfInstancedProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_Instanced_ValidProperty>.NameOf<string>();

        Assert.Equal(nameof(host.InternalInstance_StubProperty), resolver(host));
    }
}