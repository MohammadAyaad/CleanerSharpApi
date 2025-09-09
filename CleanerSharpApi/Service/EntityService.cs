using CleanerSharpApi.Repository;

namespace CleanerSharpApi.Service;

public class EntityService<
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
    : IEntityService<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TRepository : IRepository<
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
    private readonly ICollection<TOperationDecisionService> _operationDecisionService;

    public EntityService(TRepository repository)
    {
        this._repository = repository;
        this._operationDecisionService = new List<TOperationDecisionService>();
    }

    public EntityService(
        TRepository repository,
        List<TOperationDecisionService> operationDecitionServices
    )
    {
        this._repository = repository;
        this._operationDecisionService = operationDecitionServices;
    }

    public TCreateResult Create(TCreateInput input)
    {
        if (this._operationDecisionService.Any(x => !x.Create(input)))
            throw new OperationDeniedException();
        return this._repository.Create(input);
    }

    public TReadResult? Read(TReadQuery query)
    {
        if (this._operationDecisionService.Any(x => !x.Read(query)))
            throw new OperationDeniedException();
        return this._repository.Read(query);
    }

    public TUpdateResult Update(TUpdateQuery query, TUpdateInput input)
    {
        if (this._operationDecisionService.Any(x => !x.Update(query, input)))
            throw new OperationDeniedException();
        return this._repository.Update(query, input);
    }

    public void Delete(TDeleteQuery query)
    {
        if (this._operationDecisionService.Any(x => !x.Delete(query)))
            throw new OperationDeniedException();
        this._repository.Delete(query);
    }
}
