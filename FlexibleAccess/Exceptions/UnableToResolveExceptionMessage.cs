using ExceptionMessageSeparation;


namespace FlexibleAccess.Exceptions;

public readonly struct UnableToResolveExceptionMessage<THost, TResult> : IExceptionMessage<UnableToResolveException<THost, TResult>>
{
    public string For(UnableToResolveException<THost, TResult> exception) =>
    $"{Environment.NewLine}" +
    $"{Environment.NewLine}reason:: {Reason()}" +
    $"{Environment.NewLine}target:: {exception.BindingFlags} {ShortenTypeOf<TResult>()} {exception.TargetIdentifier}" +
    $"{Environment.NewLine}source:: {ShortenTypeOf<THost>()}" +
    $"{Environment.NewLine}target-verbose:: {typeof(TResult)}\n" +
    $"{Environment.NewLine}source-verbose:: {typeof(THost)}\n";


    private static string Reason() => "Couldn't resolve Property";
    private static string ShortenTypeOf<T>() => typeof(T).Name.Split('.').Last();
}