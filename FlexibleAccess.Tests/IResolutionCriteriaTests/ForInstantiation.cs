using FlexibleAccess.Tests._StubTypes;
using FlexibleAccess.Tests._StubTypes.ValidCriteriaStubs;


namespace FlexibleAccess.Tests.IResolutionCriteriaTests;

public class ForInstantiation
{
    [Fact]
    public void Struct_ReturnsCorrectCriteria_OnDefaultInit()
    {
        var stubCriteria = new StubCriteria_Static_ValidProperty();

        var expectedPropertyName = StubPrimitives.IdentifierFor_InternalStatic_StubProperty_Valid;
        var expectedBindingFlags = StubPrimitives.Flag_NonPublic_Static;

        Assert.Equal(expectedPropertyName, stubCriteria.Identifier);
        Assert.Equal(expectedBindingFlags, stubCriteria.BindingFlags);
    }
}