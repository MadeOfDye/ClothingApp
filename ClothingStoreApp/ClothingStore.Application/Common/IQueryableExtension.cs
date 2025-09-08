using System.Linq.Expressions;

namespace ClothingStore.Application.Common
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string sortBy, bool ascending = true)
        {
            if (string.IsNullOrEmpty(sortBy))
                return query;
            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, sortBy);
            var lambda = Expression.Lambda(property, param);
            if (property.Type != typeof(string) && !typeof(IComparable).IsAssignableFrom(property.Type))
            {
                throw new ArgumentException($"Property '{sortBy}' is not sortable.");
            }
            var methodName = ascending ? "OrderBy" : "OrderByDescending";
            var resultExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), property.Type },
                query.Expression,
                lambda
            );

            return query.Provider.CreateQuery<T>(resultExpression);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageNumber < 1 || pageSize < 1)
                throw new ArgumentOutOfRangeException("Page number and size must be greater than zero.");
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, string fieldName, object value)
        {
            if (string.IsNullOrEmpty(fieldName)) return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, fieldName);
            var constant = Expression.Constant(value);
            var equality = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

            return query.Where(lambda);
        }
    }
}
