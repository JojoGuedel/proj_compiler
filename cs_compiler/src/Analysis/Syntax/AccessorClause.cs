namespace Nyx.Analysis.Syntax;

internal class AccessorClause : Node
{
    internal override Location location { get; }
    public Token get { get; }
    public Token set { get; }

    internal AccessorClause(Token bigRArrow, Token get, Token set)
    {
        location = Location.Embrace(bigRArrow, set);
        this.get = get;
        this.set = set;
    }
}
