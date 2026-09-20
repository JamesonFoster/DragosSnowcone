using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DaySystem : MonoBehaviour
{
    public GameObject endDayPanel;

    public CustomerSpawner customerSpawner;

    private bool dayEnded = false;

    void Start()
    {
        if (endDayPanel != null)
            endDayPanel.SetActive(false);
    }

    void Update()
    {
        if (dayEnded)
            return;

        if (GlobalPlayerVars.custToday == GlobalPlayerVars.totalCustToday)
        {
            EndDay();
        }
    }

    void EndDay()
    {
        dayEnded = true;

        Time.timeScale = 0f;

        if (endDayPanel != null)
            endDayPanel.SetActive(true);
    }

    public void NextDay()
    {
        Time.timeScale = 1f;

        GlobalPlayerVars.lvl += 1;
        GlobalPlayerVars.orderNmbr = 0;

        SceneManager.LoadScene("MasterScene");
    }
}