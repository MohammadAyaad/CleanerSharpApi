using CleanerSharpApi.Crud;

namespace CleanerSharpApi.Repository;

public class RepositoryAsync<
    TCreateResult,
    TCreateInput,
    TReadResult,
    TReadQuery,
    TUpdateResult,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery,
    TCrud
>
    : IRepositoryAsync<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TCrud : ICrudAsync<
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
    private readonly TCrud _entities;

    public RepositoryAsync(TCrud entities)
    {
        this._entities = entities;
    }

    public async Task<TCreateResult> CreateAsync(TCreateInput input)
    {
        return await this._entities.CreateAsync(input);
    }

    public async Task<TReadResult?> ReadAsync(TReadQuery query)
    {
        return await this._entities.ReadAsync(query);
    }

    public async Task<TUpdateResult> UpdateAsync(TUpdateQuery query, TUpdateInput input)
    {
        return await this._entities.UpdateAsync(query, input);
    }

    public async Task DeleteAsync(TDeleteQuery query)
    {
        await this._entities.DeleteAsync(query);
    }
}
