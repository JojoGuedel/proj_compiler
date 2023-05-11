namespace Nyx.Analysis.Syntax;

internal class StructPassStatement : StructMember
{
    internal override Location location { get; }

    internal StructPassStatement(Token pass, Token semicolon, Token newLine)
    {
        location = pass.location;
    }
}


