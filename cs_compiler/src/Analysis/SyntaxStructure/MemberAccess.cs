namespace Nyx.Analysis;

internal class MemberAccess : Expression
{
    internal override Location location { get; }
    public Expression expression { get; }
    public Identifier identifier { get; }

    internal MemberAccess(Expression expression, Token dot, ValueToken name)
    {
        location = Location.Embrace(expression.location, name.location);
        this.expression = expression;
        this.identifier = new Identifier(name);
    }
}