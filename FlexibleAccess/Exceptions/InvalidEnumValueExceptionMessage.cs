using ExceptionMessageSeparation;


namespace FlexibleAccess.Exceptions;

public readonly struct InvalidEnumValueExceptionMessage<TEnum> 
    : IExceptionMessage<InvalidEnumValueException<TEnum>>
    where TEnum : struct, Enum
{
    public string For(InvalidEnumValueException<TEnum> exception)
    {
        var captureValue = exception.CapturedValue;
        var captureValueType = Enum.GetValues<TEnum>().Contains(captureValue) ? "Unexpected" : "Invalid";

        return
        $"{Environment.NewLine}" +
        $"An {captureValueType} enum value was encountered{Environment.NewLine}" +
        $"Encountered value:: {captureValue}";
    }
}