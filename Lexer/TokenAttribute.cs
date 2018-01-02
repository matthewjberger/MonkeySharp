namespace Lexer
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class TokenAttribute : System.Attribute
    {
        public string Token;

        public TokenAttribute(string token)
        {
            Token = token;
        }
    }
}
