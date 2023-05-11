namespace Nyx.Analysis.Syntax;

internal class PassStatement : Statement
{
    internal override Location location { get; }

    internal PassStatement(Token pass, Token semicolon, Token newLine)
    {
        location = pass.location;
    }
}
