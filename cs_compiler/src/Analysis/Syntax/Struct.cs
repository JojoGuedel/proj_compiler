using System.Collections.Immutable;

namespace Nyx.Analysis.Syntax;

internal class Struct : Member
{
    internal override Location location => Location.Embrace(modifiers, members.Last());
    public Modifiers modifiers { get; }
    public Identifier name { get; }
    public ImmutableArray<StructMember> members { get; }

    internal Struct(Modifiers modifiers, Token @struct, Identifier name, Token semicolon, Token newLine, ImmutableArray<StructMember> members)
    {
        this.modifiers = modifiers;
        this.name = name;
        this.members = members;
    }
}