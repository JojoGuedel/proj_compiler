namespace Nyx.Analysis.Syntax;

internal class AccessorClause : Node
{
    internal override Location location { get; }


    internal AccessorClause(Token rArrow, Token get, Token set, Token semicolon)
    {
        location = Location.Embrace(rArrow, semicolon);
    }
}
