using System.Reflection;


namespace FlexibleAccess;

public interface IResolutionCriteria
{
    public string Identifier { get; }
    public BindingFlags BindingFlags { get; }
}