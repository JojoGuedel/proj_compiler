using System.Collections.Immutable;

namespace Nyx.Analysis.Syntax;

internal class Subscript : Expression
{
    internal override Location location { get; }
    public Expression expression { get; }
    // TODO: optional arguments
    public ImmutableArray<Expression> arguments { get; }

    internal Subscript(
        Expression expression, 
        Token lParen, 
        ImmutableArray<Expression> arguments, 
        Token rParen)
    {
        location = Location.Embrace(expression, rParen);
        this.expression = expression;
        this.arguments = arguments;
    }
}