namespace CleanerSharpApi.Actions;

public interface ICreate<TEntity, in TInput>
{
    TEntity Create(TInput input);
}

public interface IRead<TEntity, in TQuery>
{
    TEntity? Read(TQuery query);
}

public interface IUpdate<TEntity, in TQuery, in TInput>
{
    TEntity Update(TQuery query, TInput input);
}

public interface IDelete<in TQuery>
{
    void Delete(TQuery query);
}
