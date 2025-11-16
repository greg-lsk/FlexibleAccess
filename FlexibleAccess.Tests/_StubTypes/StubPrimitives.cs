using System.Reflection;

namespace FlexibleAccess.Tests._StubTypes;

internal static class StubPrimitives
{
    internal const string InvalidPropertyNameForStubHost = "SubHost";
    internal const string InvalidFieldNameForStubHost = "SubHost";

    internal const BindingFlags StubBindingFlags = BindingFlags.NonPublic | BindingFlags.Static;
}
