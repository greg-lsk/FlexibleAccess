using FlexibleAccess.Exceptions;
using FlexibleAccess.Tests._StubTypes;


namespace FlexibleAccess.Tests.ResolverBuilderTests;

public class ForInvalidResolution
{
    [Fact]
    internal void ValueOf_Throws_OnInvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(ResolverBuilder<StubHost, StubInvalidCriteria>.ValueOf<string>);
    }

    [Fact]
    internal void NameOf_Throws_OnIvalidCriteria()
    {
        Assert.Throws<UnableToResolveException<StubHost, string>>(ResolverBuilder<StubHost, StubInvalidCriteria>.NameOf<string>);
    }
}