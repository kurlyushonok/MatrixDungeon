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
    Task2Dialogue,
    Task2,
    Task3Dialogue,
    Task3,
    Task4Dialogue,
    Task4,
    Task5Dialogue,
    Task5,
    Task6Dialogue,
    Task6
}
