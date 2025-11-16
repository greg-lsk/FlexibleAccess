using FlexibleAccess.Exceptions;
using FlexibleAccess.Tests._StubTypes;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForInvalidResolution
{
    [Fact]
    internal void ValueOfProperty_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(ResolverBuilder<StubHost, StubInvalidPropertyCriteria>.ValueOf<string>);
    }

    [Fact]
    internal void NameOfProperty_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(ResolverBuilder<StubHost, StubInvalidPropertyCriteria>.NameOf<string>);
    }

    [Fact]
    internal void ValueOfField_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(ResolverBuilder<StubHost, StubInvalidFieldCriteria>.ValueOf<string>);
    }

    [Fact]
    internal void NameOfField_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(ResolverBuilder<StubHost, StubInvalidFieldCriteria>.NameOf<string>);
    }
}