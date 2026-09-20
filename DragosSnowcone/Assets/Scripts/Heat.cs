using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Heat : MonoBehaviour
{
    public GameObject losePanel;
    private AudioSource audioSource;
    public AudioClip heatMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(GlobalPlayerVars.howHot);
        GlobalPlayerVars.howHot = 0;
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("IncreaseHeat", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        if (GlobalPlayerVars.howHot >= 100)
        {
            Debug.Log("should lose");
            losePanel.SetActive(true);
            GlobalPlayerVars.howHot = 0;
        }

        if (GlobalPlayerVars.howHot >= 88)
        {
            audioSource.PlayOneShot(heatMusic, 1.0f);
        }


    }


    void IncreaseHeat()
    {
        GlobalPlayerVars.howHot++;
        Debug.Log(GlobalPlayerVars.howHot);
    }
}
