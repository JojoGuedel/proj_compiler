namespace Nyx.Analysis.Syntax;

internal class BinaryExpression : Expression
{
    internal override Location location { get; }
    public Expression left { get; }
    public Token @operator { get; }
    public Expression right { get; }

    internal BinaryExpression(Expression left, Token opeartor, Expression right)
    {
        location = Location.Embrace(left, right);
        this.left = left;
        this.@operator = opeartor;
        this.right = right;
    }
}
