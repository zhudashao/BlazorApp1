namespace WebAppSpecExemple.Utils;

public class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, BaseSpecification<T> specification)
    {
        var query = inputQuery;

        // Appliquer les critères (Where)
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        return query;
    }
}
