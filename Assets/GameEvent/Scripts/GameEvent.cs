using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Event", menuName = "Game Event", order = 0)]
public class GameEvent : ScriptableObject
{
    private readonly List<IGameEventListener> eventListeners = new List<IGameEventListener>();

    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised();
        }
    }

    public void AddListener(IGameEventListener listener)
    {
        if(!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void RemoveListener(IGameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}