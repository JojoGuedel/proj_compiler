namespace Nyx.Analysis;

internal class IncludeAs : Member
{
    internal override Location location { get; }
    public String file { get; }
    public Expression name { get; }

    internal IncludeAs(Token include, String file, Token @as, Expression name, Token semicolon, Token newLine)
    {
        location = Location.Embrace(include.location, semicolon.location);
        this.file = file;
        this.name = name;
    }
}