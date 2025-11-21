using System.Reflection;
using ExceptionMessageSeparation;


namespace FlexibleAccess.Exceptions;

public sealed class UnableToResolveException<THost, TResult> 
    : ExceptionBase
    <
        UnableToResolveException<THost, TResult>, 
        UnableToResolveExceptionMessage<THost, TResult>
    >
{
    public string TargetIdentifier { get; }
    public BindingFlags BindingFlags { get; }

    public UnableToResolveException(string targetIdentifier, BindingFlags bindingFlags, Exception? inner = default)
        :base(inner)
    {
        TargetIdentifier = targetIdentifier;
        BindingFlags = bindingFlags;
    }
}