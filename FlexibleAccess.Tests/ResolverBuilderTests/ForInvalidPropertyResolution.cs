using FlexibleAccess.Exceptions;
using FlexibleAccess.Tests._StubTypes.StubHost;
using FlexibleAccess.Tests._StubTypes.InvalidCriteriaStub;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForInvalidPropertyResolution_OnStruct : ForInvalidPropertyResolution<StubHost_Struct>;
public class ForInvalidPropertyResolution_OnConcreteClass : ForInvalidPropertyResolution<StubHost_ConcreteClass>;

public abstract class ForInvalidPropertyResolution<TStubHost> where TStubHost : IStubHostMarked
{
    [Fact]
    internal void ValueOfStaticProperty_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<TStubHost, string>>
        (
            () => ResolutionOn<TStubHost>.Using<StubCriteria_Static_InvalidProperty>()
                                         .GetValueOf<string>()
        );
    }

    [Fact]
    internal void NameOfStaticProperty_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<TStubHost, string>>
        (
            () => ResolutionOn<TStubHost>.Using<StubCriteria_Static_InvalidProperty>()
                                         .GetNameOf<string>()
        );
    }

    [Fact]
    internal void ValueOfInstancedProperty_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<TStubHost, string>>
        (
            () => ResolutionOn<TStubHost>.Using<StubCriteria_Instanced_InvalidProperty>()
                                         .GetValueOf<string>()
        );
    }

    [Fact]
    internal void NameOfInstancedProperty_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<TStubHost, string>>
        (
            () => ResolutionOn<TStubHost>.Using<StubCriteria_Instanced_InvalidProperty>()
                                         .GetNameOf<string>()
        );
    }
}