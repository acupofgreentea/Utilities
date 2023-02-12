#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameEvent gameEvent = (GameEvent)target;
        
        if (GUILayout.Button("Raise"))
        {
            gameEvent.Raise();
        }
    }
}
#endif
