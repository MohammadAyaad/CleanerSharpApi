using CleanerSharpApi.Service;

namespace CleanerSharpApi.Endpoint;

public class EndpointAsync<
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
    : IEndpointAsync<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TEntityService : IEntityServiceAsync<
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

    public EndpointAsync(TEntityService entityService)
    {
        this._entityService = entityService;
    }

    public async Task<TCreateResult> CreateAsync(TCreateInput input)
    {
        return await this._entityService.CreateAsync(input);
    }

    public async Task<TReadResult?> ReadAsync(TReadQuery query)
    {
        return await this._entityService.ReadAsync(query);
    }

    public async Task<TUpdateResult> UpdateAsync(TUpdateQuery query, TUpdateInput input)
    {
        return await this._entityService.UpdateAsync(query, input);
    }

    public async Task DeleteAsync(TDeleteQuery query)
    {
        await this._entityService.DeleteAsync(query);
    }
}
