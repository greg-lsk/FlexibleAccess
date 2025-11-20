using FlexibleAccess.Exceptions;
using FlexibleAccess._Internals.InvalidInstanceHandling;

using FlexibleAccess.Tests._StubTypes;
using FlexibleAccess.Tests._StubTypes.StubHost;
using FlexibleAccess.Tests._StubTypes.InvalidCriteriaStub;


namespace FlexibleAccess.Tests.InternalsTests;

public class ForInvalidInstanceHandler
{
    [Fact]
    internal void ValueType_Throws_OnNoValue()
    {
        Assert.Throws<MissingInstanceAtRuntimeException<StubStruct, StubCriteria_Instanced_InvalidField>>
        (
            () => InvalidInstanceHandler<StubCriteria_Instanced_InvalidField>.ValueType<StubStruct>()
        );
    }

    [Fact]
    internal void ValueType_Throws_OnNullValue()
    {
        StubStruct? stub = null;

        Assert.Throws<MissingInstanceAtRuntimeException<StubStruct, StubCriteria_Instanced_InvalidField>>
        (
            () => InvalidInstanceHandler<StubCriteria_Instanced_InvalidField>.ValueType(stub)
        );
    }

    [Fact]
    internal void ValueType_NotThrows_WhenValueProvided()
    {
        StubStruct stub = new();
        try
        {
            InvalidInstanceHandler<StubCriteria_Instanced_InvalidField>.ValueType<StubStruct>(stub);
        }
        catch (Exception ex)
        {
            Assert.Fail($"Expected no exception, but got: {ex.Message}");
        }
    }

    [Fact]
    internal void ReferenceType_ThrowsOn_NoInstance()
    {
        Assert.Throws<MissingInstanceAtRuntimeException<StubHost_ConcreteClass, StubCriteria_Instanced_InvalidField>>
        (
            () => InvalidInstanceHandler<StubCriteria_Instanced_InvalidField>.ReferenceType<StubHost_ConcreteClass>()
        );
    }

    [Fact]
    internal void ReferenceType_ThrowsOn_NullInstance()
    {
        StubHost_ConcreteClass? stub = null;

        Assert.Throws<MissingInstanceAtRuntimeException<StubHost_ConcreteClass, StubCriteria_Instanced_InvalidField>>
        (
            () => InvalidInstanceHandler<StubCriteria_Instanced_InvalidField>.ReferenceType(stub)
        );
    }

    [Fact]
    internal void ReferenceType_NotThrows_WhenInstanceProvided()
    {
        StubHost_ConcreteClass stub = new();
        try
        {
            InvalidInstanceHandler<StubCriteria_Instanced_InvalidField>.ReferenceType(stub);
        }
        catch (Exception ex)
        {
            Assert.Fail($"Expected no exception, but got: {ex.Message}");
        }
    }
}