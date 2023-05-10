namespace Nyx.Analysis.Syntax;

internal class ErrorToken : Token
{
    internal ErrorToken(Token token) : base(token.kind, token.location) { }
}