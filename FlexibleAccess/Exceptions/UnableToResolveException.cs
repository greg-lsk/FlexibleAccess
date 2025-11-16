using System.Reflection;


namespace FlexibleAccess.Exceptions;

public sealed class UnableToResolveException<THost, TResult> : Exception
{
    public string TargetIdentifier { get; }
    public IEnumerable<BindingFlags> BindingFlags { get; }

    public override string Message => CreateMessage(TargetIdentifier, BindingFlags);


    public UnableToResolveException(string targetIdentifier, params BindingFlags[] bindingFlags)
    {
        TargetIdentifier = targetIdentifier;
        BindingFlags = bindingFlags;
    }

    public UnableToResolveException(string targetIdentifier, Exception inner, params BindingFlags[] bindingFlags)
        :base (CreateMessage(targetIdentifier, bindingFlags), inner)
    {
        TargetIdentifier = targetIdentifier;
        BindingFlags = bindingFlags;
    }


    private static string CreateMessage(string targetIdentifier, IEnumerable<BindingFlags>flags) =>
    $"\n" +
    $"reason:: {Reason()}\n" +
    $"target:: {JoinFlags(flags)} {ShortenTypeOf<TResult>()} {targetIdentifier}\n" +
    $"source:: {ShortenTypeOf<THost>()}\n" +
    $"\n" +
    $"target-verbose:: {typeof(TResult)}\n" +
    $"source-verbose:: {typeof(THost)}\n";


    private static string Reason() => "Couldn't resolve Property";
    private static string ShortenTypeOf<T>() => typeof(T).Name.Split('.').Last();
    private static string JoinFlags(IEnumerable<BindingFlags> flags) => string.Join(", ", flags.Select(f => f.ToString()));
}