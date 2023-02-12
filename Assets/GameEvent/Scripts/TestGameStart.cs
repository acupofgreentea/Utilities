using UnityEngine;

public class TestGameStart : MonoBehaviour
{
    [SerializeField] private GameEventListener gameEventListener;

    private void Start()
    {
        gameEventListener.Register(DestroyGameObject);
    }

    private void OnDisable()
    {
        gameEventListener.Unregister();
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}