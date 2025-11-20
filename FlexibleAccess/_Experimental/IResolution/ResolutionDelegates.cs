namespace FlexibleAccess._Experimental.IResolution;

internal delegate TResult ResolveOnClass<THost, TResult>(THost? instance = default) where THost : class;
internal delegate TResult ResolveOnStruct<THost, TResult>(THost? instance = default) where THost : struct;