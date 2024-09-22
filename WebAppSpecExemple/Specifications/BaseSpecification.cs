using System.Linq.Expressions;

namespace WebAppSpecExemple.Specifications;

public abstract class BaseSpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }

    protected BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }
}
