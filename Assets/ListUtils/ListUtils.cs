using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public static class ListUtils
{
    public static T GetLastItem<T>(this List<T> list)
    {
#if UNITY_2021_3_OR_NEWER
        return list[^1];
#else
        return list[list.Count - 1];
#endif
    }

    public static void FillListByParent<T>(List<T> list, Transform parent)
    {
        if (parent == null || list == null) return;

        list.Clear();

        list.AddRange(parent.Cast<T>());
    }
    
    public static List<T> Shuffle<T>(this List<T> list)
    {
        return list.OrderBy(elem => Guid.NewGuid()).ToList();
    }
    
    public static T RandomItem<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}