using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string nextScene;

    public virtual void ChangeScene()
    {
        Debug.Log($"Home: Changing scene to: {nextScene}");
        SceneManager.LoadScene(nextScene);
    }
}