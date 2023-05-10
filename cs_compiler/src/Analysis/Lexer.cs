using System.Diagnostics;
using Nyx.Analysis.Syntax;

namespace Nyx.Analysis;

internal class Lexer
{
    TextReader _source;

    bool _finished = false;

    char _last = SyntaxInfo.endChar;
    char _current = SyntaxInfo.endChar;
    char _next = SyntaxInfo.endChar;

    bool _newLine = true;
    int _pos = 0;
    int _begin = 0;
    int _length { get => _pos - _begin; }
    int _line = 1;
    int _lineBegin = 1;

    // TODO: Fix location.
    Location _location { get => new Location(_begin, _pos, _lineBegin, _line); }

    // Dictionary<Token, string> _values = new Dictionary<Token, string>();

    internal Lexer(TextReader source)
    {
        _source = source;

        _Next(2);
    }

    char _Next()
    {
        _pos++;
        _last = _current;
        _current = _next;
        _next = _Read();

        return _last;
    }

    char _Next(int increment)
    {
        Debug.Assert(increment >= 0);

        _last = _current;
        
        for(int i = 0; i < increment; i++)
        {
            _current = _next;
            _next = _Read();
        }

        return _last;
    }

    char _Read()
    {
        var result = _source.Read();

        if (result < 0)
            return SyntaxInfo.endChar;

        return (char) result; 
    }

    Token _LexComment()
    {
        while (!SyntaxInfo.IsLineTerminator((_last, _current)))
            _Next();
        
        _Next();
            
        return new Token(TokenKind.comment, _location);
    }

    Token _LexBlockComment()
    {
        while (!SyntaxInfo.IsBlockCommentTerimator((_last, _current)))
            _Next();
        
        _Next();
            
        return new Token(TokenKind.comment, _location);
    }

    ValueToken _LexCharSequence(TokenKind kind)
    {
        var terminator = _current;

        var value = string.Empty;
        while ((_current == SyntaxInfo.escapeChar || _next != terminator))
        {
            if (SyntaxInfo.IsLineTerminator((_last, _current)))
                // TODO: diagnostics
                throw new NotImplementedException();

            value += _Next();
        }

        value += _Next();
        value += _Next();

        if (kind == TokenKind.@char && value.Length != 3)
            // TODO: diagnostics
            throw new NotImplementedException();

        return new ValueToken(kind, _location, value);
    }

    internal Token LexNext()
    {
        _begin = _pos;
        _lineBegin = _line;

        // lex indents after a new line
        if (_newLine)
        {
            while (_length < SyntaxInfo.indentSize && SyntaxInfo.GetTokenKind(_current) == TokenKind.space)
                _Next();

            if (_length % SyntaxInfo.indentSize != 0)
            {
                // TODO: diagnostics
                throw new NotImplementedException();
            }
            else if (_length > 0)
                return new Token(TokenKind.indent, _location);

            _newLine = false;
        }

        // lex numbers
        if (char.IsDigit(_current))
        {
            var value = string.Empty;
            while (char.IsDigit(_current)) 
                value += _Next();
            // TODO: Handle '.'
            // TODO: Handle formats
            // TODO: handle scientific format
            return new ValueToken(TokenKind.number, _location, value);
        }
        // lex operators and names
        else
        {
            var increment = 2;
            var kind = SyntaxInfo.GetTokenKind((_current, _next));

            if (kind == TokenKind._error)
            {
                increment = 1;
                kind = SyntaxInfo.GetTokenKind(_current);
            }
            
            switch (kind)
            {
                case TokenKind._error:
                    break;
                // filter specialcases
                case TokenKind.commentMarker:
                    return _LexComment();
                case TokenKind.commentBeginMarker:
                    return _LexBlockComment();
                case TokenKind.stringMarker:
                    return _LexCharSequence(TokenKind.@string);
                case TokenKind.charMarker:
                    return _LexCharSequence(TokenKind.@char);
                case TokenKind.end:
                    _finished = true;
                    goto default;
                // handle new lines
                case TokenKind.newLine:
                    _line++;
                    _newLine = true;
                    goto default;
                // filter markers
                default:
                    _Next(increment);
                    return new Token(kind, _location);
            }

            var value = string.Empty;
            while (char.IsLetterOrDigit(_current) || _current == '_')
                value += _Next();

            // filter invalid chars
            if (_length <= 0)
            {
                _Next();
                return new Token(TokenKind.invalidChar, _location);
            }

            kind = SyntaxInfo.GetTokenKind(value);
            // filter keywords
            if (kind != TokenKind._error)
                return new Token(kind, _location);

            return new ValueToken(TokenKind.identifier, _location, value);
        }
    }

    internal IEnumerable<Token> Analyze()
    {
        do 
            yield return LexNext();
        while (!_finished);

        _source.Close();
    }
}