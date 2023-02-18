using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CubeContainer : MonoBehaviour
{
    public static List<BasicCube> Cubes = new List<BasicCube>();

    public static void AddToList(BasicCube cube)
    {
        Cubes.Add(cube);
    }

    public static void RemoveFromList(BasicCube cube)
    {
        Cubes.Remove(cube);
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        foreach (BasicCube basicCube in Cubes)
        {
            Vector3 containerPos = transform.position;
            Vector3 cubePos = basicCube.transform.position;
            float halfHeight = (containerPos.y - cubePos.y) * .5f;
            Vector3 offset = Vector3.up * halfHeight;

            Handles.DrawBezier(containerPos, cubePos, containerPos - offset, containerPos + offset,
                Color.black, Texture2D.whiteTexture, 1f);
        }
    }
    #endif
}