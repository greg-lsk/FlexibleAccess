using System.Reflection;


namespace FlexibleAccess._Internals.MemberInfoRetrieval;

internal delegate MemberInfo? MemberInfoRetriever(string name, BindingFlags bindingAttr); 