using System;
using System.Collections.Generic;

namespace Lexer
{
    public class Token : IEquatable<Token>
    {

        public TokenType Type { get; set; }

        public string Literal { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Type * 397) ^ (Literal != null ? Literal.GetHashCode() : 0);
            }
        }

        #region Comparison Functions

        public override bool Equals(object obj)
        {
            return Equals(obj as Token);
        }

        public bool Equals(Token other)
        {
            return other != null &&
                   Type == other.Type &&
                   Literal == other.Literal;
        }

        public static bool operator ==(Token token1, Token token2)
        {
            return EqualityComparer<Token>.Default.Equals(token1, token2);
        }

        public static bool operator !=(Token token1, Token token2)
        {
            return !(token1 == token2);
        }

        #endregion
    }
}
