namespace Nyx.Analysis.Syntax;

internal class Property : StructMember
{
    internal override Location location { get; }
    public Identifier name { get; }
    public TypeClause type { get; }
    public AccessorClause accessor { get; }

    internal Property(
        Token var, 
        Identifier name,
        TypeClause type, 
        AccessorClause accessor, 
        Token semicolon, 
        Token newLine)
    {
        location = Location.Embrace(var, semicolon);
        this.name = name;
        this.type = type;
        this.accessor = accessor;
    }
}
