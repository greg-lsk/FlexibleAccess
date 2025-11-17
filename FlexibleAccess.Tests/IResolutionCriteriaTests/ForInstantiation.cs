using FlexibleAccess.Tests._StubTypes;


namespace FlexibleAccess.Tests.IResolutionCriteriaTests;

public class ForInstantiation
{
    [Fact]
    public void Struct_ReturnsCorrectCriteria_OnDefaultInit()
    {
        var stubCriteria = new StubValidPropertyCriteria();

        var expectedPropertyName = nameof(StubHost.InternalStatic_StubProperty);
        var expectedBindingFlags = StubPrimitives.Flag_NonPublic_Static;

        Assert.Equal(expectedPropertyName, stubCriteria.Identifier);
        Assert.Equal(expectedBindingFlags, stubCriteria.BindingFlags);
    }
}