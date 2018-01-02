namespace Lexer.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void LexerTests_TextNextToken()
        {
            const string input = "=+(){},;";
            var lexer = new Lexer(input);
            var expectedTokens = new List<Token>
            {
                Lexer.CreateToken(TokenType.Assign),
                Lexer.CreateToken(TokenType.Plus),
                Lexer.CreateToken(TokenType.LeftParentheses),
                Lexer.CreateToken(TokenType.RightParentheses),
                Lexer.CreateToken(TokenType.LeftBrace),
                Lexer.CreateToken(TokenType.RightBrace),
                Lexer.CreateToken(TokenType.Comma),
                Lexer.CreateToken(TokenType.SemiColon),
                Lexer.CreateToken(TokenType.EndOfFile)
            };

            expectedTokens.ForEach(token => Assert.IsTrue(token.Equals(lexer.NextToken())));
        }
    }
}
