namespace Nyx.Analysis;

internal class ErrorToken : Token
{
    internal ErrorToken(Token token) : base(token.kind, token.location) { }
}