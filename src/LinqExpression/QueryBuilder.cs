using System.Linq.Expressions;

namespace LinqExpression
{
    /// <summary>
    /// Provides a fluent interface for building and executing LINQ
    /// queries with filtering, sorting, and joining capabilities.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements in the source data collection.
    /// </typeparam>
    public class QueryBuilder<T>
    {
        private readonly IQueryable<T> _source;

        private readonly List<Expression<Func<T, bool>>> _filters;
        private Func<IQueryable<T>, IOrderedQueryable<T>>? _sort;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source data collection.
        /// </param>
        public QueryBuilder(IEnumerable<T> source)
        {
            this._source = source.AsQueryable();
            this._filters = new ();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source data collection.
        /// </param>
        public QueryBuilder(IQueryable<T> source)
        {
            this._source = source;
            this._filters = new ();
        }

        /// <summary>
        /// Adds a filter predicate to the query.
        /// </summary>
        /// <param name="predicate">
        /// The filter expression.
        /// </param>
        /// <returns>
        /// The current <see cref="QueryBuilder{T}"/> instance.
        /// </returns>
        public QueryBuilder<T> Filter(Expression<Func<T, bool>> predicate)
        {
            ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));

            this._filters.Add(predicate);
            return this;
        }

        /// <summary>
        /// Specifies the primary sort order for the query.
        /// </summary>
        /// <typeparam name="TKey">
        /// The type of the key to sort by.
        /// </typeparam>
        /// <param name="keySelector">
        /// The key selector expression.
        /// </param>
        /// <param name="descending">
        /// Whether to sort in descending order.
        /// </param>
        /// <returns>
        /// The current <see cref="QueryBuilder{T}"/> instance.
        /// </returns>
        public QueryBuilder<T> SortBy<TKey>(Expression<Func<T, TKey>> keySelector, bool descending = false)
        {
            ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));

            this._sort = query => descending ? query.OrderByDescending(keySelector) : query.OrderBy(keySelector);
            return this;
        }

        /// <summary>
        /// Specifies a secondary sort order for the query.
        /// </summary>
        /// <typeparam name="TKey">
        /// The type of the key to sort by.
        /// </typeparam>
        /// <param name="keySelector">
        /// The key selector expression.
        /// </param>
        /// <param name="descending">
        /// Whether to sort in descending order.
        /// </param>
        /// <returns>
        /// The current <see cref="QueryBuilder{T}"/> instance.
        /// </returns>
        public QueryBuilder<T> ThenBy<TKey>(Expression<Func<T, TKey>> keySelector, bool descending = false)
        {
            ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));

            var previousSort = this._sort;
            if (previousSort is null)
            {
                return this.SortBy(keySelector, descending);
            }

            this._sort = query =>
            {
                var ordered = previousSort(query);
                return descending ? ordered.ThenByDescending(keySelector) : ordered.ThenBy(keySelector);
            };

            return this;
        }

        /// <summary>
        /// Performs an inner join with another data collection.
        /// </summary>
        /// <typeparam name="TInner">
        /// The type of the elements of the inner data collection.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key to join on.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result elements after join operation.
        /// </typeparam>
        /// <param name="inner">
        /// The inner data collection to join to the current query.
        /// </param>
        /// <param name="outerKeySelector">
        /// The key selector expression for the outer data collection.
        /// </param>
        /// <param name="innerKeySelector">
        /// The key selector expression for the inner data collection.
        /// </param>
        /// <param name="resultSelector">
        /// The expression to select data fields after the join operation.
        /// </param>
        /// <returns>
        /// A new <see cref="QueryBuilder{TResult}"/> representing the joined query.
        /// </returns>
        public QueryBuilder<TResult> Join<TInner, TKey, TResult>(
            IEnumerable<TInner> inner,
            Expression<Func<T, TKey>> outerKeySelector,
            Expression<Func<TInner, TKey>> innerKeySelector,
            Expression<Func<T, TInner, TResult>> resultSelector)
        {
            ArgumentNullException.ThrowIfNull(inner, nameof(inner));
            ArgumentNullException.ThrowIfNull(outerKeySelector, nameof(outerKeySelector));
            ArgumentNullException.ThrowIfNull(innerKeySelector, nameof(innerKeySelector));
            ArgumentNullException.ThrowIfNull(resultSelector, nameof(resultSelector));

            IQueryable<T> combinedQuery = this.BuildQuery();

            var innerQueryable = inner.AsQueryable();

            IQueryable<TResult> joinedResult = combinedQuery.Join(
                innerQueryable,
                outerKeySelector,
                innerKeySelector,
                resultSelector);

            return new QueryBuilder<TResult>(joinedResult);
        }

        /// <summary>
        /// Executes the composed query and returns the result as a list.
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> containing the query results.
        /// </returns>
        public List<T> Execute()
        {
            return this.BuildQuery().ToList();
        }

        /// <summary>
        /// Builds the composed query by applying all filters and sorting.
        /// </summary>
        /// <returns>
        /// The composed <see cref="IQueryable{T}"/>.
        /// </returns>
        public IQueryable<T> BuildQuery()
        {
            IQueryable<T> query = this._source;

            foreach (var filter in this._filters)
            {
                query = query.Where(filter);
            }

            if (this._sort != null)
            {
                query = this._sort(query);
            }

            return query;
        }
    }
}
