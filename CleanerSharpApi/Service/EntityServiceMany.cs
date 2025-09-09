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
    private readonly ICollection<TOperationDecisionService> _operationDecisionService;

    public EntityServiceMany(TRepository repository)
    {
        this._repository = repository;
        this._operationDecisionService = new List<TOperationDecisionService>();
    }

    public EntityServiceMany(
        TRepository repository,
        List<TOperationDecisionService> operationDecitionServices
    )
    {
        this._repository = repository;
        this._operationDecisionService = operationDecitionServices;
    }

    public IEnumerable<TCreateResult> CreateMany(TCreateInput input)
    {
        if (this._operationDecisionService.Any(x => !x.Create(input)))
            throw new OperationDeniedException();
        return this._repository.CreateMany(input);
    }

    public IEnumerable<TReadResult> ReadMany(TReadQuery query)
    {
        if (this._operationDecisionService.Any(x => !x.Read(query)))
            throw new OperationDeniedException();
        return this._repository.ReadMany(query);
    }

    public IEnumerable<TUpdateResult> UpdateMany(TUpdateQuery query, TUpdateInput input)
    {
        if (this._operationDecisionService.Any(x => !x.Update(query, input)))
            throw new OperationDeniedException();
        return this._repository.UpdateMany(query, input);
    }

    public void DeleteMany(TDeleteQuery query)
    {
        if (this._operationDecisionService.Any(x => !x.Delete(query)))
            throw new OperationDeniedException();
        this._repository.DeleteMany(query);
    }
}
