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
        var resolver = ResolutionOn<TStubHost>.Using<StubCriteria_Static_ValidField>()
                                              .GetValueOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(accessor.InternalStatic_StubField, resolver.Invoke());
    }

    [Fact]
    internal void NameOfStaticField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>();
        var resolver = ResolutionOn<TStubHost>.Using<StubCriteria_Static_ValidField>()
                                              .GetNameOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(nameof(accessor.InternalStatic_StubField), resolver.Invoke());
    }

    [Fact]
    internal void ValueOfInstancedField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>();
        var resolver = ResolutionOn<TStubHost>.Using<StubCriteria_Instanced_ValidField>()
                                              .GetValueOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(accessor.InternalInstance_StubField, resolver.Invoke((TStubHost)host));
    }

    [Fact]
    internal void NameOfInstancedField_ResolverReturns_Expected_OnValidCriteria()
    {
        var host = StubHostFactory.Create<TStubHost>(); ;
        var resolver = ResolutionOn<TStubHost>.Using<StubCriteria_Instanced_ValidField>()
                                              .GetNameOf<string>();

        var accessor = new AccessorWrapper<TStubHost>((TStubHost)host);

        Assert.Equal(nameof(accessor.InternalInstance_StubField), resolver.Invoke((TStubHost)host));
    }
}