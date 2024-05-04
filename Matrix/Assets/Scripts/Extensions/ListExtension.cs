using System.Collections.Generic;

namespace DefaultNamespace.Extensions
{
    public static class ListExtension
    {
        public static bool IsEqual<T>(this List<List<T>> list, List<List<T>> other)
        {
            //TODO сделать логику сравнения листов по значениям
            return false;
        }
    }
}