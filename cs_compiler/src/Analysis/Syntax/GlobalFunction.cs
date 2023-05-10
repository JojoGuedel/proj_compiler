using System.Collections.Immutable;

namespace Nyx.Analysis.Syntax;

internal class GlobalFunction : GlobalMember
{
    internal override Location location { get; }
    public Identifier name { get; }
    public ImmutableArray<Parameter> parameters { get; }
    public TypeClause type { get; }
    public Block body { get; }

    internal GlobalFunction (
        Token global, 
        Token func, 
        Identifier name,
        Token lParen, 
        ImmutableArray<Parameter> parameters,
        Token rParen,
        TypeClause type, 
        Token colon, 
        Token newLine,
        Block body)
    {
        location = Location.Embrace(global, body);
        this.name = name;
        this.parameters = parameters;
        this.type = type;
        this.body = body;
    }
}