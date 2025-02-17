namespace CleanerSharpApi.Service;

public class OperationDecisionServiceDeny<
    TCreateInput,
    TReadQuery,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery
> : IOperationDecisionService<TCreateInput, TReadQuery, TUpdateQuery, TUpdateInput, TDeleteQuery>
{
    public bool Create(TCreateInput input)
    {
        return false;
    }

    public bool Delete(TDeleteQuery query)
    {
        return false;
    }

    public bool Read(TReadQuery query)
    {
        return false;
    }

    public bool Update(TUpdateQuery query, TUpdateInput input)
    {
        return false;
    }
}
