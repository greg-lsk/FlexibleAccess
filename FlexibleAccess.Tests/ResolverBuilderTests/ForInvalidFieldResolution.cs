using FlexibleAccess.Exceptions;
using FlexibleAccess.Tests._StubTypes;
using FlexibleAccess.Tests._StubTypes.InvalidCriteriaStub;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForInvalidFieldResolution
{
    [Fact]
    internal void ValueOfStaticField_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(
            () => ResolverBuilder<StubHost, StubCriteria_Static_InvalidField>.ValueOf<string>());
    }

    [Fact]
    internal void NameOfStaticField_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(
            () => ResolverBuilder<StubHost, StubCriteria_Static_InvalidField>.NameOf<string>());
    }

    [Fact]
    internal void ValueOfInstancedField_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(
            () => ResolverBuilder<StubHost, StubCriteria_Instanced_InvalidField>.ValueOf<string>());
    }

    [Fact]
    internal void NameOfInstancedField_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(
            () => ResolverBuilder<StubHost, StubCriteria_Instanced_InvalidField>.NameOf<string>());
    }
}