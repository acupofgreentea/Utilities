using UnityEngine;
using UnityEngine.Events;

public class TestEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] private GameEvent testEvent;

    [SerializeField] private UnityEvent response;

    private void Start()
    {
        if (testEvent != null)
        {
            testEvent.AddListener(this);
        }
    }

    private void OnDisable()
    {
        if (testEvent != null)
        {
            testEvent.RemoveListener(this);
        }
    }

    public void OnEventRaised()
    {
        response?.Invoke();
    }
}