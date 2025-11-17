using FlexibleAccess.Tests._StubTypes;
using FlexibleAccess.Tests._StubTypes.ValidCriteriaStubs;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForValidFieldResolution
{
    [Fact]
    internal void ValueOfField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_Static_ValidField>.ValueOf<string>();

        Assert.Equal(StubHost.InternalStatic_StubField, resolver());
    }

    [Fact]
    internal void NameOfField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_Static_ValidField>.NameOf<string>();

        Assert.Equal(nameof(StubHost.InternalStatic_StubField), resolver());
    }

    [Fact]
    internal void ValueOfInstancedField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_Instanced_ValidField>.ValueOf<string>();

        Assert.Equal(host.InternalInstance_StubField, resolver(host));
    }

    [Fact]
    internal void NameOfInstancedField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = new StubHost();
        var resolver = ResolverBuilder<StubHost, StubCriteria_Instanced_ValidField>.NameOf<string>();

        Assert.Equal(nameof(StubHost.InternalInstance_StubField), resolver(host));
    }
}