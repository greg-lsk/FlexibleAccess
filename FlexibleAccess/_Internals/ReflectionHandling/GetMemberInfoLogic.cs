using FlexibleAccess.Exceptions;


namespace FlexibleAccess._Internals.ReflectionHandling;

internal static class GetMemberInfoLogic
{
    internal static GetMemberInfo For<THost>(MemberKind kind) => (kind) switch
    {
        MemberKind.Field    => typeof(THost).GetField,
        MemberKind.Property => typeof(THost).GetProperty,
        _ => throw new InvalidEnumValueException<MemberKind>(kind)
    };
}