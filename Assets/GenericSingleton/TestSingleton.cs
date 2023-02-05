using UnityEngine;

public class TestSingleton : GenericSingleton<MonoBehaviour>
{
    public override void Awake()
    {
        base.Awake();
        
        Debug.LogError("test singleton");
    }
}