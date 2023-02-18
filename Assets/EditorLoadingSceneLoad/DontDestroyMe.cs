using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMe : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Debug.LogError("awake" + SceneManager.GetActiveScene().name);
    }

    private void OnEnable()
    {
        Debug.LogError("start" + SceneManager.GetActiveScene().name);
    }
    
    private void LateUpdate()
    {
        Debug.LogError("lateupdate" + SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        Debug.LogError("update" + SceneManager.GetActiveScene().name);
    }
    
    private void FixedUpdate()
    {
        Debug.LogError("fixedupdate" + SceneManager.GetActiveScene().name);
    }
}
