namespace Nyx.Analysis;

internal class Namespace : Member
{
    internal override Location location { get; }
    public Expression name { get; }

    internal Namespace(Token @namespace, Expression name, Token semicolon, Token newLine)
    {
        location = Location.Embrace(@namespace.location, semicolon.location);
        this.name = name;
    }
}