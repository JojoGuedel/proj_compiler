namespace Nyx.Analysis.Syntax;

internal class ErrorValueToken : ValueToken
{
    internal ErrorValueToken(ValueToken token) : base(token.kind, token.location, token.value) { }
}