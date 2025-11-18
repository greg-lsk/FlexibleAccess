using FlexibleAccess.Tests._StubTypes.StubHost;
using FlexibleAccess.Tests._StubTypes.ValidCriteriaStubs;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForValidFieldResolution_OnStruct : ForValidFieldResolution<StubHost_Struct>;
public class ForValidFieldResolution_OnConcreteClass : ForValidFieldResolution<StubHost_ConcreteClass>;

public abstract class ForValidFieldResolution<TStubHost> where TStubHost : IStubHostMarked
{
    [Fact]
    internal void ValueOfStaticField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>();
        var resolver = ResolverBuilder<TStubHost, StubCriteria_Static_ValidField>.ValueOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(accessor.InternalStatic_StubField, resolver());
    }

    [Fact]
    internal void NameOfStaticField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>();
        var resolver = ResolverBuilder<TStubHost, StubCriteria_Static_ValidField>.NameOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(nameof(accessor.InternalStatic_StubField), resolver());
    }

    [Fact]
    internal void ValueOfInstancedField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>();
        var resolver = ResolverBuilder<TStubHost, StubCriteria_Instanced_ValidField>.ValueOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(accessor.InternalInstance_StubField, resolver((TStubHost)host));
    }

    [Fact]
    internal void NameOfInstancedField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>(); ;
        var resolver = ResolverBuilder<TStubHost, StubCriteria_Instanced_ValidField>.NameOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(nameof(accessor.InternalInstance_StubField), resolver((TStubHost)host));
    }
}