namespace CleanerSharpApi.Service;

public class OperationDecisionServiceAllow<
    TCreateInput,
    TReadQuery,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery
> : IOperationDecisionService<TCreateInput, TReadQuery, TUpdateQuery, TUpdateInput, TDeleteQuery>
{
    public bool Create(TCreateInput input)
    {
        return true;
    }

    public bool Delete(TDeleteQuery query)
    {
        return true;
    }

    public bool Read(TReadQuery query)
    {
        return true;
    }

    public bool Update(TUpdateQuery query, TUpdateInput input)
    {
        return true;
    }
}
