using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Heat : MonoBehaviour
{
    public GameObject losePanel;
    private AudioSource audioSource;
    public AudioClip heatMusic;

    private bool hasLost = false;

    void Start()
    {
        Debug.Log(GlobalPlayerVars.howHot);

        GlobalPlayerVars.howHot = 0;

        audioSource = GetComponent<AudioSource>();

        InvokeRepeating("IncreaseHeat", 1f, 1f);
    }

    void Update()
    {
        if (hasLost)
            return;

        if (GlobalPlayerVars.howHot >= 100)
        {
            Lose();
            return;
        }

        if (GlobalPlayerVars.howHot >= 88)
        {
            if (!audioSource.isPlaying && heatMusic != null)
            {
                audioSource.PlayOneShot(heatMusic, 1.0f);
            }
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
        hasLost = true;

        CancelInvoke("IncreaseHeat");

        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }

        Debug.Log("PLAYER LOST - HEAT REACHED 100");
    }
}