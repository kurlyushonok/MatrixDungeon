using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int number)
    {
        SceneManager.LoadScene(number);
    }
}
