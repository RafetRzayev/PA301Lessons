using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Academy.ConsoleUI
{
    public class DynamicPredicateBuilder
    {
        public static Expression<Func<TEntity, bool>>? ParseFilter<TEntity>(string filterString)
        {
            if (string.IsNullOrWhiteSpace(filterString))
                return null;

            try
            {
                // Normalize the filter string
                var normalizedFilter = NormalizeFilterString(filterString);

                // Use Dynamic LINQ to parse the expression
                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var expression = DynamicExpressionParser.ParseLambda(
                    new[] { parameter },
                    typeof(bool),
                    normalizedFilter
                );

                return (Expression<Func<TEntity, bool>>)expression;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing filter: {ex.Message}");
                return null;
            }
        }

        // Normalize user-friendly input to Dynamic LINQ format
        private static string NormalizeFilterString(string input)
        {
            // Replace common operators with Dynamic LINQ equivalents
            input = input.Replace(" = ", " == ");
            input = input.Replace(" AND ", " && ");
            input = input.Replace(" and ", " && ");
            input = input.Replace(" OR ", " || ");
            input = input.Replace(" or ", " || ");

            return input;
        }
    }
}