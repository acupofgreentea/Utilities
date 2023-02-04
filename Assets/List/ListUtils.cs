using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ListUtils
{
    public static T GetLastItem<T>(List<T> list)
    {
#if UNITY_2021_3_OR_NEWER
        return list[^1];
#else
        return list[list.Count - 1];
#endif
    }
}