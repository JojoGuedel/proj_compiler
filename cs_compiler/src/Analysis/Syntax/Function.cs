using System.Collections.Immutable;

namespace Nyx.Analysis.Syntax;

internal class Function : Member
{
    internal override Location location { get; }
    public Modifiers modifiers;
    public Expression name { get; }
    public ImmutableArray<Parameter> parameters { get; }
    public TypeClause type { get; }
    public Block body { get; }

    internal Function(
        Modifiers modifiers,
        Token func,
        Expression name,
        Token lParen,
        ImmutableArray<Parameter> parameters,
        Token rParen,
        TypeClause type,
        Token colon,
        Token newLine,
        Block body)
    {
        location = Location.Embrace(modifiers, body);
        this.modifiers = modifiers;
        this.name = name;
        this.parameters = parameters;
        this.type = type;
        this.body = body;
    }
}

internal abstract class StructMember : Node { }

internal class AccessorClause : Node
{
    internal override Location location { get; }


    internal AccessorClause(Token rArrow, Token get, Token set, Token semicolon)
    {
        location = Location.Embrace(rArrow, semicolon);
    }
}

internal class Property : StructMember
{
    internal override Location location => throw new NotImplementedException();
}

internal class FunctionDeclaration : StructMember
{
    internal override Location location => throw new NotImplementedException();
}

internal class Struct : Member
{
    internal override Location location => throw new NotImplementedException();
    ImmutableArray<StructMember> members;
}