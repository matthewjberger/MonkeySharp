namespace Lexer
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            return value
                    .GetType()
                    .GetTypeInfo()
                    .DeclaredMembers
                    .Single(attribute => attribute.Name == value.ToString())
                    .GetCustomAttributes(typeof(T), false)
                    .First() as T;
        }
    }
}
