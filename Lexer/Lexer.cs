namespace Lexer
{
    using System;

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
        public int CurrentPosition { get; set; }

        /// <summary>
        /// The current reading position in the input string
        /// (after the current char).
        /// </summary>
        public int NextReadPosition { get; set; }

        /// <summary>
        ///  The current character under examination.
        /// </summary>
        public char CurrentCharacter { get; set; }


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

        /// <summary>
        /// Finds the corresponding token type for a specific keyword
        /// </summary>
        /// <param name="identifier">The keyword to lookup</param>
        public TokenType LookupIdentifier(string identifier)
        {
            switch (identifier)
            {
                case "fn": return TokenType.Function;
                case "let": return TokenType.Let;
                default: return TokenType.Identifier;
            }
        }

        /// <summary>
        /// Advances the parser by one token.
        /// </summary>
        /// <returns>The next token read in by the lexer.</returns>
        public Token NextToken()
        {
            SkipUnusedCharacters();
            Token token;
            switch (CurrentCharacter)
            {
                case '=':
                    token = CreateToken(TokenType.Assign, CurrentCharacter.ToString());
                    break;

                case ';':
                    token = CreateToken(TokenType.SemiColon, CurrentCharacter.ToString());
                    break;

                case '(':
                    token = CreateToken(TokenType.LeftParentheses, CurrentCharacter.ToString());
                    break;

                case ')':
                    token = CreateToken(TokenType.RightParentheses, CurrentCharacter.ToString());
                    break;

                case ',':
                    token = CreateToken(TokenType.Comma, CurrentCharacter.ToString());
                    break;

                case '+':
                    token = CreateToken(TokenType.Plus, CurrentCharacter.ToString());
                    break;

                case '{':
                    token = CreateToken(TokenType.LeftCurlyBrace, CurrentCharacter.ToString());
                    break;

                case '}':
                    token = CreateToken(TokenType.RightCurlyBrace, CurrentCharacter.ToString());
                    break;

                case '\0':
                    token = CreateToken(TokenType.EndOfFile, string.Empty);
                    break;

                default:
                    if (IsIdentifierCharacterLegal(CurrentCharacter))
                    {

                        var literal = ReadIdentifier();
                        token = CreateToken(LookupIdentifier(literal), literal);
                    }
                    else if (char.IsDigit(CurrentCharacter))
                    {
                        
                        var literal = ReadNumber();
                        token = CreateToken(LookupIdentifier(literal), literal);
                    }
                    else
                    {
                        token = CreateToken(TokenType.Illegal, CurrentCharacter.ToString());
                    }
                    break;
            }

            ReadChar();
            return token;
        }

        /// <summary>
        /// Gives the next character in the input and
        /// advances the read position in the input.
        /// </summary>
        public void ReadChar()
        {
            CurrentCharacter = NextReadPosition >= Input.Length ? '\0' : Input[NextReadPosition];
            NextReadPosition++;
        }

        /// <summary>
        /// Reads an identifier in.
        /// </summary>
        public string ReadIdentifier()
        {
            return AdvanceWhileTrue(char.IsLetter, CurrentCharacter);
        }

        /// <summary>
        /// Reads a number in.
        /// </summary>
        public string ReadNumber()
        {
            return AdvanceWhileTrue(char.IsDigit, CurrentCharacter);
        }

        /// <summary>
        /// Advances the read position while a predicate is satisfied.
        /// </summary>
        /// <param name="predicate">The condition to be satisfied</param>
        /// <param name="character">The current character</param>
        /// <returns>The identifier that was read in</returns>
        private string AdvanceWhileTrue(Func<char, bool> predicate, char character)
        {
            var initialPosition = CurrentPosition;
            while (predicate(character)) ReadChar();
            return Input.Substring(initialPosition, CurrentPosition);

        }

        /// <summary>
        /// Checks if a character is legal to use in an identifier
        /// </summary>
        /// <param name="character">The character to check</param>
        public bool IsIdentifierCharacterLegal(char character)
        {
            return char.IsLetter(character) || character == '_';
        }

        /// <summary>
        /// Skips characters that shouldn't be lexed,
        /// such as whitespace and comments
        /// </summary>
        public void SkipUnusedCharacters()
        {
            // Skip whitespace
            while(char.IsWhiteSpace(CurrentCharacter)) ReadChar();
        }
    }
}
