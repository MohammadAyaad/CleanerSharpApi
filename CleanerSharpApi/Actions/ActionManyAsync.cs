namespace CleanerSharpApi.Actions;

public interface ICreateManyAsync<TEntity, in TInput>
{
    Task<IEnumerable<TEntity>> CreateManyAsync(TInput inputs);
}

public interface IReadManyAsync<TEntity, in TQuery>
{
    Task<IEnumerable<TEntity>> ReadManyAsync(TQuery query);
}

public interface IUpdateManyAsync<TEntity, in TQuery, in TInput>
{
    Task<IEnumerable<TEntity>> UpdateManyAsync(TQuery query, TInput input);
}

public interface IDeleteManyAsync<in TQuery>
{
    Task DeleteManyAsync(TQuery query);
}
