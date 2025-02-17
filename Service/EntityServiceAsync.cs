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
    private readonly TOperationDecisionService _operationDecisionService;

    public EntityServiceAsync(
        TRepository repository,
        TOperationDecisionService operationDecitionService
    )
    {
        this._repository = repository;
        this._operationDecisionService = operationDecitionService;
    }

    public async Task<TCreateResult> CreateAsync(TCreateInput input)
    {
        if (!this._operationDecisionService.Create(input))
            throw new OperationDeniedException();
        return await this._repository.CreateAsync(input);
    }

    public async Task<TReadResult?> ReadAsync(TReadQuery query)
    {
        if (!this._operationDecisionService.Read(query))
            throw new OperationDeniedException();
        return await this._repository.ReadAsync(query);
    }

    public async Task<TUpdateResult> UpdateAsync(TUpdateQuery query, TUpdateInput input)
    {
        if (!this._operationDecisionService.Update(query, input))
            throw new OperationDeniedException();
        return await this._repository.UpdateAsync(query, input);
    }

    public async Task DeleteAsync(TDeleteQuery query)
    {
        if (!this._operationDecisionService.Delete(query))
            throw new OperationDeniedException();
        await this._repository.DeleteAsync(query);
    }
}
