namespace Nyx.Analysis.Syntax;

internal class Boolean : Expression
{
    internal override Location location => boolean.location;
    public Token boolean { get; }

    internal Boolean(Token boolean)
    {
        this.boolean = boolean;
    }
}