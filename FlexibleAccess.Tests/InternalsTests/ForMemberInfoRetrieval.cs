using FlexibleAccess.Exceptions;
using FlexibleAccess.Tests._StubTypes;
using FlexibleAccess._Internals.MemberInfoRetrieval;


namespace FlexibleAccess.Tests.InternalsTests;

public class ForMemberInfoRetrieval
{
    [Fact]
    internal void ReturnsCorrectMethod_WhenProvidedWith_MemberKind_PropertyValue()
    {
        var kind = MemberKind.Property;
        var expectedLogic = "GetProperty";
        var calculatedRetievalLogic = MemberInfoRetrievalLogic.For<StubHost_ConcreteClass>(kind);

        Assert.Equal(expectedLogic, calculatedRetievalLogic.Method.Name);
    }

    [Fact]
    internal void ReturnsCorrectMethod_WhenProvidedWith_MemberKind_InfoValue()
    {
        var kind = MemberKind.Field;
        var expectedLogic = "GetField";
        var calculatedRetievalLogic = MemberInfoRetrievalLogic.For<StubHost_ConcreteClass>(kind);

        Assert.Equal(expectedLogic, calculatedRetievalLogic.Method.Name);
    }

    [Fact]
    internal void Throws_WhenProvidedWith_InvalidMemberKind_Value()
    {
        Assert.Throws<InvalidEnumValueException<MemberKind>>
        (
            () => MemberInfoRetrievalLogic.For<StubHost_ConcreteClass>((MemberKind)StubPrimitives.MemberKindEnum_InvalidValue)
        );
    }
}