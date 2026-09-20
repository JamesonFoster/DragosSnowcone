using UnityEngine;
using UnityEngine.SceneManagement;

public class DaySystem : MonoBehaviour
{
    public GameObject endDayPanel;

    private bool dayEnded = false;

    void Start()
    {
        if (endDayPanel != null)
            endDayPanel.SetActive(false);

        SetCustomersForLevel();
    }

    void Update()
    {
        if (dayEnded)
            return;

        if (GlobalPlayerVars.custToday <= 0)
        {
            EndDay();
        }
    }

    void SetCustomersForLevel()
    {
        switch (GlobalPlayerVars.lvl)
        {
            case 1:
                GlobalPlayerVars.custToday = 5;
                break;

            case 2:
                GlobalPlayerVars.custToday = 7;
                break;

            case 3:
                GlobalPlayerVars.custToday = 10;
                break;

            case 4:
                GlobalPlayerVars.custToday = 12;
                break;

            case 5:
                GlobalPlayerVars.custToday = 15;
                break;

            default:
                GlobalPlayerVars.custToday = 15;
                break;
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