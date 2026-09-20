using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class Heat : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject gameUI;

    private AudioSource audioSource;
    public AudioClip heatMusic;
    public AudioClip themeMusic;
    public bool inHeatMusic = false;

    private bool hasLost = false;

    void Start()
    {
        Debug.Log(GlobalPlayerVars.howHot);

        GlobalPlayerVars.howHot = 0;

        audioSource = GetComponent<AudioSource>();

        InvokeRepeating("IncreaseHeat", 1f, 1f);

        audioSource.clip = themeMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.fKey.wasPressedThisFrame &&
            !hasLost)
        {
            GlobalPlayerVars.howHot += 500;

            Debug.Log(
                "F pressed. Heat is now: " +
                GlobalPlayerVars.howHot
            );

            if (GlobalPlayerVars.howHot >= 100)
            {
                Lose();
                return;
            }

        }

        if (hasLost)
            return;

        if (GlobalPlayerVars.howHot >= 100)
        {
            Lose();
            return;
        }

        if (GlobalPlayerVars.howHot >= 88)
        {
            if (heatMusic != null && inHeatMusic == false)
            {
                audioSource.Stop();
                audioSource.loop = false;
                audioSource.PlayOneShot(heatMusic, 0.5f);
                

                StartCoroutine(Wait13sec());
                
            }
        }
        else
        {
            
        }
    }

    void IncreaseHeat()
    {
        if (hasLost)
            return;

        GlobalPlayerVars.howHot++;

        Debug.Log(GlobalPlayerVars.howHot);
    }

    void Lose()
    {
        if (hasLost)
            return;

        hasLost = true;

        CancelInvoke("IncreaseHeat");

        if (gameUI != null)
            gameUI.SetActive(false);

        if (losePanel != null)
            losePanel.SetActive(true);

        Debug.Log("PLAYER LOST - HEAT REACHED 100");
    }

    public void RestartMasterScene()
    {
        Time.timeScale = 1f;
        GlobalPlayerVars.orderNmbr = 0;
        SceneManager.LoadScene("MasterScene");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
    IEnumerator Wait13sec()
    {
        inHeatMusic = true;
        yield return new WaitForSeconds(12f);
        inHeatMusic = false;
        audioSource.Play();
    }
}