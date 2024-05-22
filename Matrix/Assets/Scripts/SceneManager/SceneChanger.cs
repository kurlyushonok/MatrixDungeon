using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private SceneName name;
    public void ChangeScene()
    {
        SceneManager.LoadScene((int)name);
    }
}

public enum SceneName {
    MainMenu,
    Task1Dialogue,
    Task1,
    Task2
}
