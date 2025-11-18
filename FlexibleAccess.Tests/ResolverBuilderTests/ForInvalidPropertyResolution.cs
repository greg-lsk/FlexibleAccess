using FlexibleAccess.Exceptions;
using FlexibleAccess.Tests._StubTypes;
using FlexibleAccess.Tests._StubTypes.InvalidCriteriaStub;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForInvalidPropertyResolution
{
    [Fact]
    internal void ValueOfStaticProperty_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(
            () => ResolverBuilder<StubHost, StubCriteria_Static_InvalidProperty>.ValueOf<string>());
    }

    [Fact]
    internal void NameOfStaticProperty_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(
            () => ResolverBuilder<StubHost, StubCriteria_Static_InvalidProperty>.NameOf<string>());
    }

    [Fact]
    internal void ValueOfInstancedProperty_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(
            () => ResolverBuilder<StubHost, StubCriteria_Instanced_InvalidProperty>.ValueOf<string>());
    }

    [Fact]
    internal void NameOfInstancedProperty_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(
            () => ResolverBuilder<StubHost, StubCriteria_Instanced_InvalidProperty>.NameOf<string>());
    }
}