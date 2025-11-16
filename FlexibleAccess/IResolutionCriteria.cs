using System.Reflection;


namespace FlexibleAccess;


public enum MemberKind
{
    Field,
    Property
}
public interface IResolutionCriteria
{
    public string Identifier { get; }
    public MemberKind MemberKind { get; }

    public BindingFlags BindingFlags { get; }
}