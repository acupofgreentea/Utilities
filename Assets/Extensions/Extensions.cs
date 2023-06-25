using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Extensions
{
    public static class Extensions
    {
        #region List

        public static T GetLastItem<T>(this List<T> list)
        {
#if UNITY_2021_3_OR_NEWER
            return list[^1];
#else
        return list[list.Count - 1];
#endif
        }

        public static void FillListByParent<T>(this List<T> list, Transform parent)
        {
            if (parent == null || list == null) return;

            list.Clear();

            list.AddRange(parent.Cast<T>());
        }

        public static List<T> ShuffleGUID<T>(this List<T> list)
        {
            return list.OrderBy(elem => Guid.NewGuid()).ToList();
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public static T RandomItem<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        #endregion

        #region Vector3

        public static float GetSqrMagnitude(this Vector3 a, Vector3 b)
        {
            return (b - a).sqrMagnitude;
        }

        public static float GetDistance(this Vector3 a, Vector3 b)
        {
            return Vector3.Distance(a, b);
        }

        public static Vector3 ToVector3(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0f, vector2.y);
        }

        public static Vector2 ToVector2(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }

        #endregion

        #region Transform

        public static float GetDot(this Transform forwardTransform, Transform target)
        {
            Vector3 forward = forwardTransform.forward;
            Vector3 directionNormalized = (target.position - forwardTransform.position).normalized;

            float dist = Vector3.Dot(forward, directionNormalized);

            return dist;
        }

        #endregion

        #region NavMesh
        
        public static Vector3 GetRandomPointOnNavMesh(this NavMeshAgent agent, float radius)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += agent.transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
            {
                finalPosition = hit.position;
            }

            return finalPosition;
        }

        #endregion

        #region MonoBehaviour
        
        public static void DelayConstTime(this MonoBehaviour monoBehaviour, UnityAction action, float delay)
        {
            monoBehaviour.StartCoroutine(Delay());

            IEnumerator Delay()
            {
                yield return new WaitForSeconds(delay);

                action?.Invoke();
            }
        }

        public static void DelayOneFrame(this MonoBehaviour monoBehaviour, UnityAction action)
        {
            monoBehaviour.StartCoroutine(Delay());

            IEnumerator Delay()
            {
                yield return null;
            
                action?.Invoke();
            }
        }

        public static void DelayNumberedFrame(this MonoBehaviour monoBehaviour, UnityAction action, int frameCount)
        {
            monoBehaviour.StartCoroutine(Delay());

            IEnumerator Delay()
            {
                for (int i = 0; i < frameCount; i++)
                {
                    yield return null;
                }
            
                action?.Invoke();
            }
        }
        #endregion
    }
}

public static class ThreadSafeRandom
{
    [ThreadStatic] private static System.Random Local;

    public static System.Random ThisThreadsRandom
    {
        get
        {
            return Local ??=
                new System.Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId));
        }
    }
}