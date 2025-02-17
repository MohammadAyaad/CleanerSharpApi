using CleanerSharpApi.Crud;

namespace CleanerSharpApi.Repository;

public class RepositoryMany<
    TCreateResult,
    TCreateInput,
    TReadResult,
    TReadQuery,
    TUpdateResult,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery,
    TCrudMany
>
    : IRepositoryMany<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TCrudMany : ICrudMany<
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
    private readonly TCrudMany _entities;

    public RepositoryMany(TCrudMany entities)
    {
        this._entities = entities;
    }

    public IEnumerable<TCreateResult> CreateMany(TCreateInput inputs)
    {
        return this._entities.CreateMany(inputs);
    }

    public IEnumerable<TReadResult> ReadMany(TReadQuery query)
    {
        return this._entities.ReadMany(query);
    }

    public IEnumerable<TUpdateResult> UpdateMany(TUpdateQuery query, TUpdateInput input)
    {
        return this._entities.UpdateMany(query, input);
    }

    public void DeleteMany(TDeleteQuery query)
    {
        this._entities.DeleteMany(query);
    }
}
