namespace Nyx.Analysis.Syntax;

internal class ExpressionStatement : Statement
{
    internal override Location location { get; }
    public Expression expression { get; }

    internal ExpressionStatement(Expression expression, Token semicolon, Token newLine)
    {
        location = Location.Embrace(expression, semicolon);
        this.expression = expression;
    }
}