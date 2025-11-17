using FlexibleAccess.Exceptions;
using FlexibleAccess.Tests._StubTypes;

namespace FlexibleAccess.Tests.ExceptionsTests;

public class ForInvalidEnumValueException
{
    [Fact]
    internal void WhenThrown_CorrectlyInformsAbout_UnexpectedValue()
    {
        var exception = new InvalidEnumValueException<StubEnum>(StubEnum.stubEnumValue03);
        Assert.Contains("Unexpected", exception.Message);
    }

    [Fact]
    internal void WhenThrown_CorrectlyInformsAbout_InvalidValue()
    {
        var exception = new InvalidEnumValueException<StubEnum>((StubEnum)StubPrimitives.StubEnum_InvalidValue);
        Assert.Contains("Invalid", exception.Message);
    }

    [Fact]
    internal void WhenThrown_CorrectlyCaptures_InvalidValue()
    {
        var exception = new InvalidEnumValueException<StubEnum>((StubEnum)StubPrimitives.StubEnum_InvalidValue);
        Assert.Equal($"{StubPrimitives.StubEnum_InvalidValue}", $"{exception.CapturedValue}");
    }
}