namespace Nyx.Analysis.Syntax;

internal class ElseStatement : Statement
{
    internal override Location location { get; }
    public Block body { get; }

    public ElseStatement(Token @else, Token colon, Token newLine, Block body)
    {
        location = Location.Embrace(@else, body);
        this.body = body;
    }
}