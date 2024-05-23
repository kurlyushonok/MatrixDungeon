using System.Collections.Generic;

namespace DefaultNamespace.Extensions
{
    public static class ListExtension
    {
        public static bool IsEqual(this List<List<int>> list, List<List<int>> other)
        {
            if (list.Count != other.Count) return false;
            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < list[0].Count; j++)
                    if (list[i][j] != other[i][j])
                        return false;
            return true;
        }
    }
}