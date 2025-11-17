namespace FlexibleAccess.Exceptions;

public sealed class InvalidEnumValueException<TEnum> : Exception 
    where TEnum : struct, Enum
{
    public TEnum CapturedValue { get; }
    public override string Message => CreateMessage(CapturedValue);


    public InvalidEnumValueException(TEnum captured) => CapturedValue = captured;
    public InvalidEnumValueException(TEnum captured, Exception? inner) : base(CreateMessage(captured), inner) => CapturedValue = captured;

    private static string CreateMessage(TEnum captureValue)
    {
        var message = Enum.GetValues<TEnum>().Contains(captureValue) ? "Unexpected" : "Invalid";

        return
        $"{Environment.NewLine}" +
        $"An {message} enum value was encountered{Environment.NewLine}" +
        $"Encountered value:: {captureValue}";
    }
}