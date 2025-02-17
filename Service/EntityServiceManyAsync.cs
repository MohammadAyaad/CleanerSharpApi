using CleanerSharpApi.Repository;

namespace CleanerSharpApi.Service;

public class EntityServiceManyAsync<
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
    : IEntityServiceManyAsync<
        TCreateResult,
        TCreateInput,
        TReadResult,
        TReadQuery,
        TUpdateResult,
        TUpdateQuery,
        TUpdateInput,
        TDeleteQuery
    >
    where TRepository : IRepositoryManyAsync<
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

    public EntityServiceManyAsync(
        TRepository repository,
        TOperationDecisionService operationDecisionService
    )
    {
        this._repository = repository;
        this._operationDecisionService = operationDecisionService;
    }

    public async Task<IEnumerable<TCreateResult>> CreateManyAsync(TCreateInput input)
    {
        if (!this._operationDecisionService.Create(input))
            throw new OperationDeniedException();
        return await this._repository.CreateManyAsync(input);
    }

    public async Task<IEnumerable<TReadResult>> ReadManyAsync(TReadQuery query)
    {
        if (!this._operationDecisionService.Read(query))
            throw new OperationDeniedException();
        return await this._repository.ReadManyAsync(query);
    }

    public async Task<IEnumerable<TUpdateResult>> UpdateManyAsync(
        TUpdateQuery query,
        TUpdateInput input
    )
    {
        if (!this._operationDecisionService.Update(query, input))
            throw new OperationDeniedException();
        return await this._repository.UpdateManyAsync(query, input);
    }

    public async Task DeleteManyAsync(TDeleteQuery query)
    {
        if (!this._operationDecisionService.Delete(query))
            throw new OperationDeniedException();
        await this._repository.DeleteManyAsync(query);
    }
}
