using Nyx.Symbols;

// namespace Nyx.Analysis;

// internal interface Binder {}

// internal class GlobalBinder : Binder
// {
    
// }


// internal interface IReadonlyScope
// {
//     public Symbol? Lookup(string name);
// }

// internal interface IScope : IReadonlyScope 
// {
//     public bool Declare(Symbol symbol);
// }

// class Scope : IScope
// {
//     Dictionary<string, Symbol> _symbols;
//     Scope? _parent;

//     public Scope(Scope? parent)
//     {
//         _symbols = new Dictionary<string, Symbol>();
//         _parent = parent;
//     }

//     public bool Declare(Symbol symbol)
//     {
//         return _symbols.TryAdd(symbol.name, symbol);
//     }

//     public Symbol? Lookup(string name)
//     {
//         var val = _symbols.GetValueOrDefault(name);
//         if (val is null)
//             val = _parent?.Lookup(name);
//         return val;
//     }
// }

// class TypeScope : IScope
// {
//     Dictionary<string, Symbol> _symbols;

//     public TypeScope()
//     {
//         _symbols = new Dictionary<string, Symbol>();
//     }

//     public bool Declare(Symbol symbol)
//     {
//         return _symbols.TryAdd(symbol.name, symbol);
//     }

//     public Symbol? Lookup(string name)
//     {
//         return _symbols.GetValueOrDefault(name);
//     }
// }

// public class EnvironmentBuilder
// {
//     _CompilationUnit _compilationUnit;

//     Scope _globalScope;
//     Scope _currentScope;

//     public EnvironmentBuilder(_CompilationUnit compilationUnit)
//     {
//         _compilationUnit = compilationUnit;

//         _globalScope = new Scope(null);
//         _currentScope = _globalScope;
//     }

//     Symbols.Symbol? _ResolveName(Expression name)
//     {
//         switch(name)
//         {
//             case MemberAccess memberAccess:
//                 return _ResolveName(memberAccess.expression)?.scope?.Lookup(memberAccess.identifier.name);
//             case Identifier identifier:
//                 return _currentScope.Lookup(identifier.name);
//             default:
//                 return null;
//         }
//     }

//     public IReadonlyScope Build() 
//     {
//         foreach(var member in _compilationUnit.members)
//         {
//             if (member is )
//         } 
//         throw new NotImplementedException();
//     }
// }
