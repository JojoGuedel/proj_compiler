namespace Nyx.Analysis.Syntax;

internal class Postfix : Expression
{
    internal override Location location => Location.Embrace(expression, postfix);
    public Expression expression { get; }
    public Token postfix { get; }

    internal Postfix(Expression expression, Token postfix)
    {
        this.expression = expression;
        this.postfix = postfix;
    }
}
