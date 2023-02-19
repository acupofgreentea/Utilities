using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class EnterPlayModeSceneChange
{ 
    private static readonly string loadingScenePath = "Assets/EditorLoadingSceneLoad/LoadingScene.unity";

    static EnterPlayModeSceneChange()
    {
        SceneAsset loadingScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(loadingScenePath);

        if (loadingScene == null)
        {
            Debug.LogWarning("There is no LoadingScene or not found!");
            
            EditorSceneManager.playModeStartScene =
                AssetDatabase.LoadAssetAtPath<SceneAsset>(EditorSceneManager.GetActiveScene().path);
            
            return;
        }
        
        EditorSceneManager.playModeStartScene = loadingScene;
    }
}