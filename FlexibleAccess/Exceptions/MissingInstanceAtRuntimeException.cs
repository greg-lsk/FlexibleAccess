namespace FlexibleAccess.Exceptions;


public sealed class MissingInstanceAtRuntimeException<TMissing, TCriteria> : Exception
    where TCriteria : struct, IResolutionCriteria
{
    public override string Message => CreateMessage();

    public MissingInstanceAtRuntimeException() : base(CreateMessage()) { }
    public MissingInstanceAtRuntimeException(Exception? innerException) : base(CreateMessage(), innerException) { }


    private static string CreateMessage()
    {
        return
        $"{Environment.NewLine}" +
        $"Missing instance for a resolver call that was indicated an instanced resolution{Environment.NewLine}" +
        $"{MissingTypeIdentifier} Type Needed:: {MissingType}{Environment.NewLine}" +
        $"Resolution Target:: {ResolutionTarget}{Environment.NewLine}" +
        $"Indicated By:: {Indicator}{Environment.NewLine}" +
        $"{Guidance}{Environment.NewLine}" +
        $"Type Needed - verbose:: {MissingTypeVerbose}{Environment.NewLine}" +
        $"Indicated By - verbose:: {IndicatorVerbose}";
    }

    private static string MissingType => typeof(TMissing).Name;
    private static string MissingTypeIdentifier => typeof(TMissing).IsValueType ? "Value" : "Reference";

    private static string Indicator => typeof(TCriteria).Name;
    private static string ResolutionTarget => new TCriteria().Identifier;

    private static Type MissingTypeVerbose => typeof(TMissing);
    private static Type IndicatorVerbose => typeof(TCriteria);

    private static string Guidance => "instance not provided or is null at time of execution";
}