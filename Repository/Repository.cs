using CleanerSharpApi.Crud;

namespace CleanerSharpApi.Repository;

public class Repository<
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
    : IRepository<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TCrud : ICrud<
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

    public Repository(TCrud entities)
    {
        this._entities = entities;
    }

    public TCreateResult Create(TCreateInput input)
    {
        return _entities.Create(input);
    }

    public TReadResult? Read(TReadQuery query)
    {
        return this._entities.Read(query);
    }

    public TUpdateResult Update(TUpdateQuery query, TUpdateInput input)
    {
        return this._entities.Update(query, input);
    }

    public void Delete(TDeleteQuery query)
    {
        this._entities.Delete(query);
    }
}
