using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Delay 
{
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
}
