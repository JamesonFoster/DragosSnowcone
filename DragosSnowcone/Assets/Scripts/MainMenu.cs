using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SamTest");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}