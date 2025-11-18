using FlexibleAccess.Exceptions;
using FlexibleAccess.Tests._StubTypes;
using FlexibleAccess.Tests._StubTypes.InvalidCriteriaStub;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForInvalidFieldResolution_OnStruct : ForInvalidFieldResolution<StubHost_Struct> { }
public class ForInvalidFieldResolution_OnConcreteClass : ForInvalidFieldResolution<StubHost_ConcreteClass> { }

public abstract class ForInvalidFieldResolution<TStubHost> where TStubHost : IStubHostMarked
{
    [Fact]
    internal void ValueOfStaticField_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<TStubHost, string>>(
            () => ResolverBuilder<TStubHost, StubCriteria_Static_InvalidField>.ValueOf<string>());
    }

    [Fact]
    internal void NameOfStaticField_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<TStubHost, string>>(
            () => ResolverBuilder<TStubHost, StubCriteria_Static_InvalidField>.NameOf<string>());
    }

    [Fact]
    internal void ValueOfInstancedField_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<TStubHost, string>>(
            () => ResolverBuilder<TStubHost, StubCriteria_Instanced_InvalidField>.ValueOf<string>());
    }

    [Fact]
    internal void NameOfInstancedField_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<TStubHost, string>>(
            () => ResolverBuilder<TStubHost, StubCriteria_Instanced_InvalidField>.NameOf<string>());
    }
}