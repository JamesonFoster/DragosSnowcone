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