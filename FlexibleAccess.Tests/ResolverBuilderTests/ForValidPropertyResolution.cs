using FlexibleAccess.Tests._StubTypes.StubHost;
using FlexibleAccess.Tests._StubTypes.ValidCriteriaStubs;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForValidPropertyResolution_OnStruct : ForValidPropertyResolution<StubHost_Struct>;
public class ForValidPropertyResolution_OnConcreteClass : ForValidPropertyResolution<StubHost_ConcreteClass>;

public abstract class ForValidPropertyResolution<TStubHost> where TStubHost : IStubHostMarked
{
    [Fact]
    internal void ValueOfStaticProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>();
        var resolver = ResolutionOn<TStubHost>.Using<StubCriteria_Static_ValidProperty>()
                                              .GetValueOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(accessor.InternalStatic_StubProperty, resolver.Invoke());
    }

    [Fact]
    internal void NameOfStaticProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>();
        var resolver = ResolutionOn<TStubHost>.Using<StubCriteria_Static_ValidProperty>()
                                              .GetNameOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(nameof(accessor.InternalStatic_StubProperty), resolver.Invoke());
    }

    [Fact]
    internal void ValueOfInstancedProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>();
        var resolver = ResolutionOn<TStubHost>.Using<StubCriteria_Instanced_ValidProperty>()
                                              .GetValueOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(accessor.InternalInstance_StubProperty, resolver.Invoke((TStubHost)host));
    }

    [Fact]
    internal void NameOfInstancedProperty_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>();
        var resolver = ResolutionOn<TStubHost>.Using<StubCriteria_Instanced_ValidProperty>()
                                              .GetNameOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(nameof(accessor.InternalInstance_StubProperty), resolver.Invoke((TStubHost)host));
    }
}