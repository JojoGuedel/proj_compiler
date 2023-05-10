using System.Collections.Immutable;

namespace Nyx.Analysis.Syntax;

internal class Block : Node
{
    internal override Location location { get; }
    public ImmutableArray<Statement> statements { get; }

    internal Block(ImmutableArray<Statement> statements, Location location)
    {
        this.location = location;
        this.statements = statements;
    }
}