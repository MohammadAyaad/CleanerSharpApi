using CleanerSharpApi.Repository;

namespace CleanerSharpApi.Service;

public class EntityServiceAsync<
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
    : IEntityServiceAsync<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TRepository : IRepositoryAsync<
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

    public EntityServiceAsync(TRepository repository)
    {
        this._repository = repository;
        this._operationDecisionService = new List<TOperationDecisionService>();
    }

    public EntityServiceAsync(
        TRepository repository,
        List<TOperationDecisionService> operationDecitionServices
    )
    {
        this._repository = repository;
        this._operationDecisionService = operationDecitionServices;
    }

    public async Task<TCreateResult> CreateAsync(TCreateInput input)
    {
        if (this._operationDecisionService.Any(x => !x.Create(input)))
            throw new OperationDeniedException();
        return await this._repository.CreateAsync(input);
    }

    public async Task<TReadResult?> ReadAsync(TReadQuery query)
    {
        if (this._operationDecisionService.Any(x => !x.Read(query)))
            throw new OperationDeniedException();
        return await this._repository.ReadAsync(query);
    }

    public async Task<TUpdateResult> UpdateAsync(TUpdateQuery query, TUpdateInput input)
    {
        if (this._operationDecisionService.Any(x => !x.Update(query, input)))
            throw new OperationDeniedException();
        return await this._repository.UpdateAsync(query, input);
    }

    public async Task DeleteAsync(TDeleteQuery query)
    {
        if (this._operationDecisionService.Any(x => !x.Delete(query)))
            throw new OperationDeniedException();
        await this._repository.DeleteAsync(query);
    }
}
