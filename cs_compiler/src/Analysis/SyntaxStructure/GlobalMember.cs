using Nyx.Utils;

namespace Nyx.Analysis;

public abstract class GlobalMember : Member
{
    protected GlobalMember(TextLocation location) : base(location) { }
}