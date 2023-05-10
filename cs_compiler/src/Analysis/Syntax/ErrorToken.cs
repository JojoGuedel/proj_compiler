namespace Nyx.Analysis.Syntax;

internal class ErrorToken : ValueToken
{
    internal ErrorToken(Token token) : base(token.kind, token.location, string.Empty) { }
}