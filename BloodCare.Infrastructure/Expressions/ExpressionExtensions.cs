using System.Linq.Expressions;

namespace BloodCare.Infrastructure.Expressions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TTarget, bool>> ToInfrastructureExpression<TSource, TTarget>(
            this Expression<Func<TSource, bool>> expression)
        {
            try
            {
                var converter = new ExpressionConverter<TSource, TTarget>();
                return converter.Convert(expression);
            }
            catch (Exception)
            {
                return target => false;
            }
        }
    }
}

