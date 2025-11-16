namespace FlexibleAccess;

public delegate TResult Resolver<THost, TResult>(THost? instance = default);