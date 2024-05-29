using System.Linq.Expressions;

namespace BloodCare.Infrastructure.Expressions
{
    public class ExpressionConverter<TSource, TTarget> : ExpressionVisitor
    {
        private ParameterExpression _parameter;

        public Expression<Func<TTarget, bool>> Convert(Expression<Func<TSource, bool>> expression)
        {
            _parameter = Expression.Parameter(typeof(TTarget), "target");
            var body = Visit(expression.Body);
            return Expression.Lambda<Func<TTarget, bool>>(body, _parameter);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameter;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TSource))
            {
                var member = typeof(TTarget).GetMember(node.Member.Name).FirstOrDefault();
                return Expression.MakeMemberAccess(Visit(node.Expression), member);
            }
            return base.VisitMember(node);
        }
    }
}
