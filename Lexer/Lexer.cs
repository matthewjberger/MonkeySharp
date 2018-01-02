using System.Collections.Generic;

namespace Lexer
{
    public class Lexer
    {
        /// <summary>
        /// The input text.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// The current position in the input string
        /// (points to the current character).
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// The current reading position in the input string
        /// (after the current char).
        /// </summary>
        public int ReadPosition { get; set; }

        /// <summary>
        ///  The current character under examination.
        /// </summary>
        public char CurrentCharacter { get; set; }

        public static readonly Dictionary<TokenType, string> TokenDictionary = new Dictionary<TokenType, string>
            {
                { TokenType.Assign, "=" },
                { TokenType.Plus, "+" },
                { TokenType.LeftParentheses, "(" },
                { TokenType.RightParentheses, ")" },
                { TokenType.LeftBrace, "{" },
                { TokenType.RightBrace, "}" },
                { TokenType.Comma, "," },
                { TokenType.SemiColon, ";" },
                { TokenType.EndOfFile, " " }
            };

        public static Token CreateToken(TokenType type)
        {
            return CreateToken(type, TokenDictionary[type]);
        }

        public static Token CreateToken(TokenType type, string literal) => new Token
        {
            Type = type,
            Literal = literal
        };

        public Lexer(string input)
        {
            Input = input;
            ReadChar();
        }

        public Token NextToken()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gives the next character in the input and
        /// advances the read position in the input.
        /// </summary>
        public void ReadChar()
        {
            CurrentCharacter = ReadPosition >= Input.Length ? '\0' : Input[ReadPosition];
            ReadPosition++;
        }
    }
}
