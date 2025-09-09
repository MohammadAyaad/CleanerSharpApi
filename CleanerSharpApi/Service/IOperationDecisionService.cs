using SharpCrud.Crud;

namespace CleanerSharpApi.Service;

public interface IOperationDecisionService<
    TCreateInput,
    TReadQuery,
    TUpdateQuery,
    TUpdateInput,
    TDeleteQuery
>
{
    bool Create(TCreateInput input);
    bool Read(TReadQuery query);
    bool Update(TUpdateQuery query, TUpdateInput input);
    bool Delete(TDeleteQuery query);
}
