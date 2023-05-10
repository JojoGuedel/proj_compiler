namespace Nyx.Analysis.Syntax;

internal class TypeClause : Node
{
    internal override Location location { get; }
    public Expression type { get; }

    internal TypeClause(Token clauseInit, Expression type)
    {
        location = type.location;
        this.type = type;
    } 
}