using CleanerSharpApi.Actions;

namespace CleanerSharpApi.Crud;

public interface ICrudAsync<
    TCreateResult,
    TCreateInput,
    TReadResult,
    TReadQuery,
    TUpdateResult,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery
>
    : ICreateAsync<TCreateResult, TCreateInput>,
        IReadAsync<TReadResult, TReadQuery>,
        IUpdateAsync<TUpdateResult, TUpdateQuery, TUpdateInput>,
        IDeleteAsync<TDeleteQuery> { }
