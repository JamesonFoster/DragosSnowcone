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
        if (customerSpawner == null)
        {
            Debug.LogWarning("CustomerSpawner is not assigned to DaySystem.");
            return;
        }

        int customerCount = 0;

        foreach (Customer customer in customerSpawner.normCust)
        {
            if (customer != null && customer.custLvl <= GlobalPlayerVars.lvl)
            {
                customerCount++;
            }
        }

        foreach (Customer customer in customerSpawner.hardCust)
        {
            if (customer != null && customer.custLvl <= GlobalPlayerVars.lvl)
            {
                customerCount++;
            }
        }

        GlobalPlayerVars.custToday = customerCount;

        Debug.Log(
            "Level " +
            GlobalPlayerVars.lvl +
            " has " +
            GlobalPlayerVars.custToday +
            " customers today."
        );
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