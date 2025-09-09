using SharpCrud.Crud;

namespace CleanerSharpApi.Service;

public interface IEntityService<
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
