using CleanerSharpApi.Service;

namespace CleanerSharpApi.Endpoint;

public class EndpointMany<
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
    : IEndpointMany<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TEntityService : IEntityServiceMany<
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

    public EndpointMany(TEntityService entityService)
    {
        this._entityService = entityService;
    }

    public IEnumerable<TCreateResult> CreateMany(TCreateInput inputs)
    {
        return this._entityService.CreateMany(inputs);
    }

    public IEnumerable<TReadResult> ReadMany(TReadQuery query)
    {
        return this._entityService.ReadMany(query);
    }

    public IEnumerable<TUpdateResult> UpdateMany(TUpdateQuery query, TUpdateInput input)
    {
        return this._entityService.UpdateMany(query, input);
    }

    public void DeleteMany(TDeleteQuery query)
    {
        this._entityService.DeleteMany(query);
    }
}
