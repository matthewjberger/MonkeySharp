namespace Lexer
{
    public enum TokenType
    {
        [Token("ILLEGAL")]
        Illegal,

        [Token("EOF")]
        EndOfFile,

        [Token("IDENT")]
        Identifier,

        [Token("INT")]
        Int,

        [Token("=")]
        Assign,

        [Token("+")]
        Plus,

        [Token(",")]
        Comma,

        [Token(";")]
        SemiColon,

        [Token("(")]
        LeftParentheses,

        [Token(")")]
        RightParentheses,

        [Token("{")]
        LeftBrace,

        [Token("}")]
        RightBrace,

        [Token("FUNCTION")]
        Function,

        [Token("LET")]
        Let
    };
}
