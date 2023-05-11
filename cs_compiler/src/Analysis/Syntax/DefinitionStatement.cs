namespace Nyx.Analysis.Syntax;

internal class DefinitionStatement : Statement
{
    internal override Location location { get; }
    public Modifiers modifiers { get; }
    public Identifier name { get; }
    public TypeClause type { get; }
    public Expression assignment { get; }

    internal DefinitionStatement(
        Modifiers modifiers, 
        Token var, 
        Identifier name, 
        TypeClause type, 
        Token equal, 
        Expression expression, 
        Token semicolon,
        Token newLine)
    {
        location = Location.Embrace(modifiers, semicolon);
        this.modifiers = modifiers;
        this.name = name;
        this.type = type;
        this.assignment = expression;
    }
}