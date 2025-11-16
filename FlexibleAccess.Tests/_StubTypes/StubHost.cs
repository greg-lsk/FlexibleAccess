namespace FlexibleAccess.Tests._StubTypes;

internal class StubHost
{
    private readonly static string _stubPrivateString = string.Empty;
    internal static string StubPropertyName => _stubPrivateString;
}