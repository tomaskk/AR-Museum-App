using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationScriptInsideAR : MonoBehaviour
{
    public void BackToPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
