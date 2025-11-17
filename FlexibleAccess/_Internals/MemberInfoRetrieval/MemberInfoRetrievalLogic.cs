using FlexibleAccess.Exceptions;


namespace FlexibleAccess._Internals.MemberInfoRetrieval;

internal static class MemberInfoRetrievalLogic
{
    internal static MemberInfoRetriever For<THost>(MemberKind kind) => kind switch
    {
        MemberKind.Property => typeof(THost).GetProperty,
        MemberKind.Field => typeof(THost).GetField,
        _ => throw new InvalidEnumValueException<MemberKind>(kind)
    };
}