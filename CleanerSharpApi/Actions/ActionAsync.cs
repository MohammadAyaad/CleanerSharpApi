namespace CleanerSharpApi.Actions;

public interface ICreateAsync<TEntity, in TInput>
{
    Task<TEntity> CreateAsync(TInput input);
}

public interface IReadAsync<TEntity, in TQuery>
{
    Task<TEntity?> ReadAsync(TQuery query);
}

public interface IUpdateAsync<TEntity, in TQuery, in TInput>
{
    Task<TEntity> UpdateAsync(TQuery query, TInput input);
}

public interface IDeleteAsync<in TQuery>
{
    Task DeleteAsync(TQuery query);
}
