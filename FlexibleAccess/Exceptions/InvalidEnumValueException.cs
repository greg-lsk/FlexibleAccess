using ExceptionMessageSeparation;

namespace FlexibleAccess.Exceptions;

public sealed class InvalidEnumValueException<TEnum> : ExceptionBase<InvalidEnumValueException<TEnum>, InvalidEnumValueExceptionMessage<TEnum>>
    where TEnum : struct, Enum
{
    public TEnum CapturedValue { get; }

    public InvalidEnumValueException(TEnum captured, Exception? inner = default) : base(inner) => CapturedValue = captured;

}