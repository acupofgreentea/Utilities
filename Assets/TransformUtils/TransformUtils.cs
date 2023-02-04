using UnityEngine;

public static class TransformUtils
{
    public static float GetDistanceSquared(Vector3 a, Vector3 b)
    {
        return (b - a).sqrMagnitude;
    }

    public static float GetDistance(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }

    public static bool CheckIsFront(Vector3 forward, Vector3 directionNormalized)
    {
        float dist = Vector3.Dot(forward, directionNormalized);

        return dist > 0f;
    }
}
