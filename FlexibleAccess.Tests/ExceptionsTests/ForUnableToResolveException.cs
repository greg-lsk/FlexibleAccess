using System.Reflection;
using FlexibleAccess.Exceptions;
using FlexibleAccess.Tests._StubTypes.StubHost;
using FlexibleAccess.Tests._StubTypes.InvalidCriteriaStub;


namespace FlexibleAccess.Tests.ExceptionsTests;

public class ForUnableToResolveException
{
    [Fact]
    internal void HasExpected_TargetIdentifier()
    {
        var stubInvalidCriteria = new StubCriteria_Static_InvalidProperty();
        var expected = stubInvalidCriteria.Identifier;

        var thrownException = Assert.Throws<UnableToResolveException<StubHost_ConcreteClass, string>>(
            () => ResolutionOn<StubHost_ConcreteClass>.Using<StubCriteria_Static_InvalidProperty>().GetValueOf<string>());
        var thrown = thrownException.TargetIdentifier;

        Assert.Equal(expected, thrown);
    }

    [Fact]
    internal void HasExpected_BindingFlags()
    {
        var stubInvalidCriteria = new StubCriteria_Static_InvalidProperty();
        var expected = stubInvalidCriteria.BindingFlags;

        var thrownException = Assert.Throws<UnableToResolveException<StubHost_ConcreteClass, string>>(
            () => ResolutionOn<StubHost_ConcreteClass>.Using<StubCriteria_Static_InvalidProperty>().GetValueOf<string>());
        var thrown = thrownException.BindingFlags;

        Assert.Equal(expected, thrown);
    }

    [Fact]
    internal void HasExpected_Message()
    {
        var stubInvalidCriteria = new StubCriteria_Static_InvalidProperty();
        var expected = CreateMessage<StubHost_ConcreteClass, string>(stubInvalidCriteria.Identifier, stubInvalidCriteria.BindingFlags);

        var thrownException = Assert.Throws<UnableToResolveException<StubHost_ConcreteClass, string>>(
            () => ResolutionOn<StubHost_ConcreteClass>.Using<StubCriteria_Static_InvalidProperty>().GetValueOf<string>());
        var thrown = thrownException.Message;

        Assert.Equal(expected, thrown);
    }


    private static string CreateMessage<THost, TResult>(string targetIdentifier, BindingFlags flags) =>
    $"\n" +
    $"reason:: {Reason()}\n" +
    $"target:: {flags} {ShortenTypeOf<TResult>()} {targetIdentifier}\n" +
    $"source:: {ShortenTypeOf<THost>()}\n" +
    $"\n" +
    $"target-verbose:: {typeof(TResult)}\n" +
    $"source-verbose:: {typeof(THost)}\n";

    private static string Reason() => "Couldn't resolve Property";
    private static string ShortenTypeOf<T>() => typeof(T).Name.Split('.').Last();
}