namespace Nyx.Analysis.Syntax;

internal class ReturnStatement : Statement
{
    internal override Location location { get; }
    public Expression expression { get; }

    internal ReturnStatement(Token @return, Expression expression, Token semicolon, Token newLine)
    {
        location = Location.Embrace(@return, semicolon);
        this.expression = expression;
    }
}