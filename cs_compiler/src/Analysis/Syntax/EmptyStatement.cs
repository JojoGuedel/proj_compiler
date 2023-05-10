namespace Nyx.Analysis.Syntax;

internal class EmptyStatement : Statement
{
    internal override Location location { get; }
    
    internal EmptyStatement(Location location) 
    { 
        this.location = location;
    }
}