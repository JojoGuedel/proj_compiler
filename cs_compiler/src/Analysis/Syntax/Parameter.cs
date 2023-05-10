namespace Nyx.Analysis.Syntax;

internal class Parameter : Node
{
    internal override Location location => Location.Embrace(modifiers, typeClause);
    Modifiers modifiers { get; }
    Identifier identifier { get; }
    TypeClause typeClause { get; }

    internal Parameter(Modifiers modifiers, Token var, Identifier identifier, TypeClause typeClause)
    {
        this.modifiers = modifiers;
        this.identifier = identifier;
        this.typeClause = typeClause;
    }
}
