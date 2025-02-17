using CleanerSharpApi.Repository;

namespace CleanerSharpApi.Service;

public class EntityServiceMany<
    TCreateResult,
    TCreateInput,
    TReadResult,
    TReadQuery,
    TUpdateResult,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery,
    TRepository,
    TOperationDecisionService
>
    : IEntityServiceMany<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TRepository : IRepositoryMany<
            TCreateResult,
            TCreateInput,
            TReadResult,
            TReadQuery,
            TUpdateResult,
            TUpdateQuery,
            TUpdateInput,
            TDeleteQuery
        >
    where TOperationDecisionService : IOperationDecisionService<
            TCreateInput,
            TReadQuery,
            TUpdateQuery,
            TUpdateInput,
            TDeleteQuery
        >
{
    private readonly TRepository _repository;
    private readonly TOperationDecisionService _operationDecisionService;

    public EntityServiceMany(
        TRepository repository,
        TOperationDecisionService operationDecisionService
    )
    {
        this._repository = repository;
        this._operationDecisionService = operationDecisionService;
    }

    public IEnumerable<TCreateResult> CreateMany(TCreateInput input)
    {
        if (!this._operationDecisionService.Create(input))
            throw new OperationDeniedException();
        return this._repository.CreateMany(input);
    }

    public IEnumerable<TReadResult> ReadMany(TReadQuery query)
    {
        if (!this._operationDecisionService.Read(query))
            throw new OperationDeniedException();
        return this._repository.ReadMany(query);
    }

    public IEnumerable<TUpdateResult> UpdateMany(TUpdateQuery query, TUpdateInput input)
    {
        if (!this._operationDecisionService.Update(query, input))
            throw new OperationDeniedException();
        return this._repository.UpdateMany(query, input);
    }

    public void DeleteMany(TDeleteQuery query)
    {
        if (!this._operationDecisionService.Delete(query))
            throw new OperationDeniedException();
        this._repository.DeleteMany(query);
    }
}
