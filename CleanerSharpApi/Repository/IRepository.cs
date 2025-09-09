using SharpCrud.Crud;

namespace CleanerSharpApi.Repository;

public interface IRepository<
    TCreateResult,
    TCreateInput,
    TReadResult,
    TReadQuery,
    TUpdateResult,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery
>
    : ICrud<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    > { }
