using CleanerSharpApi.Service;

namespace CleanerSharpApi.Endpoint;

public class EndpointManyAsync<
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
    : IEndpointManyAsync<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TEntityService : IEntityServiceManyAsync<
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

    public EndpointManyAsync(TEntityService entityService)
    {
        this._entityService = entityService;
    }

    public async Task<IEnumerable<TCreateResult>> CreateManyAsync(TCreateInput input)
    {
        return await this._entityService.CreateManyAsync(input);
    }

    public async Task<IEnumerable<TReadResult>> ReadManyAsync(TReadQuery query)
    {
        return await this._entityService.ReadManyAsync(query);
    }

    public async Task<IEnumerable<TUpdateResult>> UpdateManyAsync(
        TUpdateQuery query,
        TUpdateInput input
    )
    {
        return await this._entityService.UpdateManyAsync(query, input);
    }

    public async Task DeleteManyAsync(TDeleteQuery query)
    {
        await this._entityService.DeleteManyAsync(query);
    }
}
