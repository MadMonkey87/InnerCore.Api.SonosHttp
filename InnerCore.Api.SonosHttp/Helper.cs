using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace InnerCore.Api.SonosHttp
{
    public static class Helper
    {
        public static int Clamp(int value, int max, int min)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        public static String GetEnumMemberValue<T>(T value)
            where T : struct, IConvertible
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }
    }
}
