using FlexibleAccess.Exceptions;
using FlexibleAccess.Tests._StubTypes;
using FlexibleAccess.Tests._StubTypes.StubHost;
using FlexibleAccess._Internals.ReflectionHandling;


namespace FlexibleAccess.Tests.InternalsTests;

public class ForMemberInfoRetrieval
{
    [Fact]
    internal void ReturnsCorrectMethod_WhenProvidedWith_MemberKind_PropertyValue()
    {
        var kind = MemberKind.Property;
        var expectedLogic = "GetProperty";
        var calculatedRetievalLogic = GetMemberInfoLogic.For<StubHost_ConcreteClass>(kind);

        Assert.Equal(expectedLogic, calculatedRetievalLogic.Method.Name);
    }

    [Fact]
    internal void ReturnsCorrectMethod_WhenProvidedWith_MemberKind_InfoValue()
    {
        var kind = MemberKind.Field;
        var expectedLogic = "GetField";
        var calculatedRetievalLogic = GetMemberInfoLogic.For<StubHost_ConcreteClass>(kind);

        Assert.Equal(expectedLogic, calculatedRetievalLogic.Method.Name);
    }

    [Fact]
    internal void Throws_WhenProvidedWith_InvalidMemberKind_Value()
    {
        Assert.Throws<InvalidEnumValueException<MemberKind>>
        (
            () => GetMemberInfoLogic.For<StubHost_ConcreteClass>((MemberKind)StubPrimitives.MemberKindEnum_InvalidValue)
        );
    }
}