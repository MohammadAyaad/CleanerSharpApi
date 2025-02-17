using CleanerSharpApi.Service;

namespace CleanerSharpApi.Endpoint;

public class Endpoint<
    TCreateResult,
    TCreateInput,
    TReadResult,
    TReadQuery,
    TUpdateResult,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery,
    TEntityService
>
    : IEndpoint<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TEntityService : IEntityService<
            TCreateResult,
            TCreateInput,
            TReadResult,
            TReadQuery,
            TUpdateResult,
            TUpdateQuery,
            TUpdateInput,
            TDeleteQuery
        >
{
    private readonly TEntityService _entityService;

    public Endpoint(TEntityService entityService)
    {
        this._entityService = entityService;
    }

    public TCreateResult Create(TCreateInput input)
    {
        return this._entityService.Create(input);
    }

    public TReadResult? Read(TReadQuery query)
    {
        return this._entityService.Read(query);
    }

    public TUpdateResult Update(TUpdateQuery query, TUpdateInput input)
    {
        return this._entityService.Update(query, input);
    }

    public void Delete(TDeleteQuery query)
    {
        this._entityService.Delete(query);
    }
}
