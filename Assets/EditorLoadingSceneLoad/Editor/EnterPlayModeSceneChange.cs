using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class EnterPlayModeSceneChange
{
    private static readonly string loadingScenePath = "Assets/EditorLoadingSceneLoad/LoadingScene.unity";
    
    private static readonly SceneAsset loadingScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(loadingScenePath);
    
    static EnterPlayModeSceneChange()
    {
        EditorSceneManager.playModeStartScene = loadingScene;
    }
}