using ExceptionMessageSeparation;


namespace FlexibleAccess.Exceptions;

public sealed class MissingInstanceException<TMissing, TCriteria> 
    : ExceptionBase
    <
        MissingInstanceException<TMissing, TCriteria>, 
        MissingInstanceExceptionMessage<TMissing, TCriteria>
    >
    where TCriteria : struct, IResolutionCriteria
{
    public MissingInstanceException(Exception? inner = default) : base(inner) { }
}