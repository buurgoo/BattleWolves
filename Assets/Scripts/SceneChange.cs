using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string nextScene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}