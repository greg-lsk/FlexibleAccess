namespace FlexibleAccess.Tests._StubTypes;

internal class StubHost
{
    internal readonly static string stubPrivateString = string.Empty;
    internal static string StubPropertyName => stubPrivateString;
}