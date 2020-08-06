using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedScript : MonoBehaviour
{
    public void QuitFromDeathScreen()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void RestartFromDeathScreen()
    {
        Debug.Log("Restart");
        Restart();
    }

    void Restart()
    {
        SceneManager.LoadScene(1);
    }
}

