using SharpCrud.Crud;

namespace CleanerSharpApi.Repository;

public class RepositoryManyAsync<
    TCreateResult,
    TCreateInput,
    TReadResult,
    TReadQuery,
    TUpdateResult,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery,
    TCrudManyAsync
>
    : IRepositoryManyAsync<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TCrudManyAsync : ICrudManyAsync<
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
    private readonly TCrudManyAsync _entities;

    public RepositoryManyAsync(TCrudManyAsync entities)
    {
        this._entities = entities;
    }

    public async Task<IEnumerable<TCreateResult>> CreateManyAsync(TCreateInput input)
    {
        return await this._entities.CreateManyAsync(input);
    }

    public async Task<IEnumerable<TReadResult>> ReadManyAsync(TReadQuery query)
    {
        return await this._entities.ReadManyAsync(query);
    }

    public async Task<IEnumerable<TUpdateResult>> UpdateManyAsync(
        TUpdateQuery query,
        TUpdateInput input
    )
    {
        return await this._entities.UpdateManyAsync(query, input);
    }

    public async Task DeleteManyAsync(TDeleteQuery query)
    {
        await this.DeleteManyAsync(query);
    }
}
