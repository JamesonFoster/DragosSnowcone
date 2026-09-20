using System.Collections;
using UnityEngine;

public class Heat : MonoBehaviour
{
    public GameObject losePanel;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(GlobalPlayerVars.howHot);
        GlobalPlayerVars.howHot = 0;
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
        
        
    }
    

    void IncreaseHeat()
    {
        GlobalPlayerVars.howHot++;
        Debug.Log(GlobalPlayerVars.howHot);
    }
}
