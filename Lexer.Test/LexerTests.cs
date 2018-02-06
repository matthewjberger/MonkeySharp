namespace Lexer.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class LexerTests
    {

        [TestMethod]
        public void LexerTests_CreateToken()
        {
            const TokenType type = TokenType.Assign;
            const string literal = "=";

            var token = new Token
            {
                Type = type,
                Literal = literal
            };

            Assert.IsTrue(token.Equals(Lexer.CreateToken(type, literal)));
        }

        [TestMethod]
        public void LexerTests_NextToken()
        {
            const string input = "=+(){},;";
            var lexer = new Lexer(input);
            var expectedTokens = new List<Token>
            {
                Lexer.CreateToken(TokenType.Assign, "="),
                Lexer.CreateToken(TokenType.Plus, "+"),
                Lexer.CreateToken(TokenType.LeftParentheses, "("),
                Lexer.CreateToken(TokenType.RightParentheses, ")"),
                Lexer.CreateToken(TokenType.LeftCurlyBrace, "{"),
                Lexer.CreateToken(TokenType.RightCurlyBrace, "}"),
                Lexer.CreateToken(TokenType.Comma, ","),
                Lexer.CreateToken(TokenType.SemiColon, ";"),
                Lexer.CreateToken(TokenType.EndOfFile, "")
            };

            expectedTokens.ForEach(token => Assert.IsTrue(token.Equals(lexer.NextToken())));
        }

        [TestMethod]
        public void LexerTests_NextTokenWithSourceCode()
        {
            const string input = 
@"let five = 5;
let ten = 10;

let add = fn(x, y) {
    x + y;
};

let result = add(five, ten);
";
            var lexer = new Lexer(input);
            var expectedTokens = new List<Token>
            {

                // "let five = 5;"
                Lexer.CreateToken(TokenType.Let, "let"),
                Lexer.CreateToken(TokenType.Identifier, "five"),
                Lexer.CreateToken(TokenType.Assign, "="),
                Lexer.CreateToken(TokenType.Int, "5"),
                Lexer.CreateToken(TokenType.SemiColon, ";"),

                // "let ten = 10;"
                Lexer.CreateToken(TokenType.Let, "let"),
                Lexer.CreateToken(TokenType.Identifier, "ten"),
                Lexer.CreateToken(TokenType.Assign, "="),
                Lexer.CreateToken(TokenType.Int, "10"),
                Lexer.CreateToken(TokenType.SemiColon, ";"),

                // "let add = fn(x, y) { x + y; };"
                Lexer.CreateToken(TokenType.Let, "let"),
                Lexer.CreateToken(TokenType.Identifier, "add"),
                Lexer.CreateToken(TokenType.Assign, "="),
                Lexer.CreateToken(TokenType.Function, "fn"),
                Lexer.CreateToken(TokenType.LeftParentheses, "("),
                Lexer.CreateToken(TokenType.Identifier, "x"),
                Lexer.CreateToken(TokenType.Comma, ","),
                Lexer.CreateToken(TokenType.Identifier, "y"),
                Lexer.CreateToken(TokenType.RightParentheses, "("),
                Lexer.CreateToken(TokenType.LeftCurlyBrace, "{"),
                Lexer.CreateToken(TokenType.Identifier, "x"),
                Lexer.CreateToken(TokenType.Plus, "+"),
                Lexer.CreateToken(TokenType.Identifier, "y"),
                Lexer.CreateToken(TokenType.SemiColon, ";"),
                Lexer.CreateToken(TokenType.RightCurlyBrace, "}"),
                Lexer.CreateToken(TokenType.SemiColon, ";"),

                // "let result = add(five, ten);"
                Lexer.CreateToken(TokenType.Let, "let"),
                Lexer.CreateToken(TokenType.Identifier, "result"),
                Lexer.CreateToken(TokenType.Assign, "="),
                Lexer.CreateToken(TokenType.Identifier, "add"),
                Lexer.CreateToken(TokenType.LeftParentheses, "("),
                Lexer.CreateToken(TokenType.Identifier, "five"),
                Lexer.CreateToken(TokenType.Comma, ","),
                Lexer.CreateToken(TokenType.Identifier, "ten"),
                Lexer.CreateToken(TokenType.RightParentheses, ")"),
                Lexer.CreateToken(TokenType.SemiColon, ";"),

                Lexer.CreateToken(TokenType.EndOfFile, "")
 
            };

            expectedTokens.ForEach(token => Assert.IsTrue(token.Equals(lexer.NextToken())));
        }
    }
}
