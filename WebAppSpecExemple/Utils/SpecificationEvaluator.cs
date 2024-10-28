namespace WebAppSpecExemple.Utils;

public class SpecificationEvaluator<T> where T : class
{
   
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, BaseSpecification<T> specification)
    {
        // Apply criteria
        var query = inputQuery.Where(specification.Criteria);

        // Apply includes
        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query;
    }
}
