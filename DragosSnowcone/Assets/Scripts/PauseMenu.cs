using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject creditsPanel;

    private bool isPaused = false;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
            {
                return;
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;

        pausePanel.SetActive(true);
        creditsPanel.SetActive(false);

        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = false;

        pausePanel.SetActive(false);
        creditsPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void ShowCredits()
    {
        pausePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        creditsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}