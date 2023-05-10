namespace Nyx.Analysis.Syntax;

internal class Include : Member
{
    internal override Location location { get; }
    public String file { get; }

    internal Include(Token include, String file, Token semicolon, Token newLine)
    {
        location = Location.Embrace(include, semicolon);
        this.file = file;
    }
}