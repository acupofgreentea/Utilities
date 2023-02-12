using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class GameEventListener : IGameEventListener
{
    [SerializeField] private GameEvent testEvent;

    private UnityAction response = null;

    public void Register(UnityAction response)
    {
        if(testEvent != null)
            testEvent.AddListener(this);

        this.response = response;
    }

    public void Unregister()
    {
        if(testEvent != null)
            testEvent.RemoveListener(this);

        response = null;
    }
    public void OnEventRaised()
    {
        response?.Invoke();
    }
}