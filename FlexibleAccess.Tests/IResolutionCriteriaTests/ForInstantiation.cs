using FlexibleAccess.Tests._StubTypes;


namespace FlexibleAccess.Tests.IResolutionCriteriaTests;

public class ForInstantiation
{
    [Fact]
    public void Struct_ReturnsCorrectCriteria_OnDefaultInit()
    {
        var stubCriteria = new StubValidCriteria();

        var expectedPropertyName = nameof(StubHost.StubPropertyName);
        var expectedBindingFlags = StubPrimitives.StubBindingFlags;

        Assert.Equal(expectedPropertyName, stubCriteria.Identifier);
        Assert.Equal(expectedBindingFlags, stubCriteria.BindingFlags);
    }
}