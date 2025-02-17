namespace CleanerSharpApi.Actions;

public interface ICreateMany<TEntity, in TInput>
{
    IEnumerable<TEntity> CreateMany(TInput input);
}

public interface IReadMany<TEntity, in TQuery>
{
    IEnumerable<TEntity> ReadMany(TQuery query);
}

public interface IUpdateMany<TEntity, in TQuery, in TInput>
{
    IEnumerable<TEntity> UpdateMany(TQuery query, TInput input);
}

public interface IDeleteMany<in TQuery>
{
    void DeleteMany(TQuery query);
}
