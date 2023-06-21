using UnityEngine;

[CreateAssetMenu(fileName = "DemoSO", menuName = "DemoSO")]
public class DemoSO : ScriptableObject
{
    [field: SerializeField] public int TestInt { get; set; }
    
    public string TestString;
    
    [SerializeField] private bool testBool;
}