namespace CleanerSharpApi.Service;

public class OperationDecisionServiceConstant<
    TCreateInput,
    TReadQuery,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery
> : IOperationDecisionService<TCreateInput, TReadQuery, TUpdateQuery, TUpdateInput, TDeleteQuery>
{
    private bool _onCreate;
    private bool _onRead;
    private bool _onUpdate;
    private bool _onDelete;

    public OperationDecisionServiceConstant(
        bool onCreate,
        bool onRead,
        bool onUpdate,
        bool onDelete
    )
    {
        this._onCreate = onCreate;
        this._onRead = onRead;
        this._onUpdate = onUpdate;
        this._onDelete = onDelete;
    }

    public bool Create(TCreateInput input)
    {
        return this._onCreate;
    }

    public bool Read(TReadQuery query)
    {
        return this._onRead;
    }

    public bool Update(TUpdateQuery query, TUpdateInput input)
    {
        return this._onUpdate;
    }

    public bool Delete(TDeleteQuery query)
    {
        return this._onDelete;
    }
}
